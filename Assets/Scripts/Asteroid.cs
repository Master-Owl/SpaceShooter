using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

	public Sprite[] asteroidSprites = new Sprite[4];
	public AudioClip explosionNoise;

	private ParticleSystem explosionEffect;
	private new Rigidbody2D rigidbody;
	private const float MIN_SPEED = 1.5f;
	private const float MAX_SPEED = 6.0f;
	private bool outOfBounds = false;

	// Use this for initialization
	void Start () {
        gameObject.AddComponent<AudioSource>();
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
		renderer.sprite = asteroidSprites[Random.Range(0, asteroidSprites.Length)];
		explosionEffect = gameObject.GetComponent<ParticleSystem>();
		rigidbody = gameObject.GetComponent<Rigidbody2D>();
		rigidbody.AddTorque(2f, ForceMode2D.Impulse);
		rigidbody.velocity = new Vector2(Random.Range(-.35f, .35f), -Random.Range(MIN_SPEED, MAX_SPEED));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Blowup() {
		if (!outOfBounds) {
			gameObject.GetComponent<PolygonCollider2D>().enabled = false;
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			gameObject.GetComponent<AudioSource>().PlayOneShot(explosionNoise);
			// Instantiate(explosionEffect, gameObject.transform.position, gameObject.transform.rotation);
			explosionEffect.Play();
			Destroy(gameObject, Mathf.Max(explosionNoise.length, explosionEffect.main.duration));
		}
		else {
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D obj) {
		if (obj.gameObject.layer == 8) { // Asteroid layer
			if (obj.gameObject.GetComponent<Asteroid>() == null) // Make sure it's not an asteroid-on-asteroid collision
				outOfBounds = true;
			Blowup();
		}
	}
}
