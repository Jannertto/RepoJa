using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace AD1762
{
public class Button : MonoBehaviour
{
    public int buttonInt = 0;
    public TextMeshProUGUI tenTextIndicator;
    public TextMeshProUGUI buttonCountIndicator;
        public Timers timer;
    void Start()
    {

    }

    void Update()
    {
            if(buttonInt > 9)
            {
                tenTextIndicator.text = "PUSHESH 10 NOICE";
            }
            buttonCountIndicator.text = Convert.ToString(buttonInt);
    }
    public void PressDaButton()
    {
        buttonInt++;

    }
        public void ResetCounters()
        {
            timer.fixedInt = 0;
            timer.updateInt = 0;
            buttonInt = 0;
        }
}
}