using UnityEngine;
using System.Collections;

public class EnemyWave : MonoBehaviour
{
	public GameObject[] enemies;
	public int enemiesInPlay;
	public string wavename;
	public int waveSize;
	public float enemyDelay;

	private GameObject[] inPlay;
	private int enemiesSpawned;


	// Use this for initialization
	void Start ()
	{
		enemiesSpawned = 0;
		for(int i = 0; i < enemies.Length; i++) {
			enemies[i].tag = wavename;
		}

	}

	public GameObject getEnemy() {
		enemiesSpawned++;
		return enemies[Random.Range(0, enemies.Length)];
	}

	public float getEnemyDelay () {
		return enemyDelay;
	}
	

	public int getEnemiesInPlay() {
		return enemiesInPlay;
	}

	public bool waveFinished() {
		return this.enemiesSpawned >= waveSize;
	}
}

