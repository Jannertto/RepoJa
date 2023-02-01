using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762_PJ
{

    public class SkillTree : MonoBehaviour
    {
        GameObject ShowTitle;
        GameObject ShowDescription;
        GameObject ShowImage;
        GameObject ShowResearchAmountText;
        GameObject Content;

        public SkillNode SelectedResearchTarget;

        List<string> NameList = new List<string>();
        List<float> ReseachNeedList = new List<float>();
        List<List<float>> ResearchDepensiesList = new List<List<float>>();

        private void Start()
        {
            ShowTitle = transform.Find("ShowPanel").Find("Title").gameObject;
            ShowDescription = transform.Find("ShowPanel").Find("Description").gameObject;
            ShowImage = transform.Find("ShowPanel").Find("Image").gameObject;
            ShowResearchAmountText = transform.Find("ShowPanel").Find("RA").gameObject;
            Content = transform.Find("ScrollView").Find("Viewport").Find("Content").gameObject;

            int id = 0;
            GreateSkillListing(ref id, "Cyborg", 1);
            GreateSkillListing(ref id, "Exoskeleton", 100, new List<float>() { 0 });
            GreateSkillListing(ref id, "Augmentation", 100, new List<float>() { 1 });
            GreateSkillListing(ref id, "ImprovedExoskeleton", 100, new List<float>() { 1 });
            GreateSkillListing(ref id, "ImprovedAugmentation", 100, new List<float>() { 2 });
            GreateSkillListing(ref id, "ProsessorAugments", 100, new List<float>() { 2 });
            GreateSkillListing(ref id, "ImprovedProsessorAugments", 100, new List<float>() { 5 });
            GreateSkillListing(ref id, "SensorAugments", 100, new List<float>() { 2 });

            InstantiateTree();
        }

        public GameObject PresetSkillPanel;
        void InstantiateTree()
        {
            List<GameObject> SkillTreeid = new List<GameObject>();
            GameObject Handler;
            foreach (string iName in NameList)
            {
                int id = NameList.IndexOf(iName);
                if (ResearchDepensiesList[id].Count >= 1)
                {
                    Handler = Instantiate(PresetSkillPanel, SkillTreeid[Mathf.FloorToInt(ResearchDepensiesList[id][0])].transform);
                }
                else
                {
                    Handler = Instantiate(PresetSkillPanel, Content.transform);
                }
                SkillTreeid.Add(Handler);
                if (ResearchDepensiesList[id].Count >= 1)
                {
                    Handler.GetComponent<SkillNode>().EshtaplishSkillNode(SkillTreeid, iName, ReseachNeedList[id], id, SkillTreeid[id - 1]);
                }
                else
                {
                    Handler.GetComponent<SkillNode>().EshtaplishSkillNode(SkillTreeid, iName, ReseachNeedList[id], id, null);
                }
                if (id == 0)
                {
                    Handler.GetComponent<SkillNode>().SetasResearchTarget();
                }
            }
        }
        void GreateSkillListing(ref int iid, string iName, float iRechearchNeeded)
        {
            NameList.Add(iName);
            ReseachNeedList.Add(iRechearchNeeded);
            ResearchDepensiesList.Add(new List<float>() { });
            iid++;
        }
        void GreateSkillListing(ref int iid, string iName, float iRechearchNeeded, float depensy)
        {
            NameList.Add(iName);
            ReseachNeedList.Add(iRechearchNeeded);
            ResearchDepensiesList.Add(new List<float>() { depensy });
            iid++;
        }
        void GreateSkillListing(ref int iid, string iName, float iRechearchNeeded, List<float> depensy)
        {
            NameList.Add(iName);
            ReseachNeedList.Add(iRechearchNeeded);
            ResearchDepensiesList.Add(depensy);
            iid++;
        }
        public bool CheakTecksForDepensies(int[] iIntList)
        {
            bool ReturnBool = true;
            SkillNode[] SkillNodeHolder = GetComponentsInChildren<SkillNode>();
            List<SkillNode> SkillNodesForTesting = new List<SkillNode>();
            foreach (int i in iIntList)
            {
                foreach (SkillNode iSkillNode in SkillNodeHolder)
                {
                    if (iSkillNode.ResearchID == i)
                    {
                        SkillNodesForTesting.Add(iSkillNode);
                    }
                }
            }
            foreach (SkillNode iSkillNode in SkillNodesForTesting)
            {
                if (!iSkillNode.CheakReshearchComplete())
                {
                    ReturnBool = false;
                }
            }
            return ReturnBool;
        }
        public void SetResearchTarget(GameObject iSkillNode)
        {
            SelectedResearchTarget = iSkillNode.GetComponent<SkillNode>();
        }
    }

}