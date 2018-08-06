using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Game.Code.Dialogue
{
    public class TortoiseTalk : MonoBehaviour
    {
        private DialogueSystem dialogueSystem;
        public List<LineTalk> lineTalks;
        public GameObject tortoise;
        public GameObject Rotator;
        public AudioSource musicLvl1;
        public AudioSource waves;

        private bool isCollided = false;
        void Start()
        {
            dialogueSystem = GameObject.FindObjectOfType<DialogueSystem>();
        }

        void OnTriggerEnter(Collider other)
        {
            if (!isCollided && other.tag == "Player")
            {
                isCollided = true;
                tortoise.transform.parent = Rotator.transform;
                dialogueSystem.SetLines(lineTalks);
                StartCoroutine(PlayMusic());
                //GameObject.Destroy(this.gameObject);
            }
        }

        IEnumerator<WaitForSecondsRealtime> PlayMusic()
        {
            musicLvl1.Play();
            //Song first pling is at 25.30 seconds
            yield return new WaitForSecondsRealtime(25.3f);
            waves.Stop();
        }
    }
}
