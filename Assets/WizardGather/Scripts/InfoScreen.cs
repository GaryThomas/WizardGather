using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoScreen : MonoBehaviour
{

	[SerializeField] Image infoImage;
	[SerializeField] TMP_Text _infoText;
	[SerializeField] Image _infoIcon;
	[SerializeField] Button _infoNextButton;
	[SerializeField] TMP_Text _infoNextButtonText;

	bool nextItem = false;

	public IEnumerator ShowInventory (List<GameObject> inventory)
	{
		if (infoImage != null && !GameController.Instance.InstructionsDisplayed) {
			infoImage.gameObject.SetActive (true);
			yield return new WaitForSeconds (2.0f);
			List<string> seen = new List<string> ();
			foreach (GameObject obj in inventory) {
				Debug.Log ("Inventory: " + obj.name);
				InventoryItem item = obj.GetComponent<InventoryItem> ();
				if (seen.Contains (item.description)) {
					continue;
				}
				seen.Add (item.description);
				SpriteRenderer renderer = obj.GetComponent<SpriteRenderer> ();
				obj.SetActive (false);
				Debug.Log ("item: " + item.GetInstanceID ().ToString () + ", renderer = " + renderer.GetInstanceID ().ToString ());
				_infoText.text = item.description;
				_infoIcon.sprite = renderer.sprite;
				if (obj != inventory [inventory.Count - 1]) {
					_infoNextButtonText.text = "Next";
				} else {
					_infoNextButtonText.text = "Done!";
				}
				nextItem = false;
				while (!nextItem) {
					yield return null;
				}
				obj.SetActive (true);
			}
			infoImage.gameObject.SetActive (false);
		}
	}

	public void NextItem ()
	{
		nextItem = true;
	}
	

}
