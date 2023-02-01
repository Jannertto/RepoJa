using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762_GTSDF
{

	public class Module : Item
	{
		public Module(string iName) : base(iName)
		{
			Name = iName;
			Size[0] = 1;
			Size[1] = 1;
		}

		byte[] Installocation = new byte[2];
		int[] Size = new int[2];


		int Energyuse;
		public int[] GetSize()
		{
			return Size;
		}
		public void Instalation(byte[] iInstalation)
		{
			Installocation = iInstalation;
		}
		public byte[] GetLocation()
		{
			return Installocation;
		}
		public void UnInstalation()
		{
			Installocation[0] = 0;
			Installocation[1] = 0;
		}

		int Modifier;
		int ModStrenth;
		public void GetModifiers(ref int iModifier, ref int iModStrenth)
		{
			iModifier = Modifier;
			iModStrenth = ModStrenth;
		}
	}

}