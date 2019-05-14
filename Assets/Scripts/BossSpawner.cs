using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	
	public GameObject[] bossShip;

	float maxSpawnRateInSeconds = 10;
	
	void SpawnRandomBoss()
	{
		// This is the bottom left most point of the screen.
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0,0));
		// This is the bottom right most point of the screen.
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1,1));
		
		// Create an enemy as a new gameObject from the available gameObjects in the array.
		GameObject anBoss = Instantiate (bossShip [UnityEngine.Random.Range (0, bossShip.Length)]);
		anBoss.transform.position = new Vector2 (Random.Range (min.x, max.x), max.y);
		
		ScheduleNextBossSpawn();
	}

	void ScheduleNextBossSpawn()
	{
		float spawnInSeconds;

		if (maxSpawnRateInSeconds > 1f) {
			//Pick a random number between 1 and the max spawn rate.
			spawnInSeconds = Random.Range (1f, maxSpawnRateInSeconds);
		} else
			spawnInSeconds = 1f;
		// Spawn an enemy according the the timer.
		Invoke ("SpawnRandomBoss", spawnInSeconds);
	}
	// This will increase the spawn rate over time.
	void IncreaseSpawnRate()
	{
		if(maxSpawnRateInSeconds > 1f)
			maxSpawnRateInSeconds--;

		if(maxSpawnRateInSeconds == 1f)
			CancelInvoke("IncreaseSpawnRate");
	}
	// This function starts the enemy spawner.
	public void ScheduleEnemySpawner()
	{
		maxSpawnRateInSeconds = 5f;

		Invoke ("SpawnRandomBoss", maxSpawnRateInSeconds);

		//Increase spawn rate of ships every 60 Seconds.
		InvokeRepeating ("IncreaseSpawnRate", 0f, 60f);
	}
	// This function stops the enemy spawner.
	public void UnscheduleEnemySpawner()
	{
		CancelInvoke ("SpawnRandomBoss");
		CancelInvoke ("IncreaseSpawnRate");
	}
}