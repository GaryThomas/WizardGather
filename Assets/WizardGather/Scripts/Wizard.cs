using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
	public float walkSpeed = 2f;
	public int moveDir = 1;
	Rigidbody2D _rb;
	Animator _anim;
	Vector2 walkVelocity;
	BoxCollider2D _box;
	LayerMask _ground;
	bool walking = false;
	Vector3 lastPos;

	void Awake ()
	{
		_rb = GetComponent<Rigidbody2D> ();
		_anim = GetComponent<Animator> ();
		_anim.SetBool ("Walking", false);
		_box = GetComponent<BoxCollider2D> ();
		_ground = LayerMask.GetMask ("Ground");
		lastPos = transform.position;
	}

	void Start ()
	{
		walkVelocity = new Vector2 (walkSpeed, 0f);
	}

	void Update ()
	{
		if (walking && _box.IsTouchingLayers (_ground)) {
			float newX = Mathf.Max (Mathf.Abs (_rb.velocity.x), walkSpeed);
			// FIXME - sometimes the wizard gets stuck, not sure why
			float jump = Mathf.Abs (transform.position.x - lastPos.x) < Mathf.Epsilon ? 2.0f : 0.0f;
			lastPos = transform.position;
			if (jump > 0f) {
				Debug.Log ("*** Gave wizard a boost!");
			}
			// FIXME
			_rb.velocity = new Vector2 (moveDir * newX, _rb.velocity.y + jump);
//			Debug.Log ("Player - velocity: " + _rb.velocity.ToString ());
		}
		_anim.SetBool ("Walking", _rb.velocity.magnitude > 0);
	}

	public void StartMoving ()
	{
		Debug.Log ("Wizard: Start walking");
		walking = true;
		_rb.velocity = walkVelocity;
		GameController.Instance.StartLevel ();
	}

	public void Die ()
	{
		_anim.SetTrigger ("Death");
		GameController.Instance.ReloadLevel ();
	}
}
