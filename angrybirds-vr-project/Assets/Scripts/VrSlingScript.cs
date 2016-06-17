using UnityEngine;
using System.Collections;
using Valve.VR;

public class VrSlingScript : MonoBehaviour {

    EVRButtonId trigger = EVRButtonId.k_EButton_SteamVR_Trigger;
    EVRButtonId grip = EVRButtonId.k_EButton_Grip;
    EVRButtonId menu = EVRButtonId.k_EButton_ApplicationMenu;
    EVRButtonId touchPad = EVRButtonId.k_EButton_SteamVR_Touchpad;

    SteamVR_Controller.Device controller;
    SteamVR_TrackedObject trackedObj;

    public GameObject gameManager;
    SlingScript slingScript;

    // Use this for initialization
    void Start() {

        trackedObj = GetComponent<SteamVR_TrackedObject>();
        controller = SteamVR_Controller.Input((int)trackedObj.index);

        slingScript = gameManager.GetComponent<SlingScript>();


    }
    // Update is called once per frame
    void Update() {
       if (controller.GetPressDown(trigger) && !slingScript.launched){
            slingScript.Launch();
        }
       if (controller.GetPressDown(touchPad)) {
            Application.LoadLevel(Application.loadedLevelName);
        }
    }
}
