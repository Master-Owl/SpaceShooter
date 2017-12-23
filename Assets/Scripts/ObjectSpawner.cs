using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

	public GameObject asteroidPrefab;
	public GameObject powerupPrefab;

	[Range(1, 15)]
	public int asteroidFrequency = 1;
	[Range(1, 15)]
	public int powerupFrequency = 1;

	private float asteroidTimer;
	private float powerupTimer;
	private const float ASTEROID_RATIO = 2f;
	private const float POWERUP_RATIO = 10f;

	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision(8, 12); // Ignore collision between asteroids and world boundaries
		asteroidTimer = ASTEROID_RATIO / asteroidFrequency;
		powerupTimer  = POWERUP_RATIO / powerupFrequency;
	}
	
	// Update is called once per frame
	void Update () {
		if (asteroidTimer <= 0) {
			Instantiate(asteroidPrefab);
			asteroidTimer = ASTEROID_RATIO / asteroidFrequency;
		}
		if (powerupTimer <= 0) {
			//Instantiate(powerupPrefab);
			powerupTimer = POWERUP_RATIO / powerupFrequency;
		}
		asteroidTimer -= Time.deltaTime;
		powerupTimer -= Time.deltaTime;
	}
}
