using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762_PJ
{

    public class SkillNode : MonoBehaviour
    {
        float Research = 0;
        public float ResearchNeeded = 0;
        public float ResearchID = 0;
        public GameObject MainDependency;
        public int[] SkillDepentency;
        public void EshtaplishSkillNode(List<GameObject> iGameobjectList, string iName, float iResearchNeeded, float researchID, GameObject iDepensies)
        {
            gameObject.name = iName;
            ResearchNeeded = iResearchNeeded;
            ResearchID = researchID;
            MainDependency = iDepensies;
        }
        public void EshtaplishSkillNode(List<GameObject> iGameobjectList, string iName, float iResearchNeeded, float researchID, GameObject iDepensies, int[] iArrayDepensies)
        {
            gameObject.name = iName;
            ResearchNeeded = iResearchNeeded;
            ResearchID = researchID;
            MainDependency = iDepensies;
            SkillDepentency = iArrayDepensies;
        }
        public bool CheakReshearchComplete()
        {
            if (Research == ResearchNeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //work on this
        public void SetasResearchTarget()
        {
            SkillTree ParentSkillTree;
            ParentSkillTree = GetComponentInParent<SkillTree>();
            bool SetTrue = false;
            if (SkillDepentency.Length != 0)
            {
                if (ParentSkillTree.CheakTecksForDepensies(SkillDepentency))
                {
                    SetTrue = true;
                }
            }
            else
            {
                if (MainDependency == null)
                {
                    SetTrue = true;
                }
                else if (MainDependency.GetComponent<SkillNode>().CheakReshearchComplete())
                {
                    SetTrue = true;
                }
            }
            if (SetTrue)
            {
                ParentSkillTree.SetResearchTarget(gameObject);
            }
        }
    }

}