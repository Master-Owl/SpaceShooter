using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public float shipSpeed = 20.0f;
    public GameObject bullet;
    public Transform mainCanon;
    public Transform leftCanon;
    public Transform rightCanon;
    public Transform booster;

    private float horizontalModifier = 1.5f;
    private float verticalModifier = 2.25f;
	private new Rigidbody2D rigidbody;


    // Use this for initialization
    void Start() {
		rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        // if (Input.GetButtonDown("shoot_main")) {
        //     Instantiate(bullet, mainCanon.position, mainCanon.rotation);
        // }
    }

	void FixedUpdate() {
        // Vector2 currentPosition = gameObject.transform.position;
        // float transH = Input.GetAxis("Horizontal") * horizontalModifier * shipSpeed * Time.deltaTime;
        // float transV = Input.GetAxis("Vertical") * verticalModifier * shipSpeed * Time.deltaTime;
        float moveHorizontal = Input.GetAxis("Horizontal") * horizontalModifier;
        float moveVertical = Input.GetAxis("Vertical") * verticalModifier;
        Vector2 movement = new Vector3(moveHorizontal, moveVertical);

        rigidbody.AddForce(movement * shipSpeed);
	}
}
