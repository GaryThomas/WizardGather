using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(LevelPickUps))]
public abstract class PickUp : MonoBehaviour
{
	[SerializeField] LevelPickUps _pickups;

	protected virtual void Awake ()
	{
		//_pickups = GetComponent<LevelPickUps> ();
	}

	protected virtual void PickUpItem ()
	{
		_pickups.Collect (gameObject);
	}
}
