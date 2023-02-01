using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
namespace AD1762_GTSDF
{
	public class Interface : MonoBehaviour
	{
		public string ConsoleName = "";
		string[] InteractionName = new string[5];
		int[] InteractSelect = new int[5];

		GameObject InteractMenu;
		InventoryManager InventoryManager;

		private Text[] InteractText = new Text[5];
		int[] Select = new int[5];

		public string IName1 = "";
		public string IName2 = "";
		public string IName3 = "";
		public string IName4 = "";
		public string IName5 = "";

		public int Select1 = 1;
		public int Select2 = 2;
		public int Select3 = 3;
		public int Select4 = 4;
		public int Select5 = 5;
		private void Start()
		{
			InteractMenu = GameObject.FindWithTag("LinkHolder").GetComponent<LinkHolder>().Link4;
			InventoryManager = GameObject.FindWithTag("LinkHolder").GetComponent<LinkHolder>().Link1.GetComponent<InventoryManager>();
			InteractText = InteractMenu.GetComponentsInChildren<Text>();

			InteractionName[0] = IName1;
			InteractionName[1] = IName2;
			InteractionName[2] = IName3;
			InteractionName[3] = IName4;
			InteractionName[4] = IName5;

			Select[0] = 1;
			Select[1] = 2;
			Select[2] = 3;
			Select[3] = 4;
			Select[4] = 5;
		}
		public void Eshtaplish_Inteface()
		{

		}
		public void Interaction(int InteractionInt)
		{
			if (Select[InteractionInt] == 1)
			{
				InventoryManager.OpenShop();
			}
			else if (Select[InteractionInt] == 2)
			{
				InventoryManager.OpenArsenal();
			}
			else if (Select[InteractionInt] == 3)
			{
				InventoryManager.OpenGearCrafting();
			}
			else if (Select[InteractionInt] == 4)
			{
				Debug.Log(InteractionName[3]);
			}
			else if (Select[InteractionInt] == 5)
			{
				Debug.Log(InteractionName[4]);
			}
		}
		public void SetInteractionNames()
		{
			for (int i = 0; i < InteractionName.Length; i++) { InteractText[i].text = InteractionName[i]; }
		}
	}

}