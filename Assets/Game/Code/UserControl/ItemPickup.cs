using Assets.Game.Code.Events;
using Assets.Game.Code.Items;
using Assets.Game.Code.UI;
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
        private ItemUI itemUI;

        private EventActions eventActions;

        //public 

        private int itemsPickedUp;

        void Start()
        {
            itemUI = GameObject.FindObjectOfType<ItemUI>();
            eventActions = GameObject.FindObjectOfType<EventActions>();
            
        }


        void Update()
        {
            CheckPickup();
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Item")
            {
                collidedWithItem = other.GetComponent<Item>();
                collidedWithItem.GetComponent<MeshRenderer>().material.color = new Color32(100, 100, 100, 100);
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (other.tag == "Item")
            {
                if (collidedWithItem != null)
                {
                    collidedWithItem.GetComponent<MeshRenderer>().material.color = new Color32(255, 255, 255, 255);
                    collidedWithItem = null;
                }
            }
        }

        public void CheckPickup()
        {
            if (collidedWithItem != null)
            {
                if (Input.GetButtonDown("PickupItem"))
                {
                    CurrentItem = collidedWithItem;
                    itemUI.ItemPickedUp(collidedWithItem);
                    Destroy(CurrentItem.gameObject);

                    itemsPickedUp++;
                    eventActions.DoEvent(itemsPickedUp);
                }
            }
        }
    }
}
