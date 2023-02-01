using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AD1762
{
    public class Furniture : MonoBehaviour
    {
        public int ID = 0;
        public int State = 0;
        public Material material;
        
        [SerializeField]
        private GameObject otherGameObject;

        private void Start()
        {
            material.color = new Color(1, 0.7f, 0.3f);
            Debug.Log(material);
        }
        private void Update()
        {
            if (State == 10)
            {
                //Debug.Log(transform.rotation);
                //transform.rotation.Set(transform.rotation.x + 1, transform.rotation.y, transform.rotation.z, transform.rotation.w);
                transform.Rotate(new Vector3(1, 0), 10);
                if (material != null)
                {

                    material.color = new Color(material.color.g, material.color.b, material.color.r);
                    Vector3 holdVector = otherGameObject.transform.position;
                    otherGameObject.transform.position = -holdVector;
                }
            }
        }
    } 
}
