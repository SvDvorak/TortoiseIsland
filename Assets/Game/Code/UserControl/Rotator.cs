using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Game.Code.UserControl
{
    public class Rotator : MonoBehaviour
    {
        public Vector3 Rotate;
        public Space Space = Space.Self;

        // Update is called once per frame
        private void Update()
        {
            transform.Rotate(Rotate * Time.deltaTime, Space);
        }
    }
}
