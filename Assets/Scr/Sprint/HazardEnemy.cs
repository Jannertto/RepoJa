using UnityEngine;
namespace AD1762Sprint
{

    public class HazardEnemy : MonoBehaviour
    {
        [SerializeField]
        private float movementSpeed;
        [SerializeField]
        private Rigidbody2D ownBody;
        [SerializeField]
        private SpriteRenderer ownSprite;
        private Vector2 lastLocation;
        private float turnCooldown;
        private void Start()
        {
            movementSpeed /= 100;
        }
        private void FixedUpdate()
        {
            transform.position = new Vector2(transform.position.x + movementSpeed, transform.position.y);
            if (Vector2.Distance(lastLocation, transform.position) < 0.01f && turnCooldown < 0)
            {
                movementSpeed *= -1;
                turnCooldown = 1;
                ownSprite.flipX = !ownSprite.flipX;
            }
            lastLocation = transform.position;
            turnCooldown -= Time.deltaTime;
        }
    }

}