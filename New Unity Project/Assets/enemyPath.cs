using System.Collections;
using UnityEngine;

public class enemyPath : MonoBehaviour {
    public Transform[] target;
    public float speed;

    private int current;

	// Update is called once per frame
	void Update () {
        if (transform.position != target[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        else
        {
            current = (current + 1) % target.Length;
            transform.Rotate(0f, 180f, 0f);
        }
	}
}
