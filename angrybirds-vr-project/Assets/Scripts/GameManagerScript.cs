using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {
    static float score;

    public static void AddScore (float n) {
        score += n;
		print(score);
    }
}
