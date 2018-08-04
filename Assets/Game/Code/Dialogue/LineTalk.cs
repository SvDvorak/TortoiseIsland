using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Game.Code.Dialogue
{
    //[CreateAssetMenu(fileName = "Line", menuName = "Dialog/Create Line")]
    [Serializable]
    public class LineTalk
    {
        [TextArea]
        public string Line;

        public Speaker Speaker;

        public float DelayAfter = 0.5f;
    }
}
