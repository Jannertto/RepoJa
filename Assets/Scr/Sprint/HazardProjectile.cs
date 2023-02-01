using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762Sprint
{
    public class HazardProjectile : MonoBehaviour
    {
        private float projectileSpeed = 0.01f;
        private void FixedUpdate()
        {
            transform.localPosition = new Vector2(transform.localPosition.x - projectileSpeed, transform.localPosition.y);
        }
        public void SetStats(float iSpeed, float iShotLifetime)
        {
            projectileSpeed = iSpeed;
            Destroy(gameObject, iShotLifetime);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.GetComponent<Death>() != null)
            {
                collision.gameObject.GetComponent<Death>().DeathOfPlayer();
            }
            Destroy(gameObject);
        }
    }

}