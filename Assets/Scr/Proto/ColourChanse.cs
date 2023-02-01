using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762Proto
{
    public class ColourChanse : MonoBehaviour
    {
        private float colorChanse;
        public List<SpriteRenderer> colorChanseTargets;
        void Start()
        {
            ColourStart(); ;
        }
        private void ColourStart()
        {
            SpriteRenderer spriteRenderer;
            HealthSystem healthAmount = GetComponent<HealthSystem>();
            colorChanse = healthAmount.GetHealth() / healthAmount.GetHealthMax();
            Color targetColor = new Color(colorChanseTargets[0].color.r + colorChanse, colorChanseTargets[0].color.g - colorChanse / 1.2f, colorChanseTargets[0].color.b);
            foreach (var target in colorChanseTargets)
            {
                spriteRenderer = target.GetComponent<SpriteRenderer>();
                spriteRenderer.color = targetColor;
            }
        }
        public void ColourHalfHealth()
        {
            SpriteRenderer spriteRenderer;
            Color targetColor = new Color(colorChanseTargets[0].color.r - colorChanse / 4, colorChanseTargets[0].color.g - colorChanse / 4, colorChanseTargets[0].color.b - colorChanse / 4);
            foreach (var target in colorChanseTargets)
            {
                spriteRenderer = target.GetComponent<SpriteRenderer>();
                spriteRenderer.color = targetColor;
            }
        }
    }
}
