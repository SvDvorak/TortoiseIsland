using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStatic : MonoBehaviour {
    public GameObject Target;
    private Camera cameraFollow;
	// Use this for initialization
	void Start () {
        cameraFollow = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Target != null)
        {
            //cameraFollow
        }
	}
}
