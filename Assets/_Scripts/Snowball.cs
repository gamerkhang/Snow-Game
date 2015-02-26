using UnityEngine;
using System.Collections;

public class Snowball : MonoBehaviour {
	public int playerNumber;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//oncollide2d or whatever the fucntion name is, if the object is a player and its playernumber isn't
	//equal to the snowball's, call that player's damage function and do whatever is necessary for destroying
	//the snowball (e.g. play animation, play sound, then destroy it).
}
