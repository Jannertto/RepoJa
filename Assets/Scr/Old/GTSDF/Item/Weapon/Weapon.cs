using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762_GTSDF
{

	public class Weapon : Anchored_Item
	{
		Clip LoadedClip;
		[SerializeField]
		float Caliber;
		int RPS;
		double Accuracy;
		float VelocityModifier;
		[SerializeField]
		float BulletForce;
		[SerializeField]
		int EffectiveRange;
		[SerializeField]
		float Damage;

		[SerializeField]
		Projectile Bullet;

		WeaponChassis Chassis;
		[SerializeField]
		GameObject Barrel;
		public Weapon(IW_Item WorldAnchhor, string iName, GameObject iBarrel, int iEffectiveRange) : base(WorldAnchhor, iName)
		{
			ItemAnchor = WorldAnchhor;
			Barrel = iBarrel;
			EffectiveRange = iEffectiveRange;
			Name = iName;
		}

		private void Start()
		{
			Damage = BulletForce + Caliber;
		}
		public void Fire()
		{
			//if (Bullet != null)
			//{
			//	GameObject Bullet_I;
			//	Bullet_I = Instantiate(Bullet.BulletBody, Barrel.transform.position, Barrel.transform.rotation);
			//	Bullet_I.GetComponent<Rigidbody>().AddRelativeForce(0, BulletForce, 0);
			//}
			//else
			//{
			Ray Shot = new Ray(Barrel.transform.position, Barrel.transform.forward);
			RaycastHit Hit;
			if (Physics.Raycast(Barrel.transform.position, Barrel.transform.forward, out Hit, EffectiveRange, 1 << 7))
			{
				Hit.rigidbody.gameObject.GetComponent<Creature>().DamageCreature(Damage);
				Debug.Log("Ufff");
				Debug.Log(Hit.point);
			}
			if (Physics.Raycast(Barrel.transform.position, Barrel.transform.forward, out Hit, EffectiveRange, 1 << 8))
			{
				Debug.Log("Seinä");
				Debug.Log(Hit.point);
			}
			//}
		}
	}

}