using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762_PJ
{

    public class Room : MonoBehaviour
    {
        public List<Room> Connections = new List<Room>();
        private void Start()
        {
            List<Room> RoomList = new List<Room>();
            RoomList.AddRange(transform.parent.GetComponentsInChildren<Room>());
            foreach (Room iroom in RoomList)
            {
                if (gameObject != iroom.gameObject)
                {
                    if (Vector2.Distance(transform.position, iroom.transform.position) < 10)
                    {
                        Connections.Add(iroom);
                        Debug.Log(gameObject.name + " , " + iroom.gameObject.name);
                    }
                }
            }
        }
    }

}