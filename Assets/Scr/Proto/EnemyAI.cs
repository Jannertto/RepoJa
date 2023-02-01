using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762Proto
{
    public class EnemyAI : MonoBehaviour
    {
        public Transform targetTransform;
        public CircleCollider2D attackCircle;
        public float attackSpeed = 1;
        public float timeSinceLastAttack = 0;
        public float speed = 1f;
        public bool turnsRight = true;

        private float damge = 5;

        private void FixedUpdate()
        {
            //cheaks that there is a player transform to actually follow
            if (targetTransform != null)
            {
                //calls methods that point at and move towards the player
                TurnToTarget();
                MoveForward();
            }
            //adds to the cooldown of attacking
            timeSinceLastAttack += Time.deltaTime;
        }
        private void OnCollisionStay2D(Collision2D collision)
        {
            //Cheaks if Enemy has hit the player
            if (collision.transform.name == "Player")
            {
                //cheaks if cooldown on attack has ended
                if (timeSinceLastAttack > attackSpeed)
                {
                    //Attacks the player
                    //Insert attack method call here
                    collision.gameObject.GetComponent<HealthSystem>().ResieveHit(damge);
                    timeSinceLastAttack = 0;
                }
            }
            //oldway function moved to HealthSystem
            //Cheaks if the hit target is a projectile
            /*    
            else if(collision.transform.name == "Projectile")
            {
            //destroys the enemy and the projectile
            Destroy(gameObject);
            Destroy(collision.gameObject);
            }
            */
        }
        private void TurnToTarget()
        {
            //instantly turns the enemy to point at the player
            transform.right = targetTransform.position - transform.position;
        }
        private void MoveForward()
        {
            //moves towards the player at constant rate
            transform.position = Vector2.MoveTowards(transform.position, targetTransform.position, speed * Time.deltaTime);
        }
    }
}