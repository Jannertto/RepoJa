using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762_PJ
{

    public class Sector : MonoBehaviour
    {
        List<Room> rooms = new List<Room>();
        GameObject Combatant;
        private void Start()
        {
            rooms.AddRange(transform.parent.GetComponentsInChildren<Room>());
            Combatant = transform.parent.Find("Combatant").gameObject;
        }
        public Room FindPlayerRoom()
        {
            Room ClosestRoom = FindRoom(Combatant);
            return ClosestRoom;
        }
        public Room FindRoom(GameObject iGameobject)
        {
            float smalestDistance = Mathf.Infinity;
            Room ClosestRoom = rooms[0];
            foreach (Room room in rooms)
            {
                if (Vector2.Distance(room.transform.position, iGameobject.transform.position) < smalestDistance)
                {
                    smalestDistance = Vector2.Distance(room.transform.position, iGameobject.transform.position);
                    ClosestRoom = room;
                }
            }
            Debug.Log(ClosestRoom + " = ClosestRoom, " + iGameobject.name);
            return ClosestRoom;
        }
        public void FindPathToPlayer(Enemy iEnemy)
        {
            List<GameObject> ListTarget = new List<GameObject>();

            float smalestDistance = Mathf.Infinity;
            Room HeadingRoom = FindPlayerRoom();
            Vector2 Heading = HeadingRoom.transform.position;
            Room StartingRoom = FindRoom(iEnemy.gameObject);
            Room ClosestRoom = rooms[0];

            Debug.Log(HeadingRoom.name);

            foreach (Room iroom in StartingRoom.GetComponent<Room>().Connections)
            {
                if (Vector2.Distance(iroom.transform.position, Heading) < smalestDistance)
                {
                    ClosestRoom = iroom;
                    smalestDistance = Vector2.Distance(iroom.transform.position, Heading);
                }
            }
            Room TestedRoom = StartingRoom;
            smalestDistance = Mathf.Infinity;
            while (TestedRoom != HeadingRoom)
            {
                foreach (Room iroom in TestedRoom.GetComponent<Room>().Connections)
                {
                    if (Vector2.Distance(iroom.transform.position, HeadingRoom.transform.position) < smalestDistance)
                    {
                        ClosestRoom = iroom;
                        smalestDistance = Vector2.Distance(iroom.transform.position, Heading);
                    }
                    Debug.Log(iroom.gameObject.name);
                }
                ListTarget.Add(ClosestRoom.gameObject);
                TestedRoom = ClosestRoom;
            }
            foreach (GameObject iroom in ListTarget)
            {
                Debug.Log(iroom.transform.name);
            }
            //iEnemy.ListRooms.AddRange(ListTarget);
            //iEnemy.ListRooms.Add(Combatant);
        }
    }

}