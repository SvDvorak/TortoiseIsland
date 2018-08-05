using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TortoiseAnimationSpeed : MonoBehaviour
{
    void Start()
    {
        GetComponent<Animator>().speed = 2.5f;
    }

    void Update()
    {

    }
}
