using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	[Tooltip("Force needed to destroy the block")]
	public float durability;

	Rigidbody rb;
	ParticleSystem ps;

	void Start () {
		rb = GetComponent<Rigidbody>();
		ps = GetComponent<ParticleSystem>();
	}

	void OnCollisionEnter (Collision c) {

		durability -= c.impulse.magnitude;
		if (durability <= 0) {
			BlockDestroy();
		}
	}

	void BlockDestroy () {
		ps.Play();
		Destroy(gameObject, ps.startLifetime);
	}
}
