using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	[Tooltip("Force needed to destroy the block")]
	public float strenght;

	Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void OnCollisionEnter (Collision c) {
		print(name + " - " + c.gameObject.name + " " + "Impulse: " + c.impulse.magnitude);
		if (c.impulse.magnitude > strenght) {
			BlockDestroy();
		}
	}

	void BlockDestroy () {
		// Particles in future
		Destroy(gameObject);
	}
}
