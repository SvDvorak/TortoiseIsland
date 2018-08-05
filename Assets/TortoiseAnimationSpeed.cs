using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TortoiseAnimationSpeed : MonoBehaviour
{
    private Animator _animator;

    public void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.speed = 2.5f;
    }

    public void Update()
    {
        _animator.SetBool("IsWalking", transform.parent != null && Mathf.Abs(Input.GetAxis("Vertical")) > 0.1);
    }
}
