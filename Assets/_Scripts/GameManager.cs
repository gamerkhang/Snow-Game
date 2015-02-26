using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject gameplay;
	//public static timer text
	public static bool gameRunning = true;
	
	// Use this for initialization
	void Start () {
		gameplay = GameObject.Find("Gameplay");
		gameplay.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		//update gameplay timer text
		//if a player has won, enable game over stuff and halt...NAH LET THEM MOVE WHILE GAME OVER.
		//STEP ON THEIR BODIES.
	}

	void PlayGame () {
		gameplay.SetActive(true);
		//set timer to be 0
	}

	void Pause () {
		if (gameRunning)
		{

		}
	}

	void Resume() {
		if (!gameRunning)
		{

		}
	}
}
