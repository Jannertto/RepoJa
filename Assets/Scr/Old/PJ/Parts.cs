using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762_PJ
{

    public class Parts
    {
        public float[] BuffArray;
        Parts(float iDA, float iD, float iHM, float iHG, float iHDG, float iP, float iFR, float iFRang, float iMS, float iIA)
        {
            BuffArray = new float[] { iDA, iD, iHM, iHG, iHDG, iP, iFR, iFRang, iMS, iIA };
        }
        public float[] GetArray()
        { return BuffArray; }
    }

}