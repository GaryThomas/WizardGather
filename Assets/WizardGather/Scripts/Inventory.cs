using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{

	[SerializeField] List<GameObject> inventory;
	[SerializeField] InfoScreen info;

	void Start ()
	{
		BoxCollider2D[] boxes = gameObject.GetComponentsInChildren<BoxCollider2D> ();
		inventory = new List<GameObject> ();
		foreach (BoxCollider2D box in boxes) {
			inventory.Add (box.gameObject);
		}
	}

	public void OnInventoryStartupComplete ()
	{
		Debug.Log ("Inventory: Startup complete");
		StartCoroutine (info.ShowInventory (inventory));
	}
}
