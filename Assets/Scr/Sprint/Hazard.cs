using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762Sprint
{

    public class Hazard : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.GetComponent<Death>() != null)
            {
                collision.gameObject.GetComponent<Death>().DeathOfPlayer();
            }
        }
    }

}