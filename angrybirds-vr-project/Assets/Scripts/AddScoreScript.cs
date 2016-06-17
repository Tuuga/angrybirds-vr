using UnityEngine;
using System.Collections;
    
    public class AddScoreScript : MonoBehaviour {
    public float scoreBase = 10f;
    GameObject gameManager;
    GameManagerScript gmScript;

    void Start () {
        gameManager = GameObject.Find("GameManager");
        gmScript = gameManager.GetComponent<GameManagerScript>();
    }

	void OnTriggerEnter(Collider c) {
        gmScript.AddScore(scoreBase);
        Destroy(gameObject);
    }
}
