﻿using UnityEngine;
using System.Collections;

public class WallCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "bullet")
			Destroy (other.gameObject);

	}
}