using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {
    public float score;
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {
    }
    public void AddScore (float n) {
        score = score + n;
    }
}
