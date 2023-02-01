using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace AD1762
{
    public class Timers : MonoBehaviour
    {
        public int updateInt = 0;
        public int fixedInt = 0;
        public TextMeshProUGUI fixedCounter;
        public TextMeshProUGUI updateCounter;
        private void Update()
        {
        updateInt++;
            fixedCounter.text = "Fixed count = " + Convert.ToString(fixedInt);
            updateCounter.text = "Update count = " + Convert.ToString(updateInt);
        }
        private void FixedUpdate()
        {
            fixedInt++;
        }
    }
}