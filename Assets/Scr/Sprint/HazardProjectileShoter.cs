using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762Sprint
{

    public class HazardProjectileShoter : MonoBehaviour
    {
        [SerializeField]
        private GameObject arrowLoaded;
        [SerializeField]
        private GameObject hazardProjectile;
        [SerializeField]
        private float shotCooldown;
        [SerializeField]
        private float shotSpeed;
        [SerializeField]
        private float shotLifeTime;
        private float timeSinceLastShot;
        private void Start()
        {
            shotSpeed /= 100;
        }
        private void Update()
        {
            if (shotCooldown < timeSinceLastShot)
            {
                ShootProjectile();
                timeSinceLastShot = 0;
                arrowLoaded.SetActive(false);
            }
            else
            {
                timeSinceLastShot += Time.deltaTime;
            }
            if (shotCooldown / 2 < timeSinceLastShot)
            {
                arrowLoaded.SetActive(true);
            }
        }
        public void ShootProjectile()
        {
            GameObject projectile = Instantiate(hazardProjectile, transform.position, transform.rotation, transform);
            projectile.GetComponent<HazardProjectile>().SetStats(shotSpeed, shotLifeTime);
        }
    }

}