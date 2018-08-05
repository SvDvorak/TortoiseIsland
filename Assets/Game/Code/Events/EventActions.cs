using Assets.Game.Code.Dialogue;
using Assets.Game.Code.Items;
using Assets.Game.Code.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Code.Events
{
    public class EventActions : MonoBehaviour
    {
        public ImageFade ImageFade;
        public GameObject rain;
        public Item TalkRadio;
        public Item TalkAge2;
        public Item TalkAge3;
        public Item TalkLastTortoise;
        public Text TextEnd;
        private DialogueSystem dialogueSystem;
        private GameObject rainChild;

        private GameObject player;
        private GameObject playerMesh;

        public Material MaterialAge2;
        public Material MaterialAge3;

        public Vector3 ScaleAge2;
        public Vector3 ScaleAge3;

        private int eventsDone;

        private float rainFadeout;
        private ItemSpawnController itemSpawnController;

        void Start()
        {
            itemSpawnController = GameObject.FindObjectOfType<ItemSpawnController>();
            player = GameObject.FindGameObjectWithTag("Player");
            playerMesh = GameObject.FindGameObjectWithTag("PlayerMesh");
            dialogueSystem = GameObject.FindObjectOfType<DialogueSystem>();
            TextEnd.CrossFadeAlpha(0f, 0f, true);
        }

        void Update()
        {
            if (Input.GetButtonDown("Exit"))
            {
                Application.Quit();
            }
        }

        /// <summary>
        /// These are called when all the lines of a LineTalk are used.
        /// </summary>
        public void DoEvent()
        {
            Debug.Log("eventsDone: " + eventsDone);
            switch (eventsDone)
            {
                case 0:
                    //itemSpawnController.SpawnItem(itemsSpawned);
                    break;

                case 1:
                    //Done talk turtle, spawn pants
                    itemSpawnController.SpawnItem(eventsDone);

                    break;

                case 2:
                    //Done talk pants, spawn Steering Wheel
                    itemSpawnController.SpawnItem(eventsDone);


                    //StartCoroutine(Age3());
                    break;

                case 3:
                    itemSpawnController.SpawnItem(eventsDone);
                    //Done talk T-Shirt
                    break;
                case 4:
                    StartCoroutine(Age2());
                    break;

                case 5:
                    //Age2 fade in done
                    dialogueSystem.SetLines(TalkAge2.ListLines);

                    break;
                case 6:
                    //Age2 talk done
                    itemSpawnController.SpawnItem(eventsDone);

                    break;
                case 7:
                    //Radio talk done
                    //itemSpawnController.SpawnItem(eventsDone);

                    StartCoroutine(RadioClick());
                    break;

                case 8:
                    //Radio fadein done
                    dialogueSystem.SetLines(TalkRadio.ListLines);
                    break;

                case 9:
                    //Radio after fade talk done
                    itemSpawnController.SpawnItem(eventsDone);
                    break;

                case 10:
                    //Tire talk done
                    itemSpawnController.SpawnItem(eventsDone);

                    break;

                case 11:
                    //Giraffe talk done
                    StartCoroutine(Age3());
                    break;

                case 12:
                    //Age3 fade in done
                    dialogueSystem.SetLines(TalkAge3.ListLines);
                    break;

                case 13:
                    //Age3 talk done
                    StartCoroutine(BobDies());

                    break;
                case 14:
                    //Bob is dead, say goodbye
                    dialogueSystem.SetLines(TalkLastTortoise.ListLines);
                    break;
                case 15:
                    //Goodbye said
                    StartCoroutine(EndGame());
                    break;
            }
            eventsDone++;
        }

        private void StopRain()
        {
            foreach (AudioSource audio in rainChild.GetComponents<AudioSource>())
            {
                if (audio.isPlaying)
                {
                    audio.Stop();
                    GameObject.Destroy(rainChild.gameObject);
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

            //Rain time!
            rainChild = Instantiate(rain);

            ImageFade.FadeIn(3f);
            yield return new WaitForSeconds(2.0f);
            DoEvent();
        }

        IEnumerator<WaitForSeconds> RadioClick()
        {
            Debug.Log("Radio click!");
            ImageFade.FadeOut(1f);
            yield return new WaitForSeconds(1.2f);
            StopRain();
            yield return new WaitForSeconds(1.0f);
            ImageFade.FadeIn(2f);
            yield return new WaitForSeconds(1.5f);
            DoEvent();
        }

        IEnumerator<WaitForSeconds> Age3()
        {
            Debug.Log("age 3!");
            ImageFade.FadeOut(3f);
            yield return new WaitForSeconds(3.2f);

            //Spawn new
            Renderer rend = playerMesh.GetComponent<Renderer>();
            rend.materials = new Material[]
            {
                null, null, null, MaterialAge3
            };
            player.transform.localScale = ScaleAge3;
            ImageFade.FadeIn(3f);
            yield return new WaitForSeconds(2.5f);
            DoEvent();
        }

        IEnumerator<WaitForSeconds> BobDies()
        {
            Debug.Log("RIP Bob");
            ImageFade.FadeOut(3f);
            yield return new WaitForSeconds(3.2f);
            DoEvent();
        }

        IEnumerator<WaitForSeconds> EndGame()
        {
            TextEnd.CrossFadeAlpha(1f, 2f, true);
            TextEnd.text = "For all of us who wander alone.";
            yield return new WaitForSeconds(3f);
        }
    }
}
