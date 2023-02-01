using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762_GTSDF
{

	public class CraftTapleAnchor : MonoBehaviour
	{
		[SerializeField]
		GameObject FrameButtonst;
		[SerializeField]
		GameObject[] ModuleButtons = new GameObject[15];
		[SerializeField]
		Combatant PlayerCombatant;

		public void InputFrame(GameObject InbutFrame)
		{
			FrameButtonst = InbutFrame;
		}
		public void Eshtaplish_Crafting_Tapple_Buttons()
		{
			FrameButtonst.GetComponent("Gear_Frame");
			for (int i = 0; i < ModuleButtons.Length; i++)
			{
				ModuleButtons[i].GetComponent<Item_Holder>().Construct_Item_Holder(PlayerCombatant.EquipedGear[i]);
			}
		}
	}

}