using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;

	void OnCollisionEnter2D (Collision2D collision)
	{
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		print("Collision");
		levelManager.LoadLevel("Lose");
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		print("Trigger");
		levelManager.LoadLevel("Lose");
	}
}
