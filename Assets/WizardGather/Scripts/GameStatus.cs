using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{

	[SerializeField] GameObject gameOver;

	public void GameOver ()
	{
		gameOver.SetActive (true);
	}
}
