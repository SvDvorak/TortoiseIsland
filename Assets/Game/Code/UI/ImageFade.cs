using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Code.UI
{
    public class ImageFade : MonoBehaviour
    {
        private Image image;
        private float cooldown = 0f;
        private float fadeTime;

        void Start()
        {
            image = GetComponent<Image>();
            FadeIn(3f);
        }

        void Update()
        {
            if (cooldown > 0)
            {
                cooldown -= Time.deltaTime;
                if (cooldown <= 0)
                {
                    FadeIn(fadeTime);
                }
            }
        }

        public void FadeOut(float fadeDuration)
        {
            fadeTime = fadeDuration;
            image.CrossFadeAlpha(1f, fadeDuration, false);
    
        }

        public void FadeIn(float fadeDuration)
        {
            fadeTime = fadeDuration;
            image.CrossFadeAlpha(0.0f, fadeDuration, false);
        }
    }
}
