using Assets.Game.Code.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Game.Code.UserControl
{
    public class ItemPickup : MonoBehaviour
    {
        private Item collidedWithItem;
        private Item CurrentItem;


        void Update()
        {
            PickupItem();
        }

        public void OnTriggerEnter(Collider other)
        {
            Debug.Log("other.name: " + other.name);
            if (other.tag == "Item")
            {
                collidedWithItem = other.GetComponent<Item>();
                collidedWithItem.GetComponent<MeshRenderer>().material.color = new Color32(100, 100, 100, 100);
                Debug.Log("collidedWithItem.ItemName: " + collidedWithItem.ItemName);
            }
        }

        public void OnTriggerExit(Collider other)
        {
            Debug.Log("other.name EXIT: " + other.name);
            if (other.tag == "Item")
            {
                collidedWithItem.GetComponent<MeshRenderer>().material.color = new Color32(255, 255, 255, 255);
                collidedWithItem = null;
            }
        }

        public void PickupItem()
        {
            if (collidedWithItem != null)
            {
                if (Input.GetButtonDown("PickupItem"))
                {
                    CurrentItem = collidedWithItem;
                    Debug.Log("Picked up item!: " + CurrentItem.ItemName);
                    Destroy(CurrentItem.gameObject);
                }
            }
        }
    }
}
