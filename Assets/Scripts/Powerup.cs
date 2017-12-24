using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

	public enum PowerupType { RapidFire, Speed, Multishot, Shield, Upgrade, Random };
	public PowerupType powerupType = PowerupType.Random;

	private SpriteRenderer spriteRenderer;
	private AudioSource audioSource;
	private string spriteDir = "Graphics/Collectables/";
	private string audioDir = "Audio/FX/";

    // Use this for initialization
    void Start () {
		if (gameObject.GetComponent<SpriteRenderer>() == null)
			gameObject.AddComponent<SpriteRenderer>();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		
		string spriteFile = spriteDir;

		switch (powerupType) {
			case PowerupType.Multishot:
				spriteFile += "gunPowerup";
				break;

			case PowerupType.Speed:
				spriteFile += "speedPowerup";
				break;

			case PowerupType.Shield:
				spriteFile += "shieldPowerup";
				break;
			
			case PowerupType.Upgrade:
				spriteFile += "upgradePowerup";
				break;
			
			case PowerupType.RapidFire:
				spriteFile += "upgradePowerup";
				break;

			default:
				spriteFile += "mysteryPowerup";
				break;
		}

		spriteRenderer.sprite = Resources.Load<Sprite>(spriteFile);

        if (powerupType == PowerupType.Random)
            powerupType = (PowerupType)Random.Range(0, System.Enum.GetValues(typeof(PowerupType)).Length - 1);

	}

	void OnTriggerEnter2D(Collider2D obj) {
		if (obj.gameObject.tag == "Player") {
			switch (powerupType) {
				case PowerupType.Multishot:
					MultishotPowerup();
					break;

				case PowerupType.Speed:
					SpeedPowerup();
					break;

				case PowerupType.Shield:
					ShieldPowerup();
					break;

				case PowerupType.Upgrade:
					UpgradePowerup();
					break;

				case PowerupType.RapidFire:
					RapidFirePowerup();
					break;
				
				default:
					break;
			}
		}
	}

	private void RapidFirePowerup() {

	}

	private void MultishotPowerup() {

	}

	private void SpeedPowerup() {

	}

	private void ShieldPowerup() {

	}

	private void UpgradePowerup() {

	}
}
