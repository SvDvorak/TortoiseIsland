using Assets.Game.Code.Dialogue;
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
        private DialogueSystem dialogueSystem;

        private EventActions eventActions;

        //public 

        private int itemsPickedUp = 0;

        void Start()
        {
            dialogueSystem = GameObject.FindObjectOfType<DialogueSystem>();
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
                //collidedWithItem.GetComponent<MeshRenderer>().material.color = new Color32(100, 100, 100, 100);
                OutlineEffect effect = GetComponent<OutlineEffect>();
                if (effect != null)
                {
                    effect.enabled = true;
                }
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (other.tag == "Item")
            {
                if (collidedWithItem != null)
                {
                    //collidedWithItem.GetComponent<MeshRenderer>().material.color = new Color32(255, 255, 255, 255);
                    OutlineEffect effect = other.GetComponent<OutlineEffect>();
                    if (effect != null)
                    {
                        effect.enabled = false;
                    }
                    collidedWithItem = null;
                }
            }
        }

        public void CheckPickup()
        {
            //This happens now?!?!?!?! TWICE!?!?!
            if (collidedWithItem != null)
            {
                if (Input.GetButtonDown("PickupItem"))
                {
                    CurrentItem = collidedWithItem;
                    dialogueSystem.SetLines(collidedWithItem.ListLines);
                    Destroy(collidedWithItem.gameObject);
                    itemsPickedUp++;
                    eventActions.DoEvent(itemsPickedUp);
                }
            }
        }
    }
}
