using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762_GTSDF
{

	public class Combatant : Creature
	{
		public int Welth;

		[SerializeField]
		protected GameObject ActiveWeapon;


		//Luo tapa eshtaplishata aseet
		public Weapon[] EquipedWeapon = new Weapon[4];
		public Gear[] EquipedGear = new Gear[9];

		public void SwitshWeapon(byte WeaponPeingEguiped)
		{
			if (EquipedWeapon[WeaponPeingEguiped] != null)
			{
				RemoveWeapon();
				ActiveWeapon = Instantiate(EquipedWeapon[WeaponPeingEguiped].ItemAnchor.gameObject, WeaponArm.transform);
				ActiveWeapon.GetComponent<IW_Item>().Eshtaplish();
			}
		}
		public void RemoveWeapon()
		{
			if (ActiveWeapon != null)
			{
				Destroy(ActiveWeapon);
			}
		}
	}

}