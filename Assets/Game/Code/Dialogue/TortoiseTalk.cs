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
                musicLvl1.Play();
                //GameObject.Destroy(this.gameObject);
            }
        }
    }
}
