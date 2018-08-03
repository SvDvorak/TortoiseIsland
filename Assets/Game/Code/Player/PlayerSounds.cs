using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Game.Code.Player
{
    public class PlayerSounds : MonoBehaviour
    {
        private AudioSource audioSource;

        //public List<>

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayPickup()
        {

        }

    }
}
