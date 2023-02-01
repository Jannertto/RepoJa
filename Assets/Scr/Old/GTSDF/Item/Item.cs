using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
namespace AD1762_GTSDF
{

	public class Item
	{
		public string Name;
		public byte Tag;

		public float Weight;

		public int Value;
		Image Preview_Image;
		public Item(string iName)
		{
			Name = iName;
		}
		public Image GetPreviewImage()
		{
			return Preview_Image;
		}
	}

}