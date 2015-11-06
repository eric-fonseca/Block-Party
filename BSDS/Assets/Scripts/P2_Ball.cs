using UnityEngine;
using System.Collections;

public class P2_Ball : MonoBehaviour {

	Rigidbody2D rb2d;
	public bool CrossedBounds = false;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		/*
		Vector3 pos = Camera.main.WorldToScreenPoint (transform.position);
		
		if (pos.y <= (Screen.height - 16.0f) / 2.0f && !CrossedBounds) {
			rb2d.gravityScale = 1.0f;
			CrossedBounds = true;
		} else if (pos.y >= (Screen.height - 16.0f) / 2.0f && !CrossedBounds) {
			rb2d.gravityScale = -1.0f;
		}
		*/
	}
}
