using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class GameManager : MonoBehaviour {

	public int points = 0;
	public GameObject gameOverDisplay;
	public UnityEvent OnGameOver;


	void Start ()
	{		
		gameOverDisplay.SetActive (false);
	}

	public void AddPoints()
	{
		points++;

		if (points >= 8)
			GameOver ();
	}


	public void GameOver ()
	{
		gameOverDisplay.SetActive (true);
		OnGameOver.Invoke ();



	}

	public void StartOver(int scene)
	{
		SceneManager.LoadScene (scene);
	}
}
