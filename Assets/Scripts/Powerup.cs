using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

	public enum PowerupType { RapidFire, Speed, Multishot, Shield, Upgrade, Random };
	public PowerupType powerupType = PowerupType.Random;

	private SpriteRenderer spriteRenderer;
	private AudioSource audioSource;
	private PlayerControls player;
	private const float MIN_SPEED = 1.5f;
	private const float MAX_SPEED = 6.0f;

    // Use this for initialization
    void Start () {
		if (gameObject.GetComponent<SpriteRenderer>() == null)
			gameObject.AddComponent<SpriteRenderer>();
		if (gameObject.GetComponent<AudioSource>() == null)
			gameObject.AddComponent<AudioSource>();
		if (gameObject.GetComponent<Rigidbody2D>() == null)
			gameObject.AddComponent<Rigidbody2D>();

		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		audioSource = gameObject.GetComponent<AudioSource>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>();
		
		string spriteFile = "Graphics/Collectables/";
		string audioFile = "Audio/FX/";

		switch (powerupType) {
			case PowerupType.Multishot:
				spriteFile += "gunPowerup";
				audioFile += "powerup1";
				break;

			case PowerupType.Speed:
				spriteFile += "speedPowerup";
				audioFile += "powerup2";
				break;

			case PowerupType.Shield:
				spriteFile += "shieldPowerup";
				audioFile += "powerup3";
				break;
			
			case PowerupType.Upgrade:
				spriteFile += "upgradePowerup";
				audioFile += "highBuzz"; // Temporary
				break;
			
			case PowerupType.RapidFire:
				spriteFile += "upgradePowerup";
				audioFile += "oopsie"; // Temporary
				break;

			default:
				spriteFile += "mysteryPowerup";
				audioFile += "healthPickup"; // Temporary
				break;
		}

		spriteRenderer.sprite = Resources.Load<Sprite>(spriteFile);
		audioSource.clip = Resources.Load<AudioClip>(audioFile);

        if (powerupType == PowerupType.Random)
            powerupType = (PowerupType)Random.Range(0, System.Enum.GetValues(typeof(PowerupType)).Length - 1);

		gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.down * Random.Range(MIN_SPEED, MAX_SPEED);
	}

	void OnTriggerEnter2D(Collider2D obj) {
		if (obj.gameObject.tag == "Player") {
			switch (powerupType) {
				case PowerupType.Multishot:
					Debug.Log("Multishot!");
					player.Powerup_Multishot();
					break;

				case PowerupType.Speed:
					Debug.Log("Speed!");
					player.Powerup_Speed();
					break;

				case PowerupType.Shield:
					Debug.Log("Shield!");
					player.Powerup_Shield();
					break;

				case PowerupType.Upgrade:
					Debug.Log("Upgrade!");
					break;

				case PowerupType.RapidFire:
					Debug.Log("RapidFire!");
					player.Powerup_RapidFire();
					break;
				
				default:
					break;
			}

			audioSource.Play();
			spriteRenderer.enabled = false;
			Destroy(gameObject, audioSource.clip.length);
		}
	}
}
