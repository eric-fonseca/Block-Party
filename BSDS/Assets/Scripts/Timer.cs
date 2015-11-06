using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	Text _text;
	float startTime;
	public float GameTime;
	// Use this for initialization
	void Start () {
		_text = this.gameObject.GetComponent<Text> ();
		startTime = Time.time;

	}
	
	// Update is called once per frame
	void Update () {
		GameTime = Time.time - startTime;

		int minutes = (int)GameTime / 60; 
		int seconds = (int)GameTime % 60; 

		_text.text = string.Format ("{0:00}:{1:00}", minutes, seconds);

		//_text.text = GameTime.ToString();
	}
}
