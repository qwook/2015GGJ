using UnityEngine;
using System.Collections;

public class EnemySpawner: MonoBehaviour {

	public GameObject enemySpawn;

	public EnemyWave[] waves;
	private int waveNumber = 0;
	public float waveDelay;

	private EnemyWave currentWave;

	// Use this for initialization
	void Start () {
		currentWave = waves [0];
//		StartCoroutine ("SpawnEnemy");
	}
	
	// Update is called once per frame
	void Update () {
		if(currentWave.waveFinished()) {
			waveNumber ++;
			currentWave = waves[waveNumber];
		} else {

			SpawnEnemy();
		}

		if(wavesFinished()) {
			print ("waves done");
		}
	}

//	IEnumerator SpawnEnemy() {
////		yield return new WaitForSeconds (currentWave.getEnemyDelay());
//
//		
//		GameObject enemy = currentWave.getEnemy ();
//
//		enemy.transform.position = enemySpawn.transform.position;
//		enemy.SetActive (true);
//
//
//	}

	void SpawnEnemy() {
//		MazePassage passage = Instantiate(passagePrefab) as MazePassage;
		GameObject enemy = currentWave.getEnemy();

		Instantiate (enemy, enemySpawn.transform.position, Quaternion.identity);
//		enemy.transform.position = enemySpawn.transform.position;
//		enemy.SetActive (true);
		print ("spawned");
	}


	bool wavesFinished() {
		return waveNumber >= waves.Length;
	}
}
