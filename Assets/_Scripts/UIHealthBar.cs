using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIHealthBar : MonoBehaviour {
	public int playerNumber = 1;
	public Player player;
	public Image healthBar;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player" + playerNumber).GetComponent<Player>();
		healthBar = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.fillAmount = player.health / 100.0f;
	}
}
