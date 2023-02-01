using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762_GTSDF
{

	public class BaseEstaplisher : MonoBehaviour
	{
		Interface[] Interfaces = new Interface[6];
		GameObject InteractionMain;

		string[] ShopInteractionNames = new string[5];
		int[] ShopInteractionSelect = new int[5];

		void Start()
		{
			ShopInteractionNames[0] = "Buy";
			ShopInteractionNames[1] = "Sell";
			ShopInteractionNames[2] = "BaseUpgrades";
			ShopInteractionNames[3] = "MunitionManager";
			ShopInteractionNames[4] = "RelicManager";

			ShopInteractionSelect[0] = 0;
			ShopInteractionSelect[1] = 1;
			ShopInteractionSelect[2] = 2;
			ShopInteractionSelect[3] = 3;
			ShopInteractionSelect[4] = 4;

			//InteractionMain = GameObject.FindWithTag("BaseInterfaceMain");
			//Interfaces = InteractionMain.GetComponentsInChildren<Interface>();
			//Interfaces[0].EstaplishInterface(ShopInteractionNames, ShopInteractionSelect);
		}
	}

}