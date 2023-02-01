using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AD1762
{
    public class AD1762MapGenerattor : MonoBehaviour
    {
        public List<GameObject> mazeBlockLibrary;
        public int sizeX = 0;
        public int sizeZ = 0;
        private void Awake()
        {
            GenerateMap(sizeX, sizeZ);
        }

        void Update()
        {

        }
        private void GenerateMap(int iSizeX, int iSizeZ)
        {
            bool[,] locationHolder = new bool[iSizeX, iSizeZ];
            int startLocationX = iSizeX / 2;
            int startLocationZ = iSizeZ / 2;

            transform.position = new Vector3(startLocationX * 10, 0, startLocationZ * 10);
            Instantiate(mazeBlockLibrary[0], gameObject.transform.position, transform.rotation,transform);

            SpawnSection();
        }
        private void SpawnSection()
        {
            Instantiate(mazeBlockLibrary[Random.Range(0,mazeBlockLibrary.Count)], gameObject.transform.position, transform.rotation, transform);
        }
    }
}