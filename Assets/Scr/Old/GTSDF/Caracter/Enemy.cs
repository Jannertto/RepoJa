using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762_GTSDF
{
	public class Enemy : Creature
	{
		public bool[] Seencombatant = new bool[6];

		public bool Agrod = false;
		[SerializeField]
		public Combatant TargetCombatant;
		[SerializeField]
		Rigidbody RigidBodyOwn;

		public float Spotradius = 10;

		[SerializeField]
		Waypoint ExitPoint;
		[SerializeField]
		Waypoint EntryPoint;

		Waypoint nextWaypoint;

		[SerializeField]
		float height;
		[SerializeField]
		float Radius = 0.5f;
		[SerializeField]
		float operatinheight;
		void seek(Vector3 Target)
		{
			gameObject.transform.LookAt(new Vector3(Target.x, gameObject.transform.position.y, Target.z));
		}
		void CloseIn(Vector3 Target)
		{
			if (Vector3.Angle(new Vector3( Target.x - gameObject.transform.position.x, gameObject.transform.position.y, Target.z - gameObject.transform.position.z), gameObject.transform.forward) < 5)
			{
			if (Vector3.Distance(gameObject.transform.position, Target) > 0.1f)
			{
				RigidBodyOwn.AddRelativeForce(0, 0, 80);
			}
			}
		}
		void Attack(Combatant Target, int Range)
		{
			if (Vector3.Distance(gameObject.transform.position, Target.transform.position) < Range)
			{
				Debug.Log("laukaus");
			}
		}
		int intifonow = 0;
		void ChecpointPath(Vector3 Target)
		{
			if (Target != null)
			{
				if (Vector3.Distance(new Vector3(gameObject.transform.position.x, 0, 0), new Vector3(Target.x, 0, 0)) < 0.1f && Vector3.Distance(new Vector3(0, 0, gameObject.transform.position.z), new Vector3(0, 0, Target.z)) < 0.1f)
				{
					if (intifonow < 10)
					{
						Heading = FinalRoute[intifonow]; //ASD FIX
						intifonow++;
					}
				}
			}
			else if (Target != null)
			{

			}
		}

		private void Start()
		{
			Heading = gameObject.transform.position;
			RetroMakePath(EntryPoint.transform.position, ExitPoint.transform.position);
			//ScanObject(targetCombatant, EntryPoint.transform.position, ExitPoint.transform.position, Radius, false);
		}
		private void Update()
		{
			if (Agrod)
			{
				seek(TargetCombatant.transform.position);
				Attack(TargetCombatant, 6);
				CloseIn(TargetCombatant.transform.position);
			}
			else
			{
				if (Heading != null)
				{
					seek(Heading);
					CloseIn(Heading);
					ChecpointPath(Heading);
				}
				else
				{

				}
			}
		}
		public Vector3[] ScanObject(GameObject ScannedObject, Vector3 ScantDirection, Vector3 EndLocation, float CreatureRadius, bool Right)
		{
			Vector3[] ReturnLocation = new Vector3[3];

			Vector3 ClosestMarker = ScannedObject.transform.position;
			//selects corners

			EdgeMarkers[0] = ScannedObject.GetComponent<Collider>().ClosestPoint(ScannedObject.transform.position + new Vector3(1000, 0, 1000)) + new Vector3(CreatureRadius, 0, CreatureRadius);
			EdgeMarkers[1] = ScannedObject.GetComponent<Collider>().ClosestPoint(ScannedObject.transform.position + new Vector3(1000, 0, -1000)) + new Vector3(CreatureRadius, 0, -CreatureRadius);
			EdgeMarkers[2] = ScannedObject.GetComponent<Collider>().ClosestPoint(ScannedObject.transform.position - new Vector3(1000, 0, 1000)) - new Vector3(CreatureRadius, 0, CreatureRadius);
			EdgeMarkers[3] = ScannedObject.GetComponent<Collider>().ClosestPoint(ScannedObject.transform.position - new Vector3(1000, 0, -1000)) - new Vector3(CreatureRadius, 0, -CreatureRadius);

			if (EdgeMarkers[0].x + Radius > ScantDirection.x && ScantDirection.x > EdgeMarkers[2].x - Radius) //Cheks if Scandirection is betvene move scheck points on x axis
			{
				if (Right)
				{
					if (ScantDirection.z - ScannedObject.transform.position.z <= 0)
					{
						ReturnLocation[0] = EdgeMarkers[1];
						if (EdgeMarkers[0].x > EndLocation.x)
						{
							ReturnLocation[1] = EdgeMarkers[0];
							if (EdgeMarkers[0].z > EndLocation.z)
							{
								ReturnLocation[2] = EdgeMarkers[3];
							}
						}
					}
					else if (ScantDirection.z - ScannedObject.transform.position.z > 0)
					{
						ReturnLocation[0] = EdgeMarkers[3];
						if (EdgeMarkers[2].x < EndLocation.x)
						{
							ReturnLocation[1] = EdgeMarkers[2];
							if (EdgeMarkers[2].z < EndLocation.z)
							{
								ReturnLocation[2] = EdgeMarkers[1];
							}
						}
					}
				}
				else
				{
					if (ScantDirection.z - ScannedObject.transform.position.z <= 0)
					{
						ReturnLocation[0] = EdgeMarkers[2];
						if (EdgeMarkers[2].x < EndLocation.x)
						{
							ReturnLocation[1] = EdgeMarkers[3];
							if (EdgeMarkers[0].z > EndLocation.z)
							{
								ReturnLocation[2] = EdgeMarkers[0];
							}
						}
					}
					else if (ScantDirection.z - ScannedObject.transform.position.z > 0)
					{
						ReturnLocation[0] = EdgeMarkers[0];
						if (EdgeMarkers[0].x > EndLocation.x)
						{
							ReturnLocation[1] = EdgeMarkers[1];
							if (EdgeMarkers[2].z < EndLocation.z)
							{
								ReturnLocation[2] = EdgeMarkers[2];
							}
						}
					}
				}
			}
			else if (EdgeMarkers[0].z + Radius > ScantDirection.z && ScantDirection.z > EdgeMarkers[2].z - Radius) //Cheks if Scandirection is betvene move scheck points on z axis
			{
				if (Right)
				{
					if (ScantDirection.x - ScannedObject.transform.position.x <= 0)
					{
						ReturnLocation[0] = EdgeMarkers[2];
						if (EdgeMarkers[2].z < EndLocation.z)
						{
							ReturnLocation[1] = EdgeMarkers[1];
							if (EdgeMarkers[0].x > EndLocation.x)
							{
								ReturnLocation[2] = EdgeMarkers[0];
							}
						}
					}
					else if (ScantDirection.z - ScannedObject.transform.position.x > 0)
					{
						ReturnLocation[0] = EdgeMarkers[0];
						if (EdgeMarkers[0].z > EndLocation.z)
						{
							ReturnLocation[1] = EdgeMarkers[3];
							if (EdgeMarkers[2].x < EndLocation.x)
							{
								ReturnLocation[2] = EdgeMarkers[2];
							}
						}
					}
				}
				else
				{
					if (ScantDirection.x - ScannedObject.transform.position.x <= 0)
					{
						ReturnLocation[0] = EdgeMarkers[3];
						if (EdgeMarkers[0].z > EndLocation.z)
						{
							ReturnLocation[1] = EdgeMarkers[0];
							if (EdgeMarkers[0].x > EndLocation.x)
							{
								ReturnLocation[2] = EdgeMarkers[1];
							}
						}
					}
					else if (ScantDirection.z - ScannedObject.transform.position.x > 0)
					{
						ReturnLocation[0] = EdgeMarkers[1];
						if (EdgeMarkers[2].z < EndLocation.z)
						{
							ReturnLocation[1] = EdgeMarkers[2];
							if (EdgeMarkers[2].x < EndLocation.x)
							{
								ReturnLocation[2] = EdgeMarkers[3];
							}
						}
					}
				}
			}
			else
			{
				int i = 0;
				for (i = 0; i < EdgeMarkers.Length; i++)
				{
					if (Vector3.Distance(ScantDirection, ClosestMarker) > Vector3.Distance(ScantDirection, EdgeMarkers[i]))
					{
						ClosestMarker = EdgeMarkers[i];
					}
				}
				i = 0;
				while (EdgeMarkers[i] != ClosestMarker)
				{
					i++;
				}
				int DirectionModifier = 0;
				if (Right)
				{
					DirectionModifier = -1;
				}
				else
				{
					DirectionModifier = 1;
				}

				int modified_i = i + DirectionModifier;
				int modified_i2 = i + DirectionModifier + DirectionModifier;

				//Debug.Log(DirectionModifier + " , " + modified_i + " , " + modified_i2);

				if (modified_i < 0)
				{ modified_i = modified_i + 4; }

				else if (modified_i > 3)
				{ modified_i = modified_i - 4; }

				if (modified_i2 < 0)
				{ modified_i2 = modified_i2 + 4; }

				else if (modified_i2 > 3)
				{ modified_i2 = modified_i2 - 4; }


				ReturnLocation[0] = EdgeMarkers[modified_i];

				if (Vector3.Distance(new Vector3(EdgeMarkers[i].x, 0, 0), new Vector3(EdgeMarkers[modified_i].x, 0, 0)) > Vector3.Distance(new Vector3(EdgeMarkers[i].z, 0, 0), new Vector3(EdgeMarkers[modified_i].z, 0, 0)))
				{
					if (EdgeMarkers[0].x > EndLocation.x && EndLocation.x > EdgeMarkers[2].x - Radius)
					{
						ReturnLocation[1] = EdgeMarkers[modified_i2];
					}
				}
				else
				{
					if (EdgeMarkers[0].z > EndLocation.z && EndLocation.z > EdgeMarkers[2].z - Radius)
					{
						ReturnLocation[1] = EdgeMarkers[modified_i2];
					}
				}
			}


			return ReturnLocation;
		}

		[SerializeField]
		Vector3[] EdgeMarkers = new Vector3[4];
		[SerializeField]
		GameObject[] RouteMarkers = new GameObject[4];
		[SerializeField]
		List<Vector3> FinalRoute = new List<Vector3>();
		Vector3 Heading;

		void PatverificationRaycasting(Vector3 VectorOrigin, Vector3 EndLocation, float CreatureHeight, float CreatureWight, float OperationHeight, RaycastHit[] RaycastHitArray)
		{

		}

		int selectModifier(float Marker_Minus_Gameobject)
		{
			int Modifier = 0;
			if (Marker_Minus_Gameobject < 0) { Modifier = -1; }
			else if (Marker_Minus_Gameobject > 0) { Modifier = 1; }
			return Modifier;
		}


		int count = 0;
		void RetroMakePath(Vector3 StartPoint, Vector3 EndPoint) //luo ja valitsee reitin pisteest‰ toiseen k‰ytt‰en apuna Creaturen ominaisuuksia
		{

			//i -> 1 i2 -> 5
			//for some reason this apears whit start cordinates

			List<List<Vector3>> VectorListList = new List<List<Vector3>>();
			RaycastHit[] RaycastHitArray = new RaycastHit[4];

			//extra for loopi jotta kyet‰‰n tekem‰‰n useampia reittej‰
			int iVLL = 0; //iVectorListList
			VectorListList.Insert(iVLL, new List<Vector3>());
			iVLL++;
			//VectorListList.Insert(iVLL, new List<Vector3>());
			//iVLL++;
			RaycastHit Hit;
			for (int i = 0; i < iVLL && iVLL < 100; i++)//K‰yd‰‰n l‰pi kaikkien matkalla olevien esteiden potenttiaaliset reitit
			{
				bool Right = false;

				int i2 = 0;
				Vector3 Direction = new Vector3();

				if (i == 0) //pohjustus
				{
					VectorListList[i].Insert(i2, StartPoint);
					i2++;
					Right = true;
				}
				else // loppujen pohjustus
				{
					i2 = VectorListList[i].Count;
				}
				int Do_While = 0;
				do //Scaning loop
				{
					Do_While++;
					if (Physics.Raycast(VectorListList[i][i2 - 1], EndPoint - VectorListList[i][i2 - 1], out Hit, Vector3.Distance(VectorListList[i][i2 - 1], EndPoint), 1 << 8))
					{
						if (Right)
						{
							VectorListList.Insert(iVLL, new List<Vector3>());

							for (int i3 = 0; i3 < i2; i3++) //Cobys the path used thus far to the new list
							{ VectorListList[iVLL].Insert(i3, VectorListList[i][i3]); }
							iVLL++;
						}

						Vector3[] VectorReceiver = new Vector3[3]; //Handles returned Vector3 from scanobject
						VectorReceiver = ScanObject(Hit.transform.gameObject, VectorListList[i][i2 - 1], ExitPoint.transform.position, Radius, Right);

						VectorListList[i].Insert(i2, VectorReceiver[0]);
						i2++;
						if (VectorReceiver[1] != new Vector3(0, 0, 0))
						{
							VectorListList[i].Insert(i2, VectorReceiver[1]);
							i2++;
							if (VectorReceiver[2] != new Vector3(0, 0, 0))
							{
								VectorListList[i].Insert(i2, VectorReceiver[2]);
								i2++;
							}
						}
						Right = true;
					}
					else
					{
						VectorListList[i].Insert(i2, EndPoint);
						i2++;
					}

				} while (VectorListList[i][i2 - 1] != EndPoint && i2 < 100); //&& i2 < 10
				Direction = EndPoint - VectorListList[i][i2 - 1];
			}
			//verifie the pathing and shorten it if possiple

			List<int> Remove_Holder = new List<int>();
			for (int i = 0; i < VectorListList.Count; i++)
			{
				bool Removed = true;
				for (int i2 = 1; i2 < VectorListList[i].Count && Removed; i2++)
				{
					//Transfere later to more accurate scanning style
					if (Physics.Raycast(VectorListList[i][i2 - 1], VectorListList[i][i2] - VectorListList[i][i2 - 1], out Hit, Vector3.Distance(VectorListList[i][i2], VectorListList[i][i2 - 1]), 1 << 8))
					{
						Debug.Log("osui" + i + " kohde = " + Hit.transform.name);
						Remove_Holder.Add(i);
						Removed = false;
					}
				}
			}

			int Corection = 0;
			for (int i = 0; i < Remove_Holder.Count; i++)
			{
				VectorListList.Remove(VectorListList[Remove_Holder[i] - Corection]);
				Corection++;
			}

			//PatfindingRaycasting(gameObject.transform.position, nextWaypoint.transform.position, height, wight, operatinheight, RaycastHitArray);
			for (int i = 0; i < VectorListList.Count; i++)
			{
				for (int i2 = 0; i2 < VectorListList[i].Count; i2++)
				{
					GameObject GameobjectHolder = Instantiate(LocationMark, VectorListList[i][i2], gameObject.transform.rotation);
					GameobjectHolder.transform.name = (i + ", " + i2 + ", " + VectorListList[i][i2].ToString());
				}
			}

			int ShortestRoute = 1000;
			float ShortestLengt = 10000;
			float ProsessedLengt = 0;
			for (int i = 0; i < VectorListList.Count; i++)
			{
				ProsessedLengt = 0;
				for (int i2 = 1; i2 < VectorListList[i].Count; i2++)
				{
					ProsessedLengt = ProsessedLengt + Vector3.Distance(VectorListList[i][i2], VectorListList[i][i2 - 1]);
					//Debug.Log(Vector3.Distance(VectorListList[i][i2], VectorListList[i][i2 - 1]));
				}
				if (ProsessedLengt < ShortestLengt)
				{
					ShortestLengt = ProsessedLengt;
					ShortestRoute = i;
				}
			}
			FinalRoute.Clear();
			for (int i = 0; i < VectorListList[ShortestRoute].Count; i++)
			{
				FinalRoute.Insert(i, VectorListList[ShortestRoute][i]);
			}
		}
		[SerializeField]
		GameObject LocationMark;
	}
}