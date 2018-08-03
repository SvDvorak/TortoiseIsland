using Assets.Game.Code.Items;
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
        private ItemSpawnController itemSpawnController;

        void Start()
        {
            itemSpawnController = GameObject.FindObjectOfType<ItemSpawnController>();
        }

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
            itemSpawnController.SpawnItem(itemsPickedUp);
            switch (itemsPickedUp)
            {
                case 3:
                    rainChild = Instantiate(rain);
                    break;

                case 5:
                    rainFadeout = 5f;
                    break;
            }
        }

        private void StopRain()
        {
            foreach (AudioSource audio in rainChild.GetComponents<AudioSource>())
            {
                if (audio.volume > 0)
                {
                    audio.volume -= 2 * Time.deltaTime;
                    Debug.Log("audio.volume: " + audio.volume);
                    if (audio.volume < 0)
                        audio.volume = 0;
                }
            }
        }
    }
}
