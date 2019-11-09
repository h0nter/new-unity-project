using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public class EnemyPatrol : MonoBehaviour {

	public Transform[] points;
	public bool canMove = true;
	private NavMeshAgent agent;
	private Animator anim;
	private int destPoint = 0;


	void Start () {

		anim = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent>();
		destPoint = Random.Range (0, points.Length);
		NextPoint();
	}


	void NextPoint() {
		
		if (points.Length == 0)
			return;

		destPoint = Random.Range (0, points.Length);

		agent.destination = points[destPoint].position;

		destPoint = (destPoint + 1) % points.Length;
	}


	void Update () {

		if (agent.isStopped) {
			anim.SetFloat ("Speed_f", 0);
			return;
		}

			anim.SetFloat ("Speed_f", 1f);

		if (!agent.pathPending && agent.remainingDistance < 0.5f) {
			NextPoint ();

		}

	}

	void OnAnimatorMove()
	{
		agent.speed = (anim.deltaPosition / Time.deltaTime).magnitude;
	}



 }