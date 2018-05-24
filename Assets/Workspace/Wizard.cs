using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
	public float walkSpeed = 2f;
	public int moveDir = 1;
	Rigidbody2D _rb;
	Vector2 walkVelocity;
	BoxCollider2D _box;
	LayerMask _ground;

	void Awake ()
	{
		_rb = GetComponent<Rigidbody2D> ();
		_box = GetComponent<BoxCollider2D> ();
		_ground = LayerMask.GetMask ("Ground");
	}

	void Start ()
	{
		walkVelocity = new Vector2 (walkSpeed, 0f);
		_rb.velocity = walkVelocity;
	}

	void Update ()
	{
		if (_box.IsTouchingLayers (_ground)) {
			float newX = Mathf.Max (Mathf.Abs (_rb.velocity.x), walkSpeed);
			_rb.velocity = new Vector2 (moveDir * newX, _rb.velocity.y);
			Debug.Log ("Player - velocity: " + _rb.velocity.ToString ());
		}
	}
}
