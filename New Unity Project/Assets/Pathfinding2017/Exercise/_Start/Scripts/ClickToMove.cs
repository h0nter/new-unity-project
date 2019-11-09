using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent))]
[RequireComponent (typeof(Animator))]
public class ClickToMove : MonoBehaviour
{
	public bool canMove = true;
	private NavMeshAgent agent;
	private Animator anim;


	void Start ()
	{
		anim = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();
	}

	void Update ()
	{
		
		if (agent.isStopped) {
			anim.SetFloat ("Speed_f", 0);
			return;
		}


		if (agent.remainingDistance > agent.stoppingDistance) {
			anim.SetFloat ("Speed_f", 1f, 0.05f, Time.deltaTime);
		} else{
			anim.SetFloat ("Speed_f", 0);
		}

	
		if (Input.GetButtonDown ("Fire1")) {
			
			RaycastHit hit; 
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray.origin, ray.direction, out hit)) {
				agent.destination = hit.point;
			
			}
		}

	
	
	}

	void OnAnimatorMove ()
	{
		agent.speed = (anim.deltaPosition / Time.deltaTime).magnitude;
	}


}
