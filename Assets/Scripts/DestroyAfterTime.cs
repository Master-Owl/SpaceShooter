﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {

	public float seconds = 5;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, seconds);
	}
}
