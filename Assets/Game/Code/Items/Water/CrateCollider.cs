using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Game.Code.Items.Water
{
    public class CrateCollider : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            Debug.Log("cratecollider: " + other.name);
            if (other.tag == "Item")
            {
                Item item = other.GetComponent<Item>();
                if (item != null)
                {
                    item.GetComponent<WaterMover>().IsMoving = false;
                    item.GetComponent<WobbleWater>().IsMoving = false;
                }
            }
        }
    }
}
