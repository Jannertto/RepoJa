using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
namespace AD1762_GTSDF
{

	public class InventoryManager : MonoBehaviour
	{
		[SerializeField]
		CombatantController CombatantUser;

		[SerializeField]
		GameObject Inventory_UI;
		[SerializeField]
		GameObject Inventory_UI_Container;
		[SerializeField]
		GameObject GearCraft_UI;
		[SerializeField]
		GameObject GearCraft_UI_Container;
		[SerializeField]
		GameObject Combatan_Inventory_UI;
		[SerializeField]
		GameObject Combatan_Inventory_UI_Container;
		[SerializeField]
		GameObject Combatant_Inventory_Module;
		[SerializeField]
		GameObject Combatant_Inventory_Module_Container;
		[SerializeField]
		GameObject Combatant_Arsenal;
		[SerializeField]
		GameObject Item_PreviewUI_Prefab;
		[SerializeField]
		GameObject ModSlot_Prefab;

		[SerializeField]
		ArsenalAnchor PresentArsenalAchor;
		[SerializeField]
		GameObject SelectIdentifier;

		byte[] SelectedModuleSlot = new byte[2];
		Item SelectedItem;

		Gear CraftedGear;
		Weapon CraftedWeapon;

		bool Owned;
		[SerializeField]
		Text ItemStats1;
		[SerializeField]
		Text ItemStats2;
		[SerializeField]
		Text ItemDescription;
		[SerializeField]
		Image ItemImage;

		[SerializeField]
		List<Item> Buyaples = new List<Item>();
		[SerializeField]
		List<Module> Buyaple_Modules = new List<Module>();
		Text[] DescriptionBoxes = new Text[3];


		public List<Item> Inventory_List = new List<Item>();

		[SerializeField]
		List<GameObject> BuyaplePrefabs;
		private void Start()
		{
			for (int i = 0; i < BuyaplePrefabs.Count; i++)
			{
				Buyaples.Add(BuyaplePrefabs[i].GetComponent<IW_Item>().Eshtaplish());
				if (Buyaples[i].GetType() == typeof(Gear))
				{
					Gear GearResievingMod = (Gear)Buyaples[i];
					Module InstalingModule = new Module("Test");
					GearResievingMod.InstalMod(InstalingModule, 1, 1);
				}
			}


			DescriptionBoxes = Inventory_UI.GetComponentsInChildren<Text>();

			gameObject.SetActive(false);

			Estaplish_Mods();
			Debug.Log(Buyaple_Modules.Count + Buyaple_Modules[0].Name);
		}

		void Estaplish_Mods()
		{
			Buyaple_Modules.Add(new Module("TestModule"));
			Buyaple_Modules[0].Name = "Module_01";
		}


		public void OpenShop()
		{
			DestroyHolders(Holder_List);
			ToggleOnShop();
			EshtaplishShop();
			EshtaplishInventory();
		}
		public void OpenArsenal()
		{
			DestroyHolders(Holder_List);
			ToggleOnArsenal();
			EshtaplishInventory();
		}
		public void OpenGearCrafting()
		{
			DestroyHolders(Holder_List);
			DestroyHolders(CraftingHolders);
			ToggleOnGearCraft();

			EshtaplishModuleGrid(4, GearCraft_UI_Container);

			EshtaplishInventory();
		}

		void EshtaplishShop()
		{
			UnPackListToHolders(Buyaples, Inventory_UI_Container);
			UnPackListToHolders(Buyaple_Modules, Inventory_UI_Container);
		}
		void EshtaplishInventory()
		{
			//need to mod it in such fashion that modules go to other and gear to other
			gameObject.SetActive(true);
			UnPackListToHolders(Inventory_List, Combatan_Inventory_UI_Container);
			Combatant_Inventory_Module.SetActive(true);
			UnPackListToHolders(Inventory_List, Combatant_Inventory_Module_Container);
			Combatant_Inventory_Module.SetActive(false);
		}
		public void SetGearForModing()
		{
			if (SelectedItem.GetType() == typeof(Gear))
			{
				Gear InsertGear = (Gear)SelectedItem;
				UnPackGearsModSlotsToHolders(InsertGear, GearCraft_UI_Container);
				CraftedGear = InsertGear;

				int sus = 0;
				for (int i2 = 0; i2 < InsertGear.ListofModules.Length; i2++)
				{
					if (InsertGear.ListofModules[i2] != null && InsertGear.ListofModules[i2].GetType() == typeof(Module))
					{
						sus++;
						Debug.Log(InsertGear.ListofModules[i2].Name + ", " + InsertGear.ListofModules[i2].GetLocation()[0] + " " + InsertGear.ListofModules[i2].GetLocation()[1]);
					}
				}
			}
			else
			{
				Debug.Log("Item doesnt contain Gear");
			}
		}



		List<GameObject> Holder_List = new List<GameObject>();
		void UnPackListToHolders(List<Item> InputItemList, GameObject TransformParent)
		{
			for (int i = 0; i < InputItemList.Count; i++)
			{
				GameObject Holder = Instantiate(Item_PreviewUI_Prefab, TransformParent.transform.position, new Quaternion(), TransformParent.transform);
				Holder.GetComponent<Item_Holder>().Construct_Item_Holder(InputItemList[i]);
				Holder_List.Add(Holder);
			}
		}
		void UnPackListToHolders(List<Module> InputModuleList, GameObject TransformParent)
		{
			for (int i = 0; i < InputModuleList.Count; i++)
			{
				GameObject Holder = Instantiate(Item_PreviewUI_Prefab, TransformParent.transform.position, new Quaternion(), TransformParent.transform);
				Holder.GetComponent<Item_Holder>().Construct_Item_Holder(InputModuleList[i]);
				Holder_List.Add(Holder);
			}
		}
		//holds the Crafting holders
		List<GameObject> CraftingHolders = new List<GameObject>();
		public void UnPackGearsModSlotsToHolders(Gear InputGear, GameObject TransformParent)
		{
			//resets CraftingHolders
			DestroyHolders(CraftingHolders);
			//Unpacks the gears Module slots
			//Set the container wight
			GearCraft_UI_Container.GetComponent<GridLayoutGroup>().constraintCount = InputGear.ModSlots.GetLength(0);
			//build the grid
			//Destroy TransformParent.;
			int count = 0;
			bool InstantiateCheak;
			for (byte i = 0; i < InputGear.ModSlots.GetLength(1); i++)
			{
				count++;
				for (byte i2 = 0; i2 < InputGear.ModSlots.GetLength(0); i2++)
				{
					InstantiateCheak = true;
					if (0 < InputGear.ListofModules.Length)
					{
						for (byte i3 = 0; i3 < InputGear.ListofModules.Length; i3++)
						{
							//cheaks the list of modules for modules installed on the spot
							if (InputGear.ListofModules[i3] != null)
							{
								if (InputGear.ListofModules[i3].GetLocation()[0] == i && InputGear.ListofModules[i3].GetLocation()[1] == i2)
								{
									GameObject Holder = Instantiate(ModSlot_Prefab, TransformParent.transform.position, new Quaternion(), TransformParent.transform);
									Holder.GetComponent<Item_Holder>().Construct_Item_Holder(InputGear.ListofModules[i3]);
									Holder.GetComponent<Item_Holder>().SelectModuleSlot(i, i2, gameObject.GetComponent<InventoryManager>());
									CraftingHolders.Add(Holder);
									InstantiateCheak = false;
								}
							}
						}
					}
					if (InstantiateCheak)
					{
						if (i == 1 && i2 == 1) { Debug.Log("kyll"); }
						GameObject Holder = Instantiate(ModSlot_Prefab, TransformParent.transform.position, new Quaternion(), TransformParent.transform);
						Holder.GetComponent<Item_Holder>().SelectModuleSlot(i, i2, gameObject.GetComponent<InventoryManager>());
						CraftingHolders.Add(Holder);
					}
				}
			}
		}
		void EshtaplishModuleGrid(Gear InputGear, GameObject TransformParent)
		{
			TransformParent.GetComponent<GridLayoutGroup>().constraintCount = InputGear.ModSlots.GetLength(0);
			//eshtaplish gearmodule slotgrid
			for (int i = 0; i < InputGear.ModSlots.GetLength(0); i++)
			{
				for (int i2 = 0; i2 < InputGear.ModSlots.GetLength(1); i2++)
				{
					GameObject Holder = Instantiate(Item_PreviewUI_Prefab, TransformParent.transform.position, new Quaternion(), TransformParent.transform);
					Holder.GetComponent<Item_Holder>().Construct_Item_Holder(InputGear.ModSlots[i, i2], i, i2);
					Holder_List.Add(Holder);
				}
			}
		}
		void EshtaplishModuleGrid(int input, GameObject TransformParent)
		{
			TransformParent.GetComponent<GridLayoutGroup>().constraintCount = input;
			//eshtaplish gearmodule slotgrid
			for (int i = 0; i < input; i++)
			{
				for (int i2 = 0; i2 < input; i2++)
				{
					GameObject Holder = Instantiate(Item_PreviewUI_Prefab, TransformParent.transform.position, new Quaternion(), TransformParent.transform);
					CraftingHolders.Add(Holder);
				}
			}
		}
		void DestroyHolders(List<GameObject> HolderBeingEmptiet)
		{
			for (int i = 0; i < HolderBeingEmptiet.Count; i++)
			{
				Destroy(HolderBeingEmptiet[i]);
			}
		}
		public void CloseShop()
		{
			DestroyHolders(Holder_List);
			SelectIdentifier.SetActive(false);
			gameObject.SetActive(false);
		}

		void FilterInventory(int SelectNumber)
		{
			DestroyHolders(Holder_List);
			List<Item> FilteredInventory = new List<Item>();
			List<Module> FilteredModuleInventory = new List<Module>();
			if (SelectNumber == 0)
			{
				for (int i = 0; i < Inventory_List.Count; i++)
				{ if (Inventory_List[i].GetType() == typeof(Gear)) { FilteredInventory.Add(Inventory_List[i]); } }
			}
			else if (SelectNumber == 1)
			{
				for (int i = 0; i < Inventory_List.Count; i++)
				{ if (Inventory_List[i].GetType() == typeof(Weapon)) { FilteredInventory.Add(Inventory_List[i]); } }
			}
			UnPackListToHolders(FilteredInventory, Combatan_Inventory_UI_Container);
			UnPackListToHolders(FilteredModuleInventory, Combatan_Inventory_UI_Container);
		}
		//does not support buying modules
		public void Buy_Sell_Equip()
		{
			if (SelectedItem != null)
			{
				//Buying
				if (Inventory_UI.activeSelf)
				{
					if (!Owned)
					{
						if (CombatantUser.Welth >= SelectedItem.Value)
						{
							CombatantUser.Welth += -SelectedItem.Value;
							Item TransferItem = SelectedItem;

							if (TransferItem.GetType() == typeof(Gear))
							{
								Gear TransferGear = (Gear)TransferItem;
								TransferItem = TransferGear;
							}

							Inventory_List.Add(TransferItem);
						}
						else { Debug.Log("nut enoh munee"); }
					}
					else if (Owned)
					{
						Inventory_List.Remove(SelectedItem);
						CombatantUser.Welth += SelectedItem.Value;
					}
					for (int i = 0; i < Holder_List.Count; i++)
					{
						Destroy(Holder_List[i]);
					}
					DestroyHolders(Holder_List);
					EshtaplishShop();
					EshtaplishInventory();
				}
				//Equip Gear and weapons
				else if (Combatant_Arsenal.activeSelf)
				{
					if (SelectEquipmentSlot <= 8 && SelectedItem.GetType() == typeof(Gear))
					{
						RemoveFromInventory();
						Inventory_List.Add(CombatantUser.EquipedGear[SelectEquipmentSlot]);
						CombatantUser.EquipedGear[SelectEquipmentSlot] = (Gear)SelectedItem;
						Debug.Log("Item" + SelectEquipmentSlot);
					}
					if (SelectEquipmentSlot > 8 && SelectedItem.GetType() == typeof(Weapon))
					{
						SelectEquipmentSlot -= 9;
						RemoveFromInventory();
						Inventory_List.Add(CombatantUser.EquipedWeapon[SelectEquipmentSlot]);
						CombatantUser.EquipedWeapon[SelectEquipmentSlot] = (Weapon)SelectedItem;
						Debug.Log("Item" + SelectEquipmentSlot);
					}
					Inventory_List.Remove(null);
					PresentArsenalAchor.Eshtaplish_Arsenal_Buttons();
					SelectedItem = null;
					DestroyHolders(Holder_List);
					CleanInventoryList(Inventory_List);
					UnPackListToHolders(Inventory_List, Combatan_Inventory_UI_Container);
					UnPackListToHolders(Buyaples, Inventory_UI_Container);
				}
				//Set Module into gear
				else if (GearCraft_UI.activeSelf)
				{
					bool ismultislot = false;
					if (SelectedItem.GetType() == typeof(Module) && CraftedGear != null)
					{
						for (int i = 0; i == CraftedGear.ListofModules.Length; i++)
						{
							Debug.Log(CraftedGear.ListofModules[i].Name);
						}
						Module ModulebeingInstalled = (Module)SelectedItem;
						if (ModulebeingInstalled.GetSize()[0] > 1 || ModulebeingInstalled.GetSize()[1] > 1)
						{
							Debug.Log("apparently is large");
							ismultislot = true;
						}
						//Switch the modules 
						//get the location of module being removed and instal module there
						if (CraftedGear.ListofModules.Length == 0)
						{
							Debug.Log("no se o tyhjä");
						}
						else
						{
							bool Modfound = false;
							byte[] Location = new byte[3];
							for (int i = 0; i < CraftedGear.ListofModules.Length && !Modfound; i++)
							{
								if (CraftedGear.ListofModules[i] != null)
								{
									//cheak which module inhapits same slots if any

									//for large modules
									if (ismultislot)
									{
										for (byte i2 = 1; i2 < CraftedGear.ListofModules[i].GetSize()[0]; i2++)
										{
											for (byte i3 = 1; i3 < CraftedGear.ListofModules[i].GetSize()[1]; i3++)
											{
												if (CraftedGear.ListofModules[i].GetLocation()[0] < ModulebeingInstalled.GetLocation()[0] && ModulebeingInstalled.GetLocation()[0] < CraftedGear.ListofModules[i].GetLocation()[0] + i2 && CraftedGear.ListofModules[i].GetLocation()[1] < ModulebeingInstalled.GetLocation()[1] && ModulebeingInstalled.GetLocation()[1] < CraftedGear.ListofModules[i].GetLocation()[1] + i3)
												{

												}
											}
										}
										if (CraftedGear.ListofModules[i].GetLocation()[0] == ModulebeingInstalled.GetLocation()[0])
										{
											//Inventory_List.Add(CraftedGear.ListofModules[i]);
											//Inventory_List.Remove(ModulebeingInstalled);
											//CraftedGear.ListofModules[i] = ModulebeingInstalled;
											//gearfound = true;
										}
									}
									//for small modules
									else
									{
										Debug.Log(CraftedGear.Name);

										if (CraftedGear.ListofModules[i].GetLocation()[0] == SelectedModuleSlot[0] && CraftedGear.ListofModules[i].GetLocation()[1] == SelectedModuleSlot[1])
										{

											//Inventory_List.Add(CraftedGear.ListofModules[i]);
											//Inventory_List.Remove(ModulebeingInstalled);
											CraftedGear.ListofModules[i] = ModulebeingInstalled;
											Modfound = true;
										}
									}
								}
							}

							if (Modfound)
							{
								//Uninstall Module
								CraftedGear.UninstalMod(Location[2]);

							}
							if (!Modfound && ModulebeingInstalled != null)
							{
								CraftedGear.InstalMod(ModulebeingInstalled, SelectedModuleSlot[0], SelectedModuleSlot[1]);
								Inventory_List.Remove(ModulebeingInstalled);
							}
							else
							{

							}
						}
					}
					OpenGearCrafting();
					SelectedItem = CraftedGear;
					SetGearForModing();
				}
			}
		}
		void CleanInventoryList(List<Item> InventoryInsert)
		{
			InventoryInsert.Remove(null);
		}
		void RemoveFromInventory()
		{
			Inventory_List.Remove(SelectedItem);
		}

		public void SetItemPreview(Item PrevievedItemIn)
		{
			if (PrevievedItemIn != null)
			{
				if (Inventory_List.Contains(PrevievedItemIn))
				{ Owned = true; }
				else { Owned = false; }
				SelectedItem = PrevievedItemIn;
				ItemStats1.text = PrevievedItemIn.Name;
				ItemStats2.text = PrevievedItemIn.Name;
				ItemDescription.text = PrevievedItemIn.Name;
			}
		}
		int SelectEquipmentSlot;
		public void SelectSlot(GameObject EquipmentSlot, int SelectNumber)
		{
			FilterInventory(SelectNumber);
			SelectIdentifier.SetActive(true);
			SelectIdentifier.transform.position = EquipmentSlot.transform.position;
			SelectEquipmentSlot = SelectNumber;
		}
		public void SentModSlots(byte[] InsertInt)
		{
			SelectedModuleSlot = InsertInt;
		}
		public void ToggleGameobject(GameObject InsertGameobject)
		{
			if (InsertGameobject.activeSelf)
			{
				InsertGameobject.SetActive(false);
			}
			else
			{
				InsertGameobject.SetActive(true);
			}
		}
		void ToggleOnArsenal()
		{
			PresentArsenalAchor.Eshtaplish_Arsenal_Buttons();
			ToggleOnInventoryMain();
			SetFalseInterface();
			Combatant_Arsenal.SetActive(true);
		}
		void ToggleOnShop()
		{
			ToggleOnInventoryMain();
			SetFalseInterface();
			Inventory_UI.SetActive(true);
		}
		void ToggleOnGearCraft()
		{
			ToggleOnInventoryMain();
			SetFalseInterface();
			GearCraft_UI.SetActive(true);
		}
		void SetFalseInterface()
		{
			GearCraft_UI.SetActive(false);
			Inventory_UI.SetActive(false);
			Combatant_Arsenal.SetActive(false);
		}
		void ToggleOnInventoryMain()
		{
			gameObject.SetActive(true);
			Combatan_Inventory_UI.SetActive(true);
		}

		public void INVBuildGearStats()
		{
			if (SelectedItem.GetType() == typeof(Gear))
			{
				Gear InsertGear = (Gear)SelectedItem;
				InsertGear.BuildGearStats();
			}
		}



		//will be used to craft different things like modules and weapons
		void Crafter(byte iTag, string iName, byte[] i)
		{
			Item BeingProducedItem = null;
			int Value;
			if (iTag == 0)
			{
				Module BeingProducedModule = new Module(iName);
				BeingProducedItem = BeingProducedModule;
			}
			Value = 100;
			if (CombatantUser.Welth > Value && BeingProducedItem != null)
			{
				Inventory_List.Add(BeingProducedItem);
			}
		}
	}

}