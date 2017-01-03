﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Paddle paddle;

	private Vector3 paddleToBallVector;
	private bool hasStarted = false;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!hasStarted) {
			// Lock the ball relative to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;

			// Wait for a mouse press to launch
			if (Input.GetMouseButtonDown (0)) {
				print("Mouse clicked, launch ball");
				hasStarted = true;
				GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		Vector2 tweak = new Vector2 (Random.Range (-1f, 1f), Random.Range (0f, 0.2f));

		if (hasStarted) {
			GetComponent<Rigidbody2D>().velocity += tweak;
			Debug.Log(GetComponent<Rigidbody2D>().velocity);
			Debug.Log("Speed: " + GetComponent<Rigidbody2D>().velocity.magnitude);
			if (!(col.gameObject.tag == "Breakable")) {
				GetComponent<AudioSource> ().Play ();
			}
		}
	}
}
