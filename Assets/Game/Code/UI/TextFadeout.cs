using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Code.UI
{
    public class TextFadeout : MonoBehaviour
    {
        private float cooldown = 0;
        private Text text;
        public float fadeOutDuration = 3f;
        public float FadeInDuration = 0.5f;

        void Start()
        {
            text = GetComponent<Text>();
        }

        void Update()
        {
            if (cooldown > 0f)
            {
                cooldown -= Time.deltaTime;
                if (cooldown <= 0)
                {
                    StartFadeout();
                }
            }
        }

        public void Show(float timeWait)
        {
            cooldown = timeWait;
            text.CrossFadeAlpha(1f, FadeInDuration, false);
        }

        private void StartFadeout()
        {
            text.CrossFadeAlpha(0.0f, fadeOutDuration, false);
        }
    }
}
