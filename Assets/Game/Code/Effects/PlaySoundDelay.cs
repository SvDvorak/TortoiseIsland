using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Game.Code.Effects
{
    public class PlaySoundDelay : MonoBehaviour
    {
        public float WaitMin = 0f;
        public float WaitMax = 1f;

        private AudioSource audioSource;

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayDelayed(Random.Range(WaitMin, WaitMax));
        }
    }
}
