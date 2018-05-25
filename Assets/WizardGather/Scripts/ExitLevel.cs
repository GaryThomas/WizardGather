using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour
{

	[SerializeField] Sprite lockedDoorSprite;
	[SerializeField] Sprite unlockedDoorSprite;

	private SpriteRenderer exitSpriteRenderer;
	private bool doorLocked = true;
	private GameController _gc;

	void Start ()
	{
		_gc = GameController.Instance;
		exitSpriteRenderer = GetComponent<SpriteRenderer> ();
	}

	public void LockDoor (bool state)
	{
		doorLocked = state;
		exitSpriteRenderer.sprite = doorLocked ? lockedDoorSprite : unlockedDoorSprite;
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		Debug.Log (gameObject.name + " Collided with " + other.gameObject.name);
		if (other.gameObject.tag == "Player") {
			if (doorLocked) {
				Wizard wizard = other.gameObject.GetComponent<Wizard> ();
				wizard.Die ();
			} else {
				Debug.Log ("Go to next level!");
				_gc.LoadNextLevel ();
			}
		}
	}

}
