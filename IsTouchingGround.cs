using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTouchingGround : MonoBehaviour {

	public bool isGrounded;

	// Use this for initialization
	void Start () {
		isGrounded = true;
	}
	
	// Update is called once per frame



	void onCollisionEnter(Collision other){
		if (other.gameObject.CompareTag("Player")) {
			isGrounded = false;
		}

	}
}
