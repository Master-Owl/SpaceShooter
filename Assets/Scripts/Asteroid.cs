using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

	public Sprite[] asteroidSprites = new Sprite[4];

	// Use this for initialization
	void Start () {
		SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
		renderer.sprite = asteroidSprites[Random.Range(0, asteroidSprites.Length)];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
