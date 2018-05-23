using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
	public float walkSpeed = 2f;
	public Vector2 jumpAdjust = new Vector2 (2.5f, 8.5f);
	public int moveDir = 1;
	Rigidbody2D _rb;
	Vector2 walkVelocity;
	bool touchingGround = false;

	void Awake ()
	{
		_rb = GetComponent<Rigidbody2D> ();
	}

	void Start ()
	{
		walkVelocity = new Vector2 (walkSpeed, 0f);
		_rb.velocity = walkVelocity;
	}

	void Update ()
	{
		//_rb.velocity += walkVelocity;
		//_rb.AddForce (transform.forward * walkSpeed);
		if (touchingGround) {
			float newX = Mathf.Max (Mathf.Abs (_rb.velocity.x), walkSpeed);
			_rb.velocity = new Vector2 (moveDir * newX, _rb.velocity.y);
			Debug.Log ("Player - velocity: " + _rb.velocity.ToString ());
		}
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		Debug.Log (gameObject.name + " Collided with " + other.gameObject.name);
		if (other.gameObject.tag == "Ground") {
			touchingGround = true;
		}
		if (other.gameObject.tag == "Spikes") {
			Debug.Log ("OUCH!!");
		}
		if (other.gameObject.tag == "JumpUp") {
			Debug.Log (gameObject.name + " hit JumpUp: " + other.gameObject.name);
			_rb.velocity += jumpAdjust;
			_rb.AddForce (jumpAdjust);
			Destroy (other.gameObject);
		}
	}

	void OnCollisionExit2D (Collision2D other)
	{
		Debug.Log (gameObject.name + " Stopped colliding with " + other.gameObject.name);
		if (other.gameObject.tag == "Ground") {
			touchingGround = false;
		}
	}
}
