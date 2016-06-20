using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	[Tooltip("Force needed to destroy the block")]
	public float durability;

	[Tooltip("Minimum collision to register")]
	public float minColReg;

	Rigidbody rb;
	ParticleSystem ps;

	void Start () {
		rb = GetComponent<Rigidbody>();
		ps = GetComponent<ParticleSystem>();
	}

	void OnCollisionEnter (Collision c) {
		if (c.impulse.magnitude > minColReg) {
			durability -= c.impulse.magnitude;
			if (durability <= 0) {
				BlockDestroy();
			}
		}		
	}

	void BlockDestroy () {
		var bc = GetComponent<BoxCollider>();
		var model = transform.Find("Model").gameObject;

		ps.Play();
		bc.enabled = false;
		model.SetActive(false);
		Destroy(gameObject, ps.startLifetime);
	}
}
