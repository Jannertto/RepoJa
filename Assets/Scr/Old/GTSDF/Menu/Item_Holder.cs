using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
namespace AD1762_GTSDF
{

	public class Item_Holder : MonoBehaviour
	{
		[SerializeField]
		public Item Held_Item;
		[SerializeField]
		Text Name_Panel;
		[SerializeField]
		Image Image_Panel;
		byte[] ModuleSlot = new byte[2];
		InventoryManager Inventory_Manager;

		bool Craftingslot = false;
		int x = 0;
		int y = 0;
		public void Construct_Item_Holder(Anchored_Item Inserted_Item)
		{
			if (Inserted_Item != null)
			{
				Held_Item = Inserted_Item;
				Name_Panel.text = Held_Item.Name;
				//Image_Panel = Held_Item.GetComponent<Item>().GetPreviewImage();
			}
			else
			{
				Held_Item = null;
				Name_Panel.text = "null";
				Image_Panel = null;
			}
		}
		public void Construct_Item_Holder(Item Inserted_Module)
		{
			if (Inserted_Module != null)
			{
				Held_Item = Inserted_Module;
				Name_Panel.text = Held_Item.Name;
				//Image_Panel = Held_Item.GetComponent<Item>().GetPreviewImage();
			}
			else
			{
				Held_Item = null;
				Name_Panel.text = "null";
				Image_Panel = null;
			}
		}
		public void Construct_Item_Holder(bool ibool, int ix, int iy)
		{
			Name_Panel.text = ibool.ToString();
			x = ix;
			y = iy;
		}
		public void InsertTOItemPreviev()
		{
			SeekManager();
			Inventory_Manager.SetItemPreview(Held_Item);
		}
		public void SelectEquipmentSlot(int SelectionNumber)
		{
			SeekManager();
			Inventory_Manager.SelectSlot(gameObject, SelectionNumber);
		}
		public void SendModuleSlotints()
		{
			Debug.Log(name);
			Inventory_Manager.SentModSlots(ModuleSlot);
		}
		public void SelectModuleSlot(byte wight, byte height, InventoryManager InsertInventoryManager)
		{
			gameObject.name = wight + " " + height;
			ModuleSlot[0] = height;
			ModuleSlot[1] = wight;
			Inventory_Manager = InsertInventoryManager;
		}
		void SeekManager()
		{
			Inventory_Manager = GameObject.FindGameObjectWithTag("Inventory_Manager").GetComponent<InventoryManager>();
		}
	}

}