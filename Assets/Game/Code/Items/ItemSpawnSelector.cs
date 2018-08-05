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
        private ItemSpawnController spawnController;

        void Start()
        {
            spawnController = GameObject.FindObjectOfType<ItemSpawnController>();
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player" && Spawn != null)
            {
                spawnController.SetSpawn(Spawn);
                //spawnController.SpawnItem(1); //TEMP!
            }
        }
    }
}
