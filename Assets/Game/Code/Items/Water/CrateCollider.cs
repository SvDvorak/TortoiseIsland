﻿using System;
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
            //Debug.Log("cratecollider: " + other.name);
            //Debug.Log("other.tag: " + other.tag);
            if (other.tag == "Item")
            {
                Item item = other.GetComponent<Item>();
                if (item != null)
                {
                    item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                }
            }
        }
    }
}
