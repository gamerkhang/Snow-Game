using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public int ownerPlayerNumber = 1;
	public int damageAmount = 10;
	public float lifeSpan;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player")
		{
			coll.gameObject.SendMessage("ApplyDamage", damageAmount);
			Destroy(gameObject);
		}
		else if (coll.gameObject.tag == "Edges")
			Destroy(gameObject);
		else if (true)
		{
			//outlived its determined lifespan/distance
		}

	}
	
	public void SetDamage (int damage)
	{
		damageAmount = damage;
	}

	public void SetLifespan (float time)
	{
		lifeSpan = time;
	}
}
