using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762_GTSDF
{

	public class Projectile : MonoBehaviour
	{
		float Intecrity = 1;
		float Piersing;
		float Damage;
		float Caliber;
		float Inaccurasy;

		GameObject AlreadyHit;

		public GameObject BulletBody;

		public Rigidbody ProjectileRigidBody;

		private void Start()
		{

		}

		Vector3 lastposition;
		private void OnTriggerEnter(Collider other)
		{
			if (other.GetComponent<Armor>() != null | other.GetComponent<Creature>() != null)
			{
				if (other != AlreadyHit)
				{

				}
			}
			if (other.tag == "MapPiese")
			{ Debug.Log(other.name + " osu " + BulletBody.transform.position); }
			if (Intecrity < 0 | other.tag == "MapPiese")
			{
				Destroy(BulletBody);
			}
		}
		private void FixedUpdate()
		{
			if (gameObject.transform.position.y <= 0)
			{
				Destroy(BulletBody);
			}
			Debug.Log(Vector3.Distance(gameObject.transform.position, lastposition));
			lastposition = gameObject.transform.position;
		}
	}

}