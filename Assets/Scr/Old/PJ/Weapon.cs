using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762_PJ
{

    public class Weapon
    {
        public float DamageArmor = 0.1f;
        public float Damage = 25;
        float HeatMax = 100;
        float Heat;
        float HeatGen = 10;
        float HeatDGen = 5;
        public float Penetration = 1;
        public float FRate = 4f;
        public float FRange = 100;
        float MagSize = 30;
        float Inaccuracy = 1;
        float[] BaseStatArray;

        List<Parts> PartsList = new List<Parts>();

        bool Disfunctional = false;

        public Weapon(float iDA, float iD, float iHM, float iHG, float iHDG, float iP, float iFR, float iFRang, float iMS, float iIA)
        {
            DamageArmor = iDA;
            Damage = iD;
            HeatMax = iHM;
            HeatGen = iHG;
            HeatDGen = iHDG;
            Penetration = iP;
            FRate = iFR;
            FRange = iFRang;
            MagSize = iMS;
            Inaccuracy = iIA;

            BaseStatArray = new float[] { iDA, iD, iHM, iHG, iHDG, iP, iFR, iFRang, iMS, iIA };
        }

        float Timeofshots;
        public void Attack(Vector2 iShotPosition, Vector2 iShotDirection, bool iShot)
        {
            Timeofshots += FRate * Time.deltaTime;
            if (iShot)
            {
                if (Heat < HeatMax)
                {
                    if (Timeofshots > 1)
                    {
                        RaycastHit2D ShotHit = Physics2D.Raycast(iShotPosition, iShotDirection, FRange);
                        if (ShotHit.collider != null)
                        {
                            ShotHit.collider.gameObject.GetComponent<Creature>().GetHit(this);
                        }
                        Heat += HeatGen;
                        Timeofshots = 0;
                    }
                }
            }
            Heat -= HeatDGen * Time.deltaTime;
            if (Heat < 0)
            {
                Heat = 0;
            }
            else
            {
                Debug.Log(Heat);
            }
        }
        public void Assemply()
        {
            if (PartsList.Count > 0)
            {
                foreach (Parts iPart in PartsList)
                {
                    float[] iArray = iPart.GetArray();
                    for (int i = 0; i < BaseStatArray.Length; i++)
                    {
                        BaseStatArray[i] += iArray[i];
                    }
                }
            }
        }
    }

}