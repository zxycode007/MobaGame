using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public Transform  target;
	public Vector3    camRelativePos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 pos = target.position;
		Camera.main.transform.position = pos + camRelativePos;
		Camera.main.transform.LookAt (target);
	}
}
