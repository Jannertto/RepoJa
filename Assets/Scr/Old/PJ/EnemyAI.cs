using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762_PJ
{

    public class EnemyAI : MonoBehaviour
    {
        Sector sector;
        Vector2 PlayerReportedLocation;
        Room RoomPlayeris;
        List<Enemy> ListEnemy = new List<Enemy>();
        private void Start()
        {
            PlayerReportedLocation = transform.parent.Find("Combatant").transform.position;
            sector = transform.parent.GetComponentInChildren<Sector>();
        }
        public void OrderReguest(Enemy iEnemy)
        {
            iEnemy.ListRooms.Clear();
            sector.FindPathToPlayer(iEnemy);
        }
        public void ReportIn(Enemy iEnemy)
        {
            ListEnemy.Add(iEnemy);
            Debug.Log(iEnemy.transform.name);
        }
    }

}