using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AD1762_GTSDF;

namespace MenuNamespace
{
	public class Menu : MonoBehaviour
	{
		CombatantController CombatantController;
		[SerializeField]
		InventoryManager Inventory_UI;
		[SerializeField]
		public GameObject OptionsMenuUI;
		[SerializeField]
		public GameObject EscMenuUI;
		private void Start()
		{
			CombatantController = GameObject.FindGameObjectWithTag("Combatant").GetComponent<CombatantController>();
		}
		public void ToggleEscMenu()
		{
			if (Inventory_UI.gameObject.activeSelf)
			{
				Inventory_UI.CloseShop();
				CombatantController.ToggleOnPlayer();
				Cursor.lockState = CursorLockMode.Locked;
			}
			else if (EscMenuUI.activeSelf && OptionsMenuUI.activeSelf == false)
			{
				EscMenuUI.SetActive(false);
				CombatantController.ToggleOnPlayer();
				Cursor.lockState = CursorLockMode.Locked;
			}
			else if (OptionsMenuUI.activeSelf)
			{
				OptionsMenuUI.SetActive(false);
				EscMenuUI.SetActive(true);
			}
			else
			{
				EscMenuUI.SetActive(true);
				CombatantController.ToggleOnUI();
				Cursor.lockState = CursorLockMode.Confined;
			}
		}
		public void Continue()
		{
			ToggleEscMenu();
		}
		public void Options()
		{
			EscMenuUI.SetActive(false);
			OptionsMenuUI.SetActive(true);
		}
		public void ApplicationQuit()
		{
			Application.Quit();
		}
	}
}
