using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AD1762
{
    public class Spawner : MonoBehaviour
    {
        public GameObject spawnObject;
        [SerializeField]
        private float spawnTime = 0;
        [SerializeField]
        private float spawnCooldown = 1;
        void FixedUpdate()
        {
            if (spawnObject != null)
            {
                if(spawnTime > spawnCooldown)
                {
                    Instantiate(spawnObject,transform);
                    spawnTime -= spawnCooldown;
                }
            }
            spawnTime += Time.deltaTime;
        }
    } 
}
