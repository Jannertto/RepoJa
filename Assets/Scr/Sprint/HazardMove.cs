using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AD1762Sprint
{
    public class HazardMove : MonoBehaviour
    {
        public GameObject movingHazard;
        private float directionOfMovement = 1;
        public float speedOFHazard;
        public float distanceOfMovement;
        private void Start()
        {
            speedOFHazard /= 100;
            if (movingHazard == null)
            {
                Debug.Log("this MovingHazard doesnt have moving part: " + gameObject.name);
                gameObject.SetActive(false);
            }
        }
        private void FixedUpdate()
        {
            movingHazard.transform.position = new Vector2(movingHazard.transform.position.x + speedOFHazard * directionOfMovement, movingHazard.transform.position.y);
            if (Vector2.Distance(transform.position, movingHazard.transform.position) > distanceOfMovement)
            {
                directionOfMovement *= -1;
            }
        }
    }
}