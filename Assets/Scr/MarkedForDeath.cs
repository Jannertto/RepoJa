using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AD1762
{
    public class MarkedForDeath : MonoBehaviour
    {
        [SerializeField]
        private float timeToDeath;
        [SerializeField]
        private float timeCounter;
        private void FixedUpdate()
        {
            if(timeToDeath < timeCounter)
            {
                Destroy(gameObject);
            }
            timeCounter += Time.deltaTime;
        }
    } 
}
