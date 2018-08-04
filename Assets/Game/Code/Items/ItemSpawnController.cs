using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Game.Code.Items
{
    public class ItemSpawnController : MonoBehaviour
    {
        public List<Item> ListItems;
        public ItemSpawn currentSpawn;

        public void SetSpawn(ItemSpawn spawn)
        {
            currentSpawn = spawn;
        }

        public void SpawnItem(int itemsPickedUp)
        {
            currentSpawn.SpawnItem(ListItems[itemsPickedUp]);
        }
    }
}
