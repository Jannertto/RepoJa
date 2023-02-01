using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AD1762
{
	
	public class Timer : MonoBehaviour
	{
        private float timeCounter = 0;
        private float timeCooldown = 1;
        
        public bool Cheaktime()
        {
            bool timeHasComen = false;
            if (timeCooldown > timeCounter)
            {
                timeHasComen = true;
            }
            return timeHasComen;
        }
    }
}