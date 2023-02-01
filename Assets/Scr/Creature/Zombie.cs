using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AD1762
{
    public class Zombie : Hostile
    {
        public override float RollAttack()
        {
            return Random.Range(1, 20) + 4;
        }
        public override void CalculateArmorClass()
        {
            armorClass = 14;
        }
    } 
}
