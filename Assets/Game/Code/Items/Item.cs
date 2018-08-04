using Assets.Game.Code.Dialogue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Game.Code.Items
{
    public class Item : MonoBehaviour
    {
        public string ItemName;
        public List<LineTalk> ListLines;

        void Start()
        {
            OutlineEffect effect = GetComponent<OutlineEffect>();
            if (effect != null)
            {
                effect.enabled = false;
            }
        }
    }
}
