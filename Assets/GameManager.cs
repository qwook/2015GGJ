using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject[] players;
	public GameObject[] npc;

	private int currentPlayer;

	void Start() {
		for (int i = 1; i < players.Length; i++) {
			//make players uncontrollable
			players [i].SetActive (false);
		}
		currentPlayer = 0;

	}

	void BeginGame() {


	}

	void RestartGame() {
		
		
	}

	void SetNextPlayerActive() {

		players [currentPlayer].SetActive (false);

		if (currentPlayer == players.Length-1) {
			currentPlayer = 0;
		} else {
			currentPlayer ++;
		}

		players [currentPlayer].SetActive (true);


	}
}
