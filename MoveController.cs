using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {

	private CharacterController cc;

	[SerializeField] float speed = 6.0f;  
	[SerializeField] float jumpSpeed = 8.0f;
	[SerializeField] float gravity = 20.0f;

	private Vector3 moveDirection = Vector3.zero;

	void Start () {
		cc = GetComponent<CharacterController>();
	}
	void FixedUpdate () {
		if (cc.isGrounded) {
			moveDirection = new Vector3 (Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis ("Vertical"));
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection = moveDirection * speed;
				
			if (Input.GetButton("Jump")) {
				moveDirection.y = jumpSpeed;
			}
			if (Input.GetKey (KeyCode.LeftShift)) {
				speed = 10.0f;
			} else {
				speed = 6.0f;
			}
				
		}
			
		//Wywolaj grawitacje.
		moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

		//Porusz Character Controllerem.
		cc.Move(moveDirection * Time.deltaTime);
	}
}
