using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762_GTSDF
{

	public class IW_Item : MonoBehaviour
	{
		[SerializeField]
		public Anchored_Item ItemIs;
		[SerializeField]
		GameObject Ties1;
		[SerializeField]
		GameObject Ties2;
		[SerializeField]
		GameObject Ties3;
		[SerializeField]
		GameObject Ties4;
		[SerializeField]
		int ItemID = 0;
		public Anchored_Item Eshtaplish()
		{
			if (ItemID == 0)
			{ ItemIs = new Anchored_Item(gameObject.GetComponent<IW_Item>(), "Item"); }
			if (ItemID == 1)
			{ ItemIs = new Gear(gameObject.GetComponent<IW_Item>(), "Gear", 3, 6); }
			if (ItemID == 2)
			{ ItemIs = new Weapon(gameObject.GetComponent<IW_Item>(), "Weapon", Ties1, 100); }
			Debug.Log(ItemIs);
			return ItemIs;
		}

	}

}