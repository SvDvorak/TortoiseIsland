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
            item.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, item.transform.localEulerAngles.y, this.transform.localEulerAngles.z);
            var child = Instantiate(item);
            child.transform.position = this.transform.position;
            child.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, item.transform.localEulerAngles.y, this.transform.localEulerAngles.z);
        }

        public void ReduceRank()
        {
            Rank--;
        }
    }
}
