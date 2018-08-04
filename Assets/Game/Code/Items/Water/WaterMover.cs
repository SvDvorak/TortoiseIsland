using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Game.Code.Items.Water
{
    public class WaterMover : MonoBehaviour
    {
        public float SpeedForward = 0.4f;
        public bool IsMoving = true;

        void Update()
        {
            if (IsMoving)
            {
                //transform.Translate(0, 0 , -SpeedForward * Time.deltaTime, Space.World);
                transform.Translate(Vector3.forward * SpeedForward * Time.deltaTime);
            }
        }
    }
}
