using UnityEngine;
using System.Collections;

public class Divider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector2 pos = new Vector2 (Screen.width/2.0f, (Screen.height + 10f) / 2.0f);
		Vector3 newPos = Camera.main.ScreenToWorldPoint (new Vector3(pos.x, pos.y, 0f));
		transform.position = newPos;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Ball_P1" ||
		    collider.gameObject.tag == "Ball_P2") {
			GameObject obj = collider.gameObject;
			Ball ballScript = obj.GetComponent<Ball>();
			Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
			rb.gravityScale = -rb.gravityScale;
			rb.velocity *= .2f;
		}
	}

}
