using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPickUps : MonoBehaviour
{

	[SerializeField] List<GameObject> levelItems;
	[SerializeField] SpriteRenderer exitSpriteRenderer;
	[SerializeField] Sprite lockedDoorSprite;
	[SerializeField] Sprite unlockedDoorSprite;

	private int itemsCollected;

	void Start ()
	{
		BoxCollider2D[] boxes = gameObject.GetComponentsInChildren<BoxCollider2D> ();
		levelItems = new List<GameObject> ();
		foreach (BoxCollider2D box in boxes) {
			levelItems.Add (box.gameObject);
		}
		itemsCollected = 0;
	}

	public void Collect (GameObject item)
	{
		itemsCollected++;
		if (AllCollected ()) {
			exitSpriteRenderer.sprite = unlockedDoorSprite;
		}
	}

	public bool AllCollected ()
	{
		return itemsCollected == levelItems.Count;
	}
}
