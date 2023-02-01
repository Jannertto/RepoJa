using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762_GTSDF
{

	public class Creature : MonoBehaviour
	{
		[SerializeField]
		float Health;
		[SerializeField]
		float Resistance;
		[SerializeField]
		protected GameObject WeaponArm;
		public void DamageCreature(float ResievedDamage)
		{
			Health -= ResievedDamage / Resistance;
			Debug.Log(Health);
			if (Health <= 0)
			{
				Destroy(gameObject);
			}
		}
	}

}