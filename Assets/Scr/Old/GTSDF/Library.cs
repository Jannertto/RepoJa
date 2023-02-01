using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762_GTSDF
{

	namespace Library
	{
		public class Scanning
		{
			public void PerseptionScan(Enemy Perseptee)
			{

			}

			int Scanforspotting(Creature Spotee, Enemy Perseptee)
			{
				int Spothits = 0;
				List<Mesh> Spotapleobjects = new List<Mesh>();
				Spotapleobjects.AddRange(Spotee.transform.gameObject.GetComponents<Mesh>());
				RaycastHit Hit;
				for (int i = 0; i < Spotapleobjects.Count; i++)
				{
					if (Perseptee.Seencombatant[i])
					{
						if (Physics.Raycast(Perseptee.transform.position, Spotee.transform.position - Perseptee.transform.position, out Hit))
						{
							if (Hit.transform.gameObject == Spotee.transform.gameObject)
							{
								Spothits++;
							}
						}
					}
				}
				return Spothits;
			}
		}
	}

}