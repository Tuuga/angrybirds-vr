using UnityEngine;
using System.Collections;
using Valve.VR;

public class DebugLaunchScript: MonoBehaviour {

    public GameObject gameManager;
    SlingScript slingScript;

    // Use this for initialization
    void Start() {
        slingScript = gameManager.GetComponent<SlingScript>();


    }
    // Update is called once per frame
    void Update() {
        if (Input.GetKey(slingScript.launchButton) && !slingScript.launched) {
            slingScript.Launch();
        }
        if (Input.GetKeyDown(KeyCode.F5)) {
            Application.LoadLevel(Application.loadedLevelName);
        }
    }
}
