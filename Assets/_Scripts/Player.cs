using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public int playerNumber;
	public string playerNumberStr;
	public int health = 100;
	public int speed = 130;
	public int rotationSpeed = 50;
	public bool holdingProjectile = false;
	public bool canMove = true;
	public bool playerAlive = true;
	public GameObject projectile;

	public bool m_LAxisInUse = false;
	public bool buildingShot = false;
	public float shotScale;

	public bool m_RAxisInUse = false;
	public bool chargingShot = false;
	public float shotSpeed = 0;
	public float shotLifeSpan = 0;
	public float shotChargeRate = 0.5f;
	public float shotRate = 50f;
	public float nextShotTime = 0;

	// Use this for initialization
	void Start () {
		playerNumberStr = "P" + playerNumber;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerAlive)
		{
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
			x = Input.GetAxis(playerNumberStr + "LookX");
			y = Input.GetAxis(playerNumberStr + "LookY");
			Rotate (x, y);

			if (Input.GetAxisRaw(playerNumberStr + "BuildShot") != 0)
			{

			}
			if (buildingShot)
			{
				if (Input.GetAxisRaw(playerNumberStr + "BuildShot") == 0)
				{

				}
			}

			if (Input.GetAxisRaw(playerNumberStr + "Shoot") != 0)
			{
				if (!m_RAxisInUse)
				{
					chargingShot = true;
					shotSpeed = 0;
					shotLifeSpan = 0;
					//play animation?
					m_RAxisInUse = true;
				}
			}
			if (chargingShot)
			{
				shotSpeed += shotChargeRate * Time.deltaTime;
				if (Input.GetAxisRaw(playerNumberStr + "Shoot") == 0)
				{
					//if (Time.time > nextShotTime)
					//{
						Shoot();
						chargingShot = false;
						m_RAxisInUse = false;
					//}
				}
			}

			//if (Input.GetButtonDown ())

			//push cancelling off to another time if you really need to since it seems tough to negate all the actions?
			//   not sure

			if (health <= 0)
			{
				playerAlive = false;
			}
		}
	}

	void FixedUpdate () {
		if (playerAlive)
		{
			float x, y;
			
			if (canMove)
			{
				x = Input.GetAxis(playerNumberStr + "MoveX");
				y = Input.GetAxis(playerNumberStr + "MoveY");
				if (x > 0)
					x = Mathf.Ceil(x);
				else if (x < 0)
					x = Mathf.Floor(x);
				if (y > 0)
					y = Mathf.Ceil(y);
				else if (y < 0)
					y = Mathf.Floor(y);
				Move (x, -y);  //don't quite know why it's inverted yet.
			}
		}
	}

	void Move (float x, float y) {
		//Debug.Log (x + " " + y);
		float displace = speed * Time.deltaTime;
		x *= displace;
		y *= displace;

		Vector2 velocity = new Vector2(x,y);
		Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
		rb2D.MovePosition(rb2D.position + velocity);
	}

	void Rotate (float x, float y) {

//		//how do you map these numbers to the guy's z rotation? (1, 1) would be like -45 degrees... (0, 1) would be 0,

		if (x == 0 && y == 0)
			return;
		else
		{
			float angle = Mathf.Atan2(-x, -y) * Mathf.Rad2Deg;
			//put in code that makes him turn around more slowly

			transform.rotation = Quaternion.Euler(0f,0f, angle);
			//		float angle = Mathf.Rad2Deg * Mathf.Atan(y/x) + 90f;
			//		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			//		transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
		}
	}

	void Shoot ()
	{
		GameObject temp = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
		temp.GetComponent<Rigidbody2D>().AddForce(transform.up * shotSpeed);
		Physics2D.IgnoreCollision( temp.GetComponentInChildren<Collider2D>(), transform.root.GetComponent<Collider2D>() );
		nextShotTime = Time.time + shotRate;
		shotSpeed = 0;
		//temp.rigidbody2D.velocity = ;
	}
	
	//registerHit, called by a snowball projectile that hits the player, causes player's health to decrement.
	//if his health is <= 0, change his sprite. movement disabling will be done by update.
	void ApplyDamage (int damageAmount)
	{
		health -= damageAmount;
	}

	//make snowball initializes a snowball with this player's playerNumber.

	//throw snowball
}
