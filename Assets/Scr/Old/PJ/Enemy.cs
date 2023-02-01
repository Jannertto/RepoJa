using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762_PJ
{

    public class Enemy : Creature
    {
        Weapon MeleeWeapon;

        public List<GameObject> ListRooms = new List<GameObject>();
        GameObject Target;
        GameObject Player;

        byte TypeTag = 0;
        private void Start()
        {
            //MeleeWeapon = new Weapon();
            MeleeWeapon.FRate = 2;
            MeleeWeapon.FRange = 1.5f;
            Player = gameObject.transform.parent.transform.parent.gameObject.transform.Find("Combatant").gameObject;
            WeaponHolder = gameObject.transform.Find("WeaponHolder").gameObject;
            transform.parent.GetComponent<EnemyAI>().ReportIn(gameObject.GetComponent<Enemy>());
        }
        float Timeoftargeting = 0;
        private void Update()
        {
            Dying();
            Timeoftargeting += Time.deltaTime;

            if (Target != Player)
            {
                if (Target != null)
                {
                    Debug.Log(Target.name);
                    if (Vector2.Distance(transform.position, Target.transform.position) < 1.5f)
                    {
                        Target = null;
                        Timeoftargeting = 0;
                        TakeNextTarget();
                    }
                }
                else if (Timeoftargeting > 10 || Target == null)
                {
                    Seekroute();
                }
            }
            if (TypeTag == 0)
            {
                if (Target != null)
                {
                    BasicAI();
                }
            }
        }
        float Timeofshots = 0;
        void BasicAI()
        {
            gameObject.transform.up = Target.transform.position - gameObject.transform.position;
            Timeofshots += MeleeWeapon.FRate * Time.deltaTime;
            if (Vector2.Distance(transform.position, Target.transform.position) > 1.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, MoveSpeed);
            }
            else
            {
                Attack();
            }
        }
        void Seekroute()
        {
            if (Target != null)
            {
                if (Target != Player)
                {

                }
                else
                {
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, Target.transform.position, Vector2.Distance(transform.position, Target.transform.position), 6);
                    if (hit.collider != null)
                    {
                        hit.collider.ClosestPoint(transform.position);

                    }
                }
            }
            else
            {
                GetTarget();
            }
        }
        void TakeNextTarget()
        {
            ListRooms.Remove(Target.GetComponent<GameObject>());
        }
        void GetTarget()
        {
            // transfer to Enemy AI at later point so it will command the enemy whia giving it targets == Movement orders, enemies and objectives like destroy, capture or repair
            transform.parent.GetComponent<EnemyAI>().OrderReguest(gameObject.GetComponent<Enemy>());
            Target = ListRooms[0].gameObject;
        }
        void Attack()
        {
            if (Timeofshots > 1)
            {
                RaycastHit2D ShotHit = Physics2D.Raycast(WeaponHolder.transform.position, WeaponHolder.transform.up, MeleeWeapon.FRange + 1);
                if (ShotHit.collider != null)
                {
                    ShotHit.collider.gameObject.GetComponent<Creature>().GetHit(MeleeWeapon);
                }
                Timeofshots = 0;
            }
        }
    }

}