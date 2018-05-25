using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
	void OnMouseDrag ()
	{
		if (!GameController.Instance.LevelStarted) {
			//Debug.Log (gameObject.name + ": Mouse drag");
			Vector3 mousePos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10f);
			Vector3 objPos = Camera.main.ScreenToWorldPoint (mousePos);
			transform.position = objPos;
		}
	}

}
