using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public float shipSpeed = 2.0f;
    [Tooltip("The max number of lasers shot per second if holding down fire button.")]
    public float fireSpeed = 2.0f;

    public Rigidbody2D laser;
    public Transform mainCanon;
    public Transform leftCanon;
    public Transform rightCanon;
    public Transform booster;

    private const float LASER_SPEED = 6.0f;
    private const float POWERUP_DURATION = 5.0f;
    private float laserTimer;
    private float horizontalModifier = 1.5f;
    private float verticalModifier = 2.25f;
	private new Rigidbody2D rigidbody;

    private float multishotPowerupTimer;

    private bool multishotPowerup = false;
    private bool shieldPowerup = false;

    // Use this for initialization
    void Start() {
		rigidbody = gameObject.GetComponent<Rigidbody2D>();
        laserTimer = 0;
        multishotPowerupTimer = 0;
        shipSpeed *= 10.0f;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButton("fire_main") && laserTimer <= 0) {
            Fire();
        }
        laserTimer -= Time.deltaTime;
        multishotPowerupTimer -= Time.deltaTime;
    }

	void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal") * horizontalModifier;
        float moveVertical = Input.GetAxis("Vertical") * verticalModifier;
        Vector2 movement = new Vector3(moveHorizontal, moveVertical);

        rigidbody.AddForce(movement * shipSpeed);
	}

    private void Fire() {
        Rigidbody2D laserFire = Instantiate(laser, mainCanon.position, mainCanon.rotation);
        laserFire.GetComponent<AudioSource>().Play();
        laserFire.velocity = Vector2.up * LASER_SPEED;
        laserTimer = 1.0f / fireSpeed;

        if (multishotPowerupTimer <= 0) multishotPowerup = false;
        if (multishotPowerup) {
            Rigidbody2D leftFire = Instantiate(laser, leftCanon.position, leftCanon.rotation);
            Rigidbody2D rightFire = Instantiate(laser, rightCanon.position, rightCanon.rotation);

            leftFire.velocity = Vector2.up * LASER_SPEED;
            rightFire.velocity = Vector2.up * LASER_SPEED;
        }
    }

    public void Powerup_Multishot() {
        multishotPowerup = true;
        multishotPowerupTimer = POWERUP_DURATION;
    }

    public void Powerup_Speed(float modifier = 2f) {
        shipSpeed *= modifier;
        StartCoroutine(ReduceSpeed(modifier, POWERUP_DURATION));
    }

    public void Powerup_RapidFire() {
        fireSpeed *= 1.5f;
    }

    public void Powerup_Shield() {
        shieldPowerup = true;
        // Add some sort of shield sprite around the ship
    }

    private IEnumerator ReduceSpeed(float modifier, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        shipSpeed /= modifier;
    }
}
