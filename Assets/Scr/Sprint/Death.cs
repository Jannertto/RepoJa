using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762Sprint
{

    public class Death : MonoBehaviour
    {
        private Vector2 cheakPointLocation;
        private int deaths;
        private void Start()
        {
            cheakPointLocation = transform.position;
        }
        public void ChanseCheakPointLocation(Vector2 iNewPosition)
        {
            cheakPointLocation = iNewPosition;
        }
        public void DeathOfPlayer()
        {
            transform.position = cheakPointLocation;
            deaths++;
        }
        public int ReturnDeaths()
        {
            return deaths;
        }
    }

}