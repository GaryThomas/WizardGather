using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPickUps : MonoBehaviour
{

	[SerializeField] List<GameObject> levelItems;
	[SerializeField] ExitLevel exit;

	private int itemsCollected;

	void Start ()
	{
		BoxCollider2D[] boxes = gameObject.GetComponentsInChildren<BoxCollider2D> ();
		BoxCollider2D myBox = GetComponent<BoxCollider2D> ();
		levelItems = new List<GameObject> ();
		foreach (BoxCollider2D box in boxes) {
			if (box != myBox) {
				levelItems.Add (box.gameObject);
			}
		}
		itemsCollected = 0;
		exit.LockDoor (true);
	}

	public void Collect (GameObject item)
	{
		itemsCollected++;
		if (AllCollected ()) {
			exit.LockDoor (false);
		}
	}

	public bool AllCollected ()
	{
		return itemsCollected == levelItems.Count;
	}

}
