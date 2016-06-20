using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	[Tooltip("Force needed to destroy the block")]
	public float durability;

	[Tooltip("Minimum collision to register")]
	public float minColReg;

	[Tooltip("Time until blocks can start taking damage")]
	public float settleTime;

	Rigidbody rb;
	ParticleSystem ps;

	void Start () {
		rb = GetComponent<Rigidbody>();
		ps = GetComponent<ParticleSystem>();
	}

	void OnCollisionEnter (Collision c) {
		if (c.impulse.magnitude > minColReg && Time.time > settleTime) {
			durability -= c.impulse.magnitude;
			if (durability <= 0) {
				BlockDestroy();
			}
		}		
	}

	void BlockDestroy () {
		var model = transform.Find("Model").gameObject;
		var col = model.GetComponent<Collider>();

		ps.Play();
		col.enabled = false;
		model.SetActive(false);
		Destroy(gameObject, ps.startLifetime);
	}
}
