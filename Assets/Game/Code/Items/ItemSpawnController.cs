using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Game.Code.Items
{
    public class ItemSpawnController : MonoBehaviour
    {
        private List<ItemSpawn> spawns;
        public List<Item> ListItems;

        void Start()
        {
            spawns = GetComponentsInChildren<ItemSpawn>().ToList();
        }

        public void SpawnItem(int itemsPickedUp)
        {
            ItemSpawn lowestSpawn;
            int lowestRank = 1337;
            foreach (var spawner in spawns)
            {
                if (spawner.Rank < lowestRank)
                {
                    lowestSpawn = spawner;
                }
                spawner.ReduceRank();
                spawner.SpawnItem(GetRandomItem(itemsPickedUp));
            }
        }

        private Item GetRandomItem(int itemsPickedUp)
        {
            return ListItems[0];
        }
    }
}
