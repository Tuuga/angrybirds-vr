using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagerScript : MonoBehaviour {
    static float score;

    public static void AddScore (float n) {
        score += n;
		print(score);
    }
}
