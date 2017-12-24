using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFire : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D obj) {
		if (obj.gameObject.tag == "Asteroid") {
			obj.gameObject.GetComponent<Asteroid>().Blowup();
			Destroy(gameObject);
		}
	}
}
