using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Game.Code.Items
{
    public class ItemSpawn : MonoBehaviour
    {
        public int Rank;
        private Item itemCurrent;


        public void SpawnItem(Item item)
        {
            Rank++;
            itemCurrent = item;
            item.transform.position = this.transform.position;
            item.transform.rotation = this.transform.rotation;
            Instantiate(item);
        }

        public void ReduceRank()
        {
            Rank--;
        }
    }
}
