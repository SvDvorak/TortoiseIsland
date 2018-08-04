using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Game.Code.Items
{
    public class ItemSpawn : MonoBehaviour
    {
        private Item itemCurrent;

        public void SpawnItem(Item item)
        {
            itemCurrent = item;
            item.transform.position = this.transform.position;
            //item.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, item.transform.localEulerAngles.y, this.transform.localEulerAngles.z);
            itemCurrent = Instantiate(item);
            //child.transform.position = this.transform.position;
            //child.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, item.transform.localEulerAngles.y, this.transform.localEulerAngles.z);
        }
    }
}
