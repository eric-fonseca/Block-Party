using UnityEngine;
using System.Collections;

public class BreakerController : MonoBehaviour {
	Rigidbody2D rb2d;
	public bool top;
	float power = 4.0f;
	GameObject ball;
	public GameObject throwPoint;
	public GameObject GOMaster;
	GameMaster Master;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		Master = GOMaster.GetComponent<GameMaster> ();
	}
	
	// Update is called once per frame
	void Update () {
		ApplyGravity();
		CheckHorizontalMovement();

		if (Master.SinglePlayer) {
			if (Input.GetButtonDown ("Jump")) {
				power = 0.0f;
				while (power < 4.25f)
					power += Time.deltaTime;
				
			}
			
			if (Input.GetButtonUp ("Jump"))
				ThrowBall ();
		} else {

			if(top) {
				if (Input.GetButtonDown ("P2_Shoot")) {
					power = 0.0f;
					while (power < 4.25f)
						power += Time.deltaTime;
					
				}
				
				if (Input.GetButtonUp ("P2_Shoot"))
					ThrowBall ();
			}
			else {
				if (Input.GetButtonDown ("P1_Shoot")) {
					power = 0.0f;
					while (power < 4.25f)
						power += Time.deltaTime;
					
				}
				
				if (Input.GetButtonUp ("P1_Shoot"))
					ThrowBall ();
			}
		}

	}

	void ApplyGravity(){
		if(top){
			Vector3 pos = Camera.main.WorldToScreenPoint (transform.position);
			if(pos.y <= (Screen.height - 32f))
			{
				rb2d.AddForce(new Vector2(0.0f,50f) * Time.deltaTime);
			}
			else
			{
				rb2d.velocity = new Vector2(rb2d.velocity.x,0);
			}
		}
		else{
			Vector3 pos = Camera.main.WorldToScreenPoint (transform.position);
			if(pos.y >= (32f))
			{
				rb2d.AddForce(new Vector2(0.0f,-50f) * Time.deltaTime);
			}
			else
			{
				rb2d.velocity = new Vector2(rb2d.velocity.x,0);
			}
		}

	}
	void CheckHorizontalMovement(){
		float axisValue;

		//If we are playing singlePlayer
		if (Master.SinglePlayer) {
			if(top){
				axisValue = Input.GetAxis ("SP_Horizontal2");
			}
			else{
				axisValue = Input.GetAxis ("SP_Horizontal");
			}
		} else {
			if(top){
				axisValue = Input.GetAxis ("Horizontal2");
			}
			else{
				axisValue = Input.GetAxis ("Horizontal");
			}
		}


		float hDisplacement = 5.0f * axisValue;

		Vector3 pos = Camera.main.WorldToScreenPoint (transform.position);
		if(pos.x < 32f)
		{
			//rb2d.velocity = new Vector2(0,rb2d.velocity.y);
			Vector3 newRBP = new Vector3(32f, pos.y, 0);
			Vector3 spos = Camera.main.ScreenToWorldPoint(newRBP);
			rb2d.position = new Vector2(spos.x,spos.y);
			transform.position = rb2d.position;
		}
		else if(pos.x > Screen.width - 32f)
		{
			Vector3 newRBP = new Vector3(Screen.width - 32f, pos.y, 0);
			Vector3 spos = Camera.main.ScreenToWorldPoint(newRBP);
			rb2d.position = new Vector2(spos.x,spos.y);
			transform.position = rb2d.position;
		}
		else{
			//rb2d.AddForce(new Vector2(hDisplacement,0.0f) * Time.deltaTime);
			rb2d.velocity = new Vector2(hDisplacement,rb2d.velocity.y);
		}

	}

	void OnCollisionEnter2D(Collision2D collision) {

		if (top) {
			if (collision.gameObject.tag == "Ball_P2") {
				if(ball != null)
					return;

				Ball ballScript = collision.gameObject.GetComponent<Ball> ();
				ballScript.LockObject = throwPoint;
				ballScript.Holder = this.gameObject;
				ballScript.CanHit = true;

				Rigidbody2D cRB = collision.gameObject.GetComponent<Rigidbody2D> ();
				cRB.gravityScale = 0;
				cRB.angularVelocity = 0;
				cRB.velocity = Vector2.zero;
				ball = collision.gameObject;
			}
			else if(collision.gameObject.tag == "Ball_P1"){
				if(ball != null)
					return;

				Ball ballScript = collision.gameObject.GetComponent<Ball> ();
				ballScript.LockObject = throwPoint;
				ballScript.Holder = this.gameObject;
				ballScript.CanHit = false;
			
				Rigidbody2D cRB = collision.gameObject.GetComponent<Rigidbody2D> ();
				cRB.gravityScale = 0;
				cRB.angularVelocity = 0;
				cRB.velocity = Vector2.zero;
				ball = collision.gameObject;
			}
		} else {
			if (collision.gameObject.tag == "Ball_P1") {
				if(ball != null)
					return;

				Ball ballScript = collision.gameObject.GetComponent<Ball>();
				ballScript.LockObject = throwPoint;
				ballScript.Holder = this.gameObject;
				ballScript.CanHit = true;

				Rigidbody2D cRB = collision.gameObject.GetComponent<Rigidbody2D>();
				cRB.gravityScale = 0;
				cRB.angularVelocity = 0;
				cRB.velocity = Vector2.zero;
				ball = collision.gameObject;
			}
			else if(collision.gameObject.tag == "Ball_P2") {
				if(ball != null)
					return;
				
				Ball ballScript = collision.gameObject.GetComponent<Ball>();
				ballScript.LockObject = throwPoint;
				ballScript.Holder = this.gameObject;
				ballScript.CanHit = false;
				Rigidbody2D cRB = collision.gameObject.GetComponent<Rigidbody2D>();
				cRB.gravityScale = 0;
				cRB.angularVelocity = 0;
				cRB.velocity = Vector2.zero;
				ball = collision.gameObject;
			}
		}

	}

	void ThrowBall(){

		if (ball) {
			Ball ballScript = ball.GetComponent<Ball>();
			ballScript.LockObject = null;
			Vector2 direction = new Vector2(ballScript.gameObject.transform.position.x-this.transform.position.x, ballScript.gameObject.transform.position.y-this.transform.position.y);
			Rigidbody2D cRB = ball.GetComponent<Rigidbody2D> ();
			if(top) {
				cRB.gravityScale = -1;
				cRB.AddForce (-direction * -power * Time.deltaTime);
			}
			else {
				cRB.gravityScale = 1;
				cRB.AddForce (direction * power * Time.deltaTime);
			}

			ball = null;
		}
	}
}
