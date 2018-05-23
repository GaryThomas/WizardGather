using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
	public float walkSpeed = 2f;
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
			_rb.velocity = new Vector2 (walkSpeed, _rb.velocity.y);
		}
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		Debug.Log (gameObject.name + " Collided with " + other.gameObject.name);
		if (other.gameObject.tag == "Ground") {
			touchingGround = true;
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
