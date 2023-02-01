using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AD1762
{

    public class AI_World : MonoBehaviour
    {
        EnemyAI EnemyAI;
        //map if the World AI needs to eshtaplish anything on start and judge if it is better done on awaken.
        void Start()
        {

        }

        // cheaks if Enemy operators see player in their area and informs the Enemy_AI about it simplified if player isnt present comblicated if is.
        // also transfers info about gun shots and such for the Enemy_AI. Tells the Enemy_AI the chanses in the world like if some bridge the Enemy_AI tought was there has been broken.
        //
        void Update()
        {

        }
        /*
           * void Informing_The_EnemyAI(List<int> iStatesOfRoom, Furniture FurnitureInRoom)
           * { 
          *      if (CheakFurnitureState(FurnitureInRoom, ))
         *       {
        *
            *    }
            *}
            */
        bool CheakFurnitureState(Furniture iFurniture, int iState)
        {
            bool rBool = false;
            if (iFurniture.State != iState)
            {
                rBool = true;
            }
            return rBool;
        }
    }

}