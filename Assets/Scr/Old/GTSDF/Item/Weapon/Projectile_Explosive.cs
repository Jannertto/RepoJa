using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762_GTSDF
{

	public class Projectile_Explosive : Projectile_Special
	{
		bool Pen_Trigger;
		bool Time_Trigger;
		bool Pre_Trigger;

		float Explosion_Radius;
		float Explosion_Damage;
		float Explosion_Damage_dropoff;
		float Shrapnel_Numper;
		float Shrapnel_Cone_Start;
		float Shrapnel_Cone;
	}

}