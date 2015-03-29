using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextTimer : MonoBehaviour {
	bool active = false;
	public float startTime, currentTime;
	Text timer;

	// Use this for initialization
	void Start () {
		timer = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (active)
		{
			currentTime = Time.time - startTime;
			string minutes = Mathf.Floor(currentTime / 60).ToString("00");
			string seconds = Mathf.Floor(currentTime % 60).ToString("00");
			timer.text = minutes + ":" + seconds;
		}
	}

	public void StartTimer() {
		startTime = Time.time;
		active = true;
	}
}
