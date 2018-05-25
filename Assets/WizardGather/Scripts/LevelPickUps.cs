using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPickUps : MonoBehaviour
{

	[SerializeField] List<GameObject> levelItems;
	[SerializeField] ExitLevel exit;
	//	[SerializeField] SpriteRenderer exitSpriteRenderer;
	//	[SerializeField] Sprite lockedDoorSprite;
	//	[SerializeField] Sprite unlockedDoorSprite;

	private int itemsCollected;
	//	private bool doorLocked;

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
//		doorLocked = true;
	}

	public void Collect (GameObject item)
	{
		itemsCollected++;
		if (AllCollected ()) {
//			exitSpriteRenderer.sprite = unlockedDoorSprite;
			exit.LockDoor (false);
//			doorLocked = false;
		}
	}

	public bool AllCollected ()
	{
		return itemsCollected == levelItems.Count;
	}

}
