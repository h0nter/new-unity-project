using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(SphereCollider))]
public class Detection : MonoBehaviour
{
	[Range (0f, 180f)]
	public float viewAngle = 110f;
	[Range (0f, 100f)]
	public float viewingRadius;
	public Color colorPick;
	public LayerMask obstacleLayer;
	private SphereCollider col;
	private NavMeshAgent agent;
	public GameManager gameManager;

	void Start ()
	{

		gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager> ();
		agent = GetComponent<NavMeshAgent> ();
		col = GetComponent<SphereCollider> ();
		col.radius = viewingRadius / 2;

	}

	void OnTriggerStay (Collider col)
	{
		if (col.CompareTag ("Player")) {
			
				
			Vector3 direction = (col.transform.position - transform.position);

			if (Vector3.Angle (transform.forward, direction) < viewAngle / 2) {
					
				if (!Physics.Raycast (transform.position + transform.up, direction.normalized, viewingRadius, obstacleLayer)) {
					Debug.Log ("you've been spotted");
					Debug.DrawRay (transform.position + transform.up, direction.normalized * viewingRadius, Color.blue);
					gameManager.GameOver ();
				
				} 

			}

		} 

	}



}


