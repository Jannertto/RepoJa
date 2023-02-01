using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AD1762
{
    public class ArratAndList : MonoBehaviour
    {
        
        float[] floattArray = new float[10] { 1, 5, 4, 6, 8, 2, 9, 4, 7, 1 };
        List<float> floatList = new List<float>();
        void Start()
        {
            floatList.AddRange(floattArray);
            foreach (int i in floattArray)
            {
                floatList[i] += GenerateRandomFLoat();
            }
            LogFloat();
            int listCounter = 0;
            for (int i = 0; i > 10 ; i++)
            {
                floatList[listCounter] += GenerateRandomFLoat();
            }
            listCounter = 0;
            foreach (int i in floattArray)
            {
                floattArray[listCounter] += GenerateRandomFLoat();
                listCounter++;
            }
            LogFloat();
        }
        private float GenerateRandomFLoat()
        {
            return Random.Range(-20f,20f);
        }
        private void LogFloat()
        {
            int logListCounter = 0;
            foreach (int i in floatList)
            {
                Debug.Log("LIst:" + logListCounter + " = " + i);
                logListCounter++;
            }
            logListCounter = 0;
            foreach (int i in floattArray)
            {
                Debug.Log("Array:" + logListCounter + " = " + i);
                logListCounter++;
            }
        }
    }
}