using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SimpleAnimation : MonoBehaviour {

	public float timeInterval = 1f;
	public float delayStart = 0f;

	[Header("Movement")]
	public bool useMovement = false;
	public Vector2 pointA;
	public Vector2 pointB;

    [Header("Rotation")]
	public bool useRotation = false;
    public Vector3 startRotation;
    public Vector3 endRotation;

	[Header("Fade")]
	public bool fadeOut = false;
	public bool fadeIn  = false;

	private SpriteRenderer spriteRenderer;
	private bool runAnimation = false;
	private float timer = 0;
	private float ROC; // Rate Of Change

	// Use this for initialization
	void Awake() {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		timeInterval = Mathf.Abs(timeInterval);
		delayStart = Mathf.Abs(delayStart);
        ROC = Time.deltaTime / timeInterval;

        if (fadeOut && fadeIn) {
            fadeIn = false;
        }
		if (useMovement) {
			gameObject.transform.position = pointA;
		}
		if (useRotation) {
			gameObject.transform.rotation = Quaternion.Euler(startRotation);
		}
		if (fadeIn) {
			Color c = spriteRenderer.color;
			spriteRenderer.color = new Color(c.r, c.g, c.b, 0);
		}
	}

	// Update is called once per frame
	void Update() {
		if (delayStart > 0) {
			delayStart -= Time.deltaTime;
		}
		else if (delayStart <= 0 && timer < timeInterval) {
			runAnimation = true;
		}
		
		if (runAnimation) {
			timer += ROC;

			if (fadeOut || fadeIn)
				Fade();

			if (useMovement)
				Move();

			if (useRotation)
				Rotate();
			
			if (timer >= timeInterval)
				runAnimation = false;
		}
	}

	private void Fade() {
		Color c = spriteRenderer.color;
		float alpha = spriteRenderer.color.a;
		if (fadeIn) {
            alpha += ROC;
        }
		else if (fadeOut) {
            alpha -= ROC;
        }
		spriteRenderer.color = new Color(c.r, c.g, c.b, alpha);
	}

	private void Move() {
		Vector2 curPos = gameObject.transform.position;
		float x = curPos.x + (pointB.x - pointA.x) * ROC;
		float y = curPos.y + (pointB.y - pointA.y) * ROC;
		gameObject.transform.position = new Vector2(x, y);
	}

	private void Rotate() {
		Vector3 curRot = gameObject.transform.rotation.eulerAngles;
		float x = curRot.x + (endRotation.x - startRotation.x) * ROC;
		float y = curRot.y + (endRotation.y - startRotation.y) * ROC;
		float z = curRot.z + (endRotation.z - startRotation.z) * ROC;
		gameObject.transform.rotation = Quaternion.Euler(x, y, z);
    }
}
