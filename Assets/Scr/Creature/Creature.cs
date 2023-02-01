using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AD1762
{
    public abstract class Creature : MonoBehaviour
    {
        public float healthPoint;
        public float moveSpeed;
        public float armorClass;
        public float damage;
        public void GetHit(Creature iCreatureHiting, float iAttackRoll)
        {
            if (armorClass < iAttackRoll)
            {
                healthPoint -= iCreatureHiting.damage;
                Debug.Log("Damage taken : "+iCreatureHiting.damage+" Health left : "+healthPoint );
            }
            else
            {
                Debug.Log("Missed");
            }
        }
        public abstract void CalculateArmorClass();
        public abstract float RollAttack();
    } 
}
