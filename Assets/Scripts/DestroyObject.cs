using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

	public enum DestroyBy { TIME, COLLISION, EITHER };
	public DestroyBy destructionMode;
	[Tooltip("This field can be left alone if destruction type is \"COLLISION.\"")]
	public float seconds = 0f;

	// Use this for initialization
	void Start () {
		if (destructionMode == DestroyBy.TIME 
		||  destructionMode == DestroyBy.EITHER) {
			Destroy(gameObject, seconds);
		}
	}
	
	void OnCollisionEnter2D(Collision2D obj) {
		Debug.Log(gameObject.name + " collided with " + obj.gameObject.name);
		if (destructionMode == DestroyBy.COLLISION
		||  destructionMode == DestroyBy.EITHER){
            Destroy(gameObject);
        }
	}
}
