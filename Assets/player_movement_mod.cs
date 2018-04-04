﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement_mod : MonoBehaviour {
	public int playerSpeed = 10;
	private bool facingRight = true;
	public int playerJumpPower = 125;
	private float moveX;

	
	// Update is called once per frame
	void Update () {
		PlayerMove ();
	}

	void PlayerMove () {
		moveX = Input.GetAxis ("Horizontal");
		if (moveX < 0.0f && facingRight == false) {
			flipPlayer ();
		} else if (moveX > 0.0f && facingRight == true) {
			flipPlayer ();
		}
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D> ().velocity.y); 

		if (Input.GetButtonDown ("Jump")) {
			PlayerJump ();
		}
		//direction
		//animation
		//
	}

	void PlayerJump () {
		//jump code
		gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * playerJumpPower);
	}
	void flipPlayer () {
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}


}
