using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public int playerNumber;
	public string playerNumberStr;
	public int health = 100;
	public int speed = 130;
	public bool holdingSnowball = false;
	public bool canMove = true;

	// Use this for initialization
	void Start () {
		playerNumberStr = "P" + playerNumber;
	}
	
	// Update is called once per frame
	void Update () {
		//remember to do input strings by making it "_____" + playerNumber!
		//if (Input.GetButton(playerNumberStr + "Pause"))
		//if input is pause, pause game
		//only allow movement and actions if player's health > 0
		//if not holding a snowball and input registered, make snowball (should be able to make ones that grow in size
		//  over time as they hold down the button)
		//if holding snowball and input registered, throw it (remember, they should be able to hold their throw)
		if (Input.GetButtonDown(playerNumberStr + "StopMoving"))
			canMove = false;
		if (Input.GetButtonUp(playerNumberStr + "StopMoving"))
			canMove = true;

		float x, y;

		if (canMove)
		{
			x = Input.GetAxis(playerNumberStr + "MoveX");
			y = Input.GetAxis(playerNumberStr + "MoveY");
			Move (x, y);
		}

		x = Input.GetAxis(playerNumberStr + "LookX");
		y = Input.GetAxis(playerNumberStr + "LookY");
		Rotate (x, y);

		//if (Input.GetButtonDown ())

		//push cancelling off to another time if you really need to since it seems tough to negate all the actions?
		//   not sure
	}

	void Move (float x, float y) {
		float displace = speed * Time.deltaTime;
		float xComp = x * displace;
		float yComp = y * displace;

		if(x != 0 && y != 0)
		{
			xComp = xComp * Mathf.Sqrt(2)/2;
			yComp = yComp * Mathf.Sqrt(2)/2;
			
		}

		Vector2 velocity = new Vector2(xComp,yComp);
		//rigidbody2D.MovePosition((Vector2)transform.position + velocity);
	}

	void Rotate (float x, float y) {

	}

	//registerHit, called by a snowball projectile that hits the player, causes player's health to decrement.
	//if his health is <= 0, change his sprite. movement disabling will be done by update.

	//make snowball initializes a snowball with this player's playerNumber.

	//throw snowball
}
