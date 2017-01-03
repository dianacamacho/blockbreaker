using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public AudioClip drip;
	public GameObject smoke;

	private int timesHit;
	private bool isBreakable;
	private LevelManager levelManager;

	// Use this for initialization
	void Start ()
	{
		isBreakable = (this.tag == "Breakable");

		if (isBreakable) {
			breakableCount++;
		}

		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnCollisionEnter2D (Collision2D col)
	{
		if (isBreakable) {
			AudioSource.PlayClipAtPoint(drip, transform.position);
			HandleHits ();
		}
	}

	void HandleHits() {
		timesHit++;
		int maxHits = hitSprites.Length + 1;

		if (timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed();
			SmokePuff();
			Destroy (gameObject);
		} else {
			LoadSprites();
		}
	}

	void SmokePuff () {
		GameObject puff = Instantiate (smoke, transform.position, Quaternion.identity);
		puff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}

	void LoadSprites ()
	{
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites [spriteIndex];
		} else {
			Debug.LogError("Brick sprite missing");
		}
	}

	// TODO Remove this method once we can actually win
	void SimulateWin ()
	{
		levelManager.LoadNextLevel();
	}
}
