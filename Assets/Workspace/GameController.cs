using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	private bool levelStarted = false;

	public bool LevelStarted { get { return levelStarted; } }

	private bool instructionsDisplayed = false;

	public bool InstructionsDisplayed{ get { return instructionsDisplayed; } }

	private static GameController _instance = null;

	public static GameController Instance { 
		get {
			if (_instance == null) {
				_instance = Object.FindObjectOfType<GameController> ();
			}
			return _instance;
		}
	}

	void Awake ()
	{
		if (_instance == null) {
			_instance = Instance;
		} else if (_instance != this) {
			Destroy (gameObject);
			return;
		}
		DontDestroyOnLoad (_instance.gameObject);
	}

	public void StartLevel ()
	{
		levelStarted = true;
		instructionsDisplayed = true;
	}

	public void ReloadLevel ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		levelStarted = false;
	}

	public void LoadNextLevel ()
	{
		int nextLevel = (SceneManager.GetActiveScene ().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
		Debug.Log ("LoadNextLevel = " + nextLevel.ToString () + ", active = " + SceneManager.GetActiveScene ().buildIndex.ToString () + ", total = " + SceneManager.sceneCountInBuildSettings.ToString ());
		SceneManager.LoadScene (nextLevel);
		levelStarted = false;
	}
}
