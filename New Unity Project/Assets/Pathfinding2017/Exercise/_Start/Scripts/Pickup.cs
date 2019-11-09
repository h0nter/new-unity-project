using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	public GameManager gameManager;

	void Start ()
	{
		gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager> ();
	}

	void Update ()
	{
		transform.Rotate (Vector3.forward * 1f);
	}


	void OnTriggerEnter (Collider col)
	{
		if (col.CompareTag ("Player")) {
			gameManager.AddPoints ();
			gameObject.SetActive (false);
		
		}
	}

}
