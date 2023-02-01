using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762Proto
{

    public class EnemyHost : MonoBehaviour
    {
        private GameObject playerGameObject;
        public GameObject enemyPrefab;
        public int startEnemies = 1;
        void Start()
        {
            playerGameObject = transform.parent.Find("Player").gameObject;
            //finds the player and spawns an enemy to hunt it
            for (int i = 0; i < startEnemies; i++)
            {
                SpawnEnemy(new Vector2(Random.Range(10, 30), Random.Range(-10, 10)));
            }
        }
        public void SpawnEnemy()
        {
            //spawns an enemy and gives it its target(player transform)
            GameObject instantiatedEnemy = Instantiate(enemyPrefab, new Vector2(10, 0), new Quaternion(0, 0, 0, 0), transform);
            instantiatedEnemy.GetComponent<EnemyAI>().targetTransform = playerGameObject.transform;
        }
        //meant for more ellaborate spawning of enemies
        public void SpawnEnemy(Vector2 iSpawnEnemyLocation)
        {
            //spawns an enemy and gives it its target(player transform)
            GameObject instantiatedEnemy = Instantiate(enemyPrefab, iSpawnEnemyLocation, new Quaternion(0, 0, 0, 0), transform);
            instantiatedEnemy.GetComponent<EnemyAI>().targetTransform = playerGameObject.transform;
        }
    } 
}