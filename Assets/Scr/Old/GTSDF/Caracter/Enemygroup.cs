using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762_GTSDF
{

	public class Enemygroup
	{
		public Vector3 Location_of_group;
		public int Spotradius = 4;

		List<Enemy> Groupcomposition = new List<Enemy>();
		void SetAgro(bool NewAgro)
		{
			for (int i = 0; i < Groupcomposition.Count; i++)
			{
				Groupcomposition[i].Agrod = NewAgro;
			}
		}
	}

}