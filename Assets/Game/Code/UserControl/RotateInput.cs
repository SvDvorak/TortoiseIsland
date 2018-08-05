using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Assets.Game.Code.UserControl
{
    public class RotateInput : MonoBehaviour
    {
        public float movementYSpeed = 200f;
        private Rotator rotator;

        void Start()
        {
            rotator = GetComponent<Rotator>();
        }

        void Update()
        {
            UpdateMovement();
        }

        private void UpdateMovement()
        {
            float h = CrossPlatformInputManager.GetAxis("Vertical") * movementYSpeed;
            rotator.Rotate = new Vector3(0, h, 0);
        }
    }
}
