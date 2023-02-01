using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762_GTSDF
{

	public class Module_armor : Module
	{
		public int Armortofnes;
		public int ArmorHealth;
		public int ThiknesCm;
		Material UsedMaterial;

		public Module_armor(string iName) : base(iName)
		{
			Name = iName;
		}
	}

}