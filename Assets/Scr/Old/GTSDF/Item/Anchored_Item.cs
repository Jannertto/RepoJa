using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762_GTSDF
{

	public class Anchored_Item : Item
	{
		public Anchored_Item(IW_Item WorldAnchhor, string iName) : base(iName)
		{
			ItemAnchor = WorldAnchhor;
			Name = iName;
		}
		public IW_Item ItemAnchor;
	}

}