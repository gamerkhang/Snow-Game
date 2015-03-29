using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject UIGameplay;
	public GameObject UIMainMenu;
	public GameObject UIGameOver;
	public GameObject[] players;
	//public static timer text
	public static bool gameRunning = false;
	public int playerCount = 2;
	
	// Use this for initialization
	void Start () {
		UIGameplay = GameObject.Find("Gameplay");
		UIGameplay.SetActive(false);
		UIMainMenu = GameObject.Find("MainMenu");
		UIGameOver = GameObject.Find("GameOver");
		UIGameOver.SetActive(false);
		Time.timeScale = 0;
		players = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		//update gameplay timer text
		//if a player has won, enable game over stuff and halt...NAH LET THEM MOVE WHILE GAME OVER.
		//STEP ON THEIR BODIES.

		for (int i = 1; i < playerCount; ++i)
		{
			if (Input.GetButtonDown("P" + i + "Pause"))
				Pause();
			if (!players[i].GetComponent<Player>().playerAlive)
			{
				UIGameOver.SetActive(true);
				Application.Quit ();
			}
		}
	}
	
	public void MenuStartGame() {
		//on click, start game then change the button's text to be resume instead so it can be reused
		UIGameplay.SetActive(true);
		gameRunning = true;
		UIMainMenu.SetActive(false);
		Time.timeScale = 1;
	}
	
	public void MenuQuitGame() {
		Application.Quit();
	}

	void Pause () {
		gameRunning = false;
		Time.timeScale = 0;
	}

	void Resume() {
		gameRunning = true;
		Time.timeScale = 1;
	}
}
