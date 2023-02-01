using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762_GTSDF
{

	public class AIUniverse : MonoBehaviour
	{
		[SerializeField]
		Combatant[] CombatantArray = new Combatant[4];
		[SerializeField]
		Enemy[] EnemyArray = new Enemy[2];
		List<Enemygroup> EnemyGroupList = new List<Enemygroup>();


		public Vector3 Getlocation(int CombatantID)
		{
			Vector3 CombatantLocation = CombatantArray[CombatantID].transform.position;
			return CombatantLocation;
		}
		void Lookforspotpossipilities()
		{
			for (int i = 0; i < EnemyGroupList.Count; i++)
			{
				for (int i2 = 0; i2 < CombatantArray.Length; i2++)
					if (EnemyGroupList[i] != null && CombatantArray[i2] != null)
					{
						if (Vector3.Distance(EnemyGroupList[i].Location_of_group, CombatantArray[i2].transform.position) < EnemyGroupList[i].Spotradius)
						{

							//deside if scan happens in Enemygroups or here + add how singular enemy scan works (singular enemy as group / differesiated scan method)

							//

							//EnemyGroupList[i];
						}
					}
			}
		}
		void Lookforspotpossipilities_Enemy()
		{
			for (int i = 0; i < EnemyArray.Length; i++)
			{
				for (int i2 = 0; i2 < CombatantArray.Length; i2++)
					if (EnemyArray[i] != null && CombatantArray[i2] != null)
					{
						if (Vector3.Distance(EnemyArray[i].transform.position, CombatantArray[i2].transform.position) < EnemyArray[i].Spotradius)
						{
							EnemyArray[i].Agrod = true;
							EnemyArray[i].TargetCombatant = CombatantArray[i2];
							//deside if scan happens in Enemygroups or here + add how singular enemy scan works (singular enemy as group / differesiated scan method)

							//

							//EnemyGroupList[i];
						}
					}
			}
		}
		private void Start()
		{

		}
		private void Update()
		{
			Lookforspotpossipilities_Enemy();
		}
	}

}