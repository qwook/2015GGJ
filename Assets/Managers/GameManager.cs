using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject[] players;
	public GameObject[] npc;

	private float gameTime = 0;
	private float gameTimeStarted;
	private int currentPlayer;
	private bool gameStarted = false;

	void Start() {



	}

	void Update() {
		if (gameStarted) {
			gameTime += Time.deltaTime;

		} else {

		}

	}

	void BeginGame() {
		players [currentPlayer].SetActive (true);
		camera.enabled = false;
		gameStarted = true;
	}

	void RestartGame() {
	}



}
