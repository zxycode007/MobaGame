using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBoltHitEffect : MonoBehaviour {


	public float lifeTime = 1.0F;
	private float time = 0;
	// Use this for initialization
	void Start () {
		time = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if(time<lifeTime)
		{
			time += Time.deltaTime;
		}else{
			Destroy (gameObject);
		}
	}
}
