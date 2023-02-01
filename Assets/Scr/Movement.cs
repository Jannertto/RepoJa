using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AD1762
{
    public class Movement : MonoBehaviour
    {
        void Update()
        {
            if(Input.anyKeyDown)
            {
                if(Input.GetKeyDown(KeyCode.W))
                {
                    transform.position = transform.position + new Vector3(1,0,0);
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    transform.position = transform.position + new Vector3(-1, 0, 0);
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    transform.position = transform.position + new Vector3(0, 0, 1);
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    transform.position = transform.position + new Vector3(0, 0, -1);
                }
                if (Input.GetKeyDown(KeyCode.J))
                {
                    transform.rotation = new Quaternion(0, transform.rotation.y + 1, 0, 0);
                }
                if (Input.GetKeyDown(KeyCode.L))
                {
                    transform.rotation = new Quaternion(0, transform.rotation.y - 1, 0, 0);
                }
            }
        }
        public void DED()
        {
            Destroy(gameObject);
        }
    }
}
