using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762_PJ
{

    public class Creature : MonoBehaviour
    {
        protected float Health = 100;
        protected float Resistance = 10;
        protected float MoveSpeed = 0.05f;

        protected GameObject WeaponHolder;

        public void GetHit(Weapon iWeapon)
        {

            Health -= iWeapon.Damage - (Resistance / iWeapon.Penetration);
            Resistance -= iWeapon.DamageArmor;
        }
        protected void Dying()
        {
            if (Health < 0)
            {
                Destroy(gameObject);
                Debug.Log(gameObject.name + " is DED");
            }
        }
        private void Update()
        {
            Dying();
        }
    }

}