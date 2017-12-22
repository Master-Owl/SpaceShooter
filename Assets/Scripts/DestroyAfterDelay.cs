using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour {

	public float seconds = 10;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, seconds);
	}
}
