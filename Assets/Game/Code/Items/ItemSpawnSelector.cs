using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Game.Code.Items
{
    public class ItemSpawnSelector : MonoBehaviour
    {
        public ItemSpawn Spawn;

        public void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                
            }
        }
    }
}
