using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
	Rigidbody2D rb2d;
	public bool CanHit = true;
	public GameObject LockObject;
	public GameObject Holder;

	public bool OnBottom;
	public bool OnTop;
	public float angle;
	GameMaster gm;

	// Use this for initialization
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();

		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<GameMaster> ();
	}
	
	// Update is called once per frame
	void Update()
	{
		Clamp();
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Block") {
			if(CanHit) {
				ContactPoint2D[] contacts = collision.contacts;
				GameObject toDestroy = contacts[0].collider.gameObject;
				Destroy(toDestroy);
				gm.BlockCount--;
			}
			CanHit = false;
		}

		if (collision.gameObject.tag == "Block_White") {

			//ContactPoint2D[] contacts = collision.contacts;
			//GameObject toDestroy = contacts[0].collider.gameObject;
			Destroy(collision.gameObject);
			gm.BlockCount--;
			//CanHit = false;
		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Divider") {
			Debug.Log("Divider hit");
			rb2d.gravityScale = -rb2d.gravityScale;
		}
	}

	void Clamp()
	{
		if (LockObject != null) {
			transform.position = LockObject.transform.position;

			//angle += Input.GetAxis("RotateBottom");
			//angle *= Mathf.PI;
			float roll = Input.GetAxis ("RotateBottom");
			if(roll < 0 && angle > -8 || roll > 0 && angle < 8){
				angle += roll * Time.deltaTime * 15.0f;
			}
			if(roll == 0){
				angle = 0;
			}

			//rotate it based on input
			transform.RotateAround(Holder.transform.position, Vector3.forward, angle*Mathf.PI);

		}


		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);

		if(pos.x < 16f)
		{
			Vector3 newRBP = new Vector3(16f, pos.y, 0);
			Vector3 spos = Camera.main.ScreenToWorldPoint(newRBP);
			rb2d.position = new Vector2(spos.x,spos.y);
			transform.position = rb2d.position;
			rb2d.velocity = new Vector2(-rb2d.velocity.x, rb2d.velocity.y);
		}

		else if(pos.x > Screen.width - 16f)
		{
			Vector3 newRBP = new Vector3(Screen.width - 16f, pos.y, 0);
			Vector3 spos = Camera.main.ScreenToWorldPoint(newRBP);
			rb2d.position = new Vector2(spos.x,spos.y);
			transform.position = rb2d.position;
			rb2d.velocity = new Vector2(-rb2d.velocity.x, rb2d.velocity.y);
		}

		else if(pos.y < 16f)
		{
			Vector3 newRBP = new Vector3(pos.x, 16f, 0);
			Vector3 spos = Camera.main.ScreenToWorldPoint(newRBP);
			rb2d.position = new Vector2(spos.x,spos.y);
			transform.position = rb2d.position;
			rb2d.velocity = new Vector2(rb2d.velocity.x, -rb2d.velocity.y);
		}
		
		else if(pos.y > Screen.height - 16f)
		{
			Vector3 newRBP = new Vector3(pos.x, Screen.height - 16f, 0);
			Vector3 spos = Camera.main.ScreenToWorldPoint(newRBP);
			rb2d.position = new Vector2(spos.x,spos.y);
			transform.position = rb2d.position;
			rb2d.velocity = new Vector2(rb2d.velocity.x, -rb2d.velocity.y);
		}
	}
}