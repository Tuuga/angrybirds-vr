using UnityEngine;
using System.Collections;
    
    public class AddScoreScript : MonoBehaviour {
    public float scoreBase = 10f;

	void OnTriggerEnter(Collider c) {
        GameManagerScript.AddScore(scoreBase);
        Destroy(gameObject);
    }
}
