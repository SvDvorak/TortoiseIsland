using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Game.Code.Events
{
    public class EventActions : MonoBehaviour
    {
        public GameObject rain;
        private GameObject rainChild;
        private float rainFadeout;

        void Update()
        {
            if (rainFadeout > 0)
            {
                rainFadeout -= Time.deltaTime;
                StopRain();
                if (rainFadeout <= 0)
                {
                    Destroy(rainChild.gameObject);
                }
            }
        }

        public void DoEvent(int itemsPickedUp)
        {
            switch (itemsPickedUp)
            {
                case 3:
                    rainChild = Instantiate(rain);
                    break;

                case 6:
                    rainFadeout = 8f;
                    break;
            }
        }

        private void StopRain()
        {
            foreach (AudioSource audio in rainChild.GetComponents<AudioSource>())
            {
                audio.volume -= audio.volume * Time.deltaTime;
                if (audio.volume < 0)
                    audio.volume = 0;
            }
        }
    }
}
