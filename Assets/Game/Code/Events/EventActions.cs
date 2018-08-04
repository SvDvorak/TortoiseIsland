using Assets.Game.Code.Items;
using Assets.Game.Code.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Game.Code.Events
{
    public class EventActions : MonoBehaviour
    {
        public ImageFade ImageFade;
        public GameObject rain;
        private GameObject rainChild;

        private GameObject player;
        private GameObject playerMesh;

        public Material MaterialAge2;
        public Material MaterialAge3;

        public Vector3 ScaleAge2;
        public Vector3 ScaleAge3;

        public AudioSource musicLvl1;

        private float rainFadeout;
        private ItemSpawnController itemSpawnController;

        void Start()
        {
            itemSpawnController = GameObject.FindObjectOfType<ItemSpawnController>();
            player = GameObject.FindGameObjectWithTag("Player");
            playerMesh = GameObject.FindGameObjectWithTag("PlayerMesh");
        }

        void Update()
        {

            if (rainFadeout > 0)
            {
                rainFadeout -= Time.deltaTime;
                StopRain();
                if (rainFadeout <= 0)
                {
                    Debug.Log("STOP RAINING!");
                    ImageFade.FadeIn(3f);
                    foreach (AudioSource audio in rainChild.GetComponents<AudioSource>())
                    {
                        audio.Stop();
                    }
                    GameObject.Destroy(rainChild.gameObject);
                }
            }
        }

        public void DoEvent(int itemsPickedUp)
        {
            itemSpawnController.SpawnItem(itemsPickedUp);
            switch (itemsPickedUp)
            {
                case 1:
                    musicLvl1.Play();
                    break;

                case 2:
                    StartCoroutine(Age2());
                    break;

                case 3:
                    StartCoroutine(Age3());
                    break;
                case 5:
                    rainFadeout = 5f;
                    ImageFade.FadeOut(1f);
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
                    //Debug.Log("audio.volume: " + audio.volume);
                    if (audio.volume < 0)
                        audio.volume = 0;
                }
            }
        }

        IEnumerator<WaitForSeconds> Age2()
        {
            Debug.Log("age 2!");
            ImageFade.FadeOut(3f);
            yield return new WaitForSeconds(3.2f);

            //Spawn new
            Renderer rend = playerMesh.GetComponent<Renderer>();
            rend.materials = new Material[]
            {
                null, null, null, MaterialAge2
            };
            
            player.transform.localScale = ScaleAge2;

            ImageFade.FadeIn(3f);
        }

        IEnumerator<WaitForSeconds> Age3()
        {
            Debug.Log("age 2!");
            ImageFade.FadeOut(3f);
            yield return new WaitForSeconds(3.2f);

            //Spawn new
            Renderer rend = playerMesh.GetComponent<Renderer>();
            rend.materials = new Material[]
            {
                null, null, null, MaterialAge3
            };

            player.transform.localScale = ScaleAge2;
            rainChild = Instantiate(rain);
            ImageFade.FadeIn(3f);
        }
    }
}
