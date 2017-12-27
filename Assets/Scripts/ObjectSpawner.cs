using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

	public GameObject asteroidPrefab;
	public GameObject powerupPrefab;

	[Range(1, 15)]
	public int asteroidFrequency = 1;
	[Tooltip("How often should powerups spawn?")]
	[Range(1, 15)]
	public int powerupFrequency = 1;
	[Tooltip("How frequently should the shield powerup occur?")]
	[Range(0, 100)]
	public int shieldPowerupFrequency = 25;
    [Tooltip("How frequently should the multishot powerup occur?")]
    [Range(0, 100)]
    public int multishotPowerupFrequency = 25;
    [Tooltip("How frequently should the speed powerup occur?")]
    [Range(0, 100)]
    public int speedPowerupFrequency = 25;
    [Tooltip("How frequently should the rapidfire powerup occur?")]
    [Range(0, 100)]
    public int rapidfirePowerupFrequency = 25;
    [Tooltip("How frequently should the upgrade powerup occur?")]
    [Range(0, 100)]
    public int upgradePowerupFrequency = 25;
    [Tooltip("How frequently should a random powerup occur?")]
    [Range(0, 100)]
    public int randomPowerupFrequency = 25;

	private float asteroidTimer;
	private float powerupTimer;
	private const float ASTEROID_RATIO = 3f;
	private const float POWERUP_RATIO = 10f;
	private const float SPAWN_POINT_Y = 6.25f;
	private const float SPAWN_MAx_X = 6f;

	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision(8, 12); // Ignore collision between asteroids and world boundaries
		Physics2D.IgnoreLayerCollision(10, 11); // Ignore collision between laser and player
		Physics2D.IgnoreLayerCollision(9, 11); // Ignore collision between powerups and laser
		asteroidTimer = ASTEROID_RATIO / asteroidFrequency;
		powerupTimer  = POWERUP_RATIO / powerupFrequency;
	}
	
	// Update is called once per frame
	void Update () {
		if (asteroidTimer <= 0) {
			Instantiate(asteroidPrefab, 
				new Vector2(Random.Range(-SPAWN_MAx_X, SPAWN_MAx_X), SPAWN_POINT_Y), 
				Quaternion.identity);
			asteroidTimer = ASTEROID_RATIO / asteroidFrequency;
		}
		if (powerupTimer <= 0) {
			int maxValue = 
				shieldPowerupFrequency + multishotPowerupFrequency +
                speedPowerupFrequency + rapidfirePowerupFrequency +
				upgradePowerupFrequency + randomPowerupFrequency;
			int randomValue = Random.Range(0, maxValue);
			Powerup powerup = powerupPrefab.GetComponent<Powerup>();

			if (randomValue <= shieldPowerupFrequency)
				powerup.powerupType = Powerup.PowerupType.Shield;
			else if (randomValue <= shieldPowerupFrequency + multishotPowerupFrequency)
				powerup.powerupType = Powerup.PowerupType.Multishot;
			else if (randomValue <= shieldPowerupFrequency + multishotPowerupFrequency + speedPowerupFrequency)
                powerup.powerupType = Powerup.PowerupType.Speed;
			else if (randomValue <= shieldPowerupFrequency + multishotPowerupFrequency + speedPowerupFrequency + rapidfirePowerupFrequency)
                powerup.powerupType = Powerup.PowerupType.RapidFire;
            else if (randomValue <= maxValue - randomPowerupFrequency)
                powerup.powerupType = Powerup.PowerupType.Upgrade;
			else
                powerup.powerupType = Powerup.PowerupType.Random;

            Instantiate(powerup,
                new Vector2(Random.Range(-SPAWN_MAx_X, SPAWN_MAx_X), SPAWN_POINT_Y),
                Quaternion.identity);
			powerupTimer = POWERUP_RATIO / powerupFrequency;
		}
		asteroidTimer -= Time.deltaTime;
		powerupTimer -= Time.deltaTime;
	}
}
