using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762_GTSDF
{

	public class ArsenalAnchor : MonoBehaviour
	{
		[SerializeField]
		GameObject[] Gearbuttons = new GameObject[9];
		[SerializeField]
		GameObject[] Weaponbuttons = new GameObject[4];
		[SerializeField]
		Combatant PlayerCombatant;

		public void Eshtaplish_Arsenal_Buttons()
		{
			for (int i = 0; i < Gearbuttons.Length; i++)
			{
				Gearbuttons[i].GetComponent<Item_Holder>().Construct_Item_Holder(PlayerCombatant.EquipedGear[i]);
				if (i < Weaponbuttons.Length)
				{
					Weaponbuttons[i].GetComponent<Item_Holder>().Construct_Item_Holder(PlayerCombatant.EquipedWeapon[i]);
				}
			}
		}
	}

}