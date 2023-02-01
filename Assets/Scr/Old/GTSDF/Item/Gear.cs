using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762_GTSDF
{

	public class Gear : Anchored_Item
	{
		//suunittele pohja joka kykenee tukemaan useampaa buffia eri osille

		//gearin statit ja modulit heijastetaan ruumin osa classiin

		// eshtaplish mod array/list and bool 2arrays/lists
		[SerializeField]
		public bool[,] ModSlots = new bool[1, 1];

		public
			Module[] ListofModules;

		Armor InstalledArmor;

		//SuitParts GearsSuitConstruct;
		public Gear(IW_Item WorldAnchhor, string iName, int ModWight, int ModHeight) : base(WorldAnchhor, iName)
		{
			ItemAnchor = WorldAnchhor;
			Name = iName;
			EshtaplishModuleBool(ModWight, ModHeight);
			ListofModules = new Module[ModWight * ModHeight];
		}
		//goes through the mod slots and finds the stat boosts and adds them
		public void BuildGearStats()
		{
			bool[,] ModslotReviev = new bool[ModSlots.GetLength(0), ModSlots.GetLength(1)];
			for (byte i = 0; i < ModSlots.GetLength(0); i++)
			{
				for (byte i2 = 0; i2 < ModSlots.GetLength(1); i2++)
				{
					if (ModSlots[i, i2])
					{
						if (!ModslotReviev[i, i2])
						{
							Module HandledModule;
							for (byte i1 = 0; i < ListofModules.Length; i1++)
							{
								if (ListofModules[i1].GetLocation()[0] == i && ListofModules[i1].GetLocation()[1] == i2)
								{
									HandledModule = ListofModules[i1];
									for (byte i21 = i; i21 < i + HandledModule.GetSize()[0]; i21++)
									{
										for (byte i22 = i2; i22 < i2 + HandledModule.GetSize()[1]; i22++)
										{
											ModslotReviev[i21, i22] = true;
										}
									}
								}
							}
						}
						Debug.Log(ModslotReviev[i, i2]);
					}
					else
					{
						Debug.Log(ModslotReviev[i, i2]);
						ModslotReviev[i, i2] = true;
					}
				}
			}
		}

		void EshtaplishModuleBool(int ModWight, int ModHeight)
		{
			ModSlots = new bool[ModWight, ModHeight];
		}
		public void InstalMod(Module iSelecterModule, byte istartHeight, byte istartWight)
		{
			bool Valid = false;
			if (ModSlots.GetUpperBound(0) >= istartWight + iSelecterModule.GetSize()[0] && ModSlots.GetUpperBound(1) >= istartHeight + iSelecterModule.GetSize()[1])
			{
				//cheks for area module is being installed in
				for (int i = istartWight; i < istartWight + iSelecterModule.GetSize()[0]; i++)
				{
					for (int i2 = istartHeight; i2 < istartHeight + iSelecterModule.GetSize()[1]; i2++)
					{
						if (ModSlots[i, i2] != false)
						{
							Valid = true;
						}
					}
				}
				//cheaks the number of installed modules
				int ModCount = 0;
				for (int i = 0; i < ListofModules.Length; i++)
				{
					if (ListofModules[i] != null)
					{
						ModCount++;
					}
				}
				//cheks for max module count
				if (ListofModules.Length >= ModCount)
				{
					Valid = true;
				}
				//if valid module gets installed
				if (Valid)
				{
					byte[] Instalationlocation = new byte[2];
					Instalationlocation[0] = istartWight;
					Instalationlocation[1] = istartHeight;
					iSelecterModule.Instalation(Instalationlocation);

					int sus = 0;
					for (int i2 = 0; i2 < ListofModules.Length; i2++)
					{
						if (ListofModules[i2] != null && ListofModules[i2].GetType() == typeof(Module))
						{
							sus++;
							Debug.Log(sus);
						}
					}
					if (sus != 0)
					{
						ListofModules[sus] = iSelecterModule;
					}
					else
					{
						Debug.Log("butting it in");
						ListofModules[0] = iSelecterModule;
					}
					for (int i = istartWight; i < istartWight + iSelecterModule.GetSize()[0] - 1; i++)
					{
						for (int i2 = istartHeight; i2 < istartHeight + iSelecterModule.GetSize()[1] - 1; i2++)
						{
							ModSlots[i, i2] = true;
						}
					}
				}
				else { Debug.Log("doesnt fit"); }
			}
			//tarkistaa onko modslot validi ja jos se on asentaa modin niihin slotteihin

		}
		public void UninstalMod(int iListLocation)
		{
			for (int i = ListofModules[iListLocation].GetLocation()[0]; i < ListofModules[iListLocation].GetLocation()[0] + ListofModules[iListLocation].GetSize()[0] - 1; i++)
			{
				for (int i2 = ListofModules[iListLocation].GetLocation()[1]; i2 < ListofModules[iListLocation].GetLocation()[1] + ListofModules[iListLocation].GetSize()[1] - 1; i2++)
				{
					ModSlots[i, i2] = false;
				}
			}
			ListofModules[iListLocation] = null;
		}
		public virtual void Gear_Constructor(int boolwith, int boolheight, int MaxModules)
		{
			ModSlots = new bool[boolwith, boolheight];
			ListofModules = new Module[MaxModules];
		}
	}

}