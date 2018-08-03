using Assets.Game.Code.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Code.UI
{
    public class ItemUI : MonoBehaviour
    {
        private Text text;
        private TextFadeout textFadeout;
        public float DelayPerWord = 0.3f;

        void Start()
        {
            text = GetComponentInChildren<Text>();
            textFadeout = text.GetComponent<TextFadeout>();
        }

        public void ItemPickedUp(Item item)
        {
            text.text = item.ItemName;
            float time = GetTimeForString(item.ItemName);
            Debug.Log("time: " + time);
            textFadeout.Show(time);
        }

        private float GetTimeForString(string name)
        {
            float time = DelayPerWord;
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == ' ')
                {
                    time += DelayPerWord;
                }
            }
            return time;
        }
    }
}
