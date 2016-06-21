using UnityEngine;
using System.Collections;
using Valve.VR;

public class SlingScript : MonoBehaviour {

    EVRButtonId trigger = EVRButtonId.k_EButton_SteamVR_Trigger;
    EVRButtonId grip = EVRButtonId.k_EButton_Grip;
    EVRButtonId menu = EVRButtonId.k_EButton_ApplicationMenu;
    EVRButtonId touchPad = EVRButtonId.k_EButton_SteamVR_Touchpad;

    SteamVR_Controller.Device controller;
    SteamVR_TrackedObject trackedObj;

    public GameObject slingableObject;
    public GameObject slingMiddlePositionMarkerObject;
    public GameObject vRCamera;
    public GameObject vRCameraRig;
    public GameObject debugCamera;
    public GameObject playerRender;
    GameObject slingInitCam;
    FPS_CAM_Script debugCamScript;
    Rigidbody rb;
    public KeyCode launchButton = KeyCode.D;
    public bool launched;
    public bool vROn;
    public float launchVelocity = 10f;

	// Use this for initialization
	void Start () {
        rb = slingableObject.GetComponent<Rigidbody>();
        debugCamScript = slingableObject.GetComponent<FPS_CAM_Script>();
        if (vROn && vRCamera != null) {
            slingInitCam = vRCamera;
            debugCamScript.isActive = false;
            debugCamera.SetActive(false);
        }
        else {
            slingInitCam = slingableObject;
        }
	
	}
	
	// Update is called once per frame

    public void Launch () {
        if (!launched) {
            launched = true;
            debugCamScript.MouseLock();
            playerRender.SetActive(true);
            if (vROn && vRCameraRig != null) {
                slingableObject.transform.position = vRCamera.transform.position;
                vRCameraRig.transform.parent = slingableObject.transform;
            }
            rb.isKinematic = false;
            var heading = slingMiddlePositionMarkerObject.transform.position - slingableObject.transform.position;
            var distance = heading.magnitude;
												// var dir = heading.normalized;
            var direction = heading / distance; // This is now the normalized direction.
            rb.AddForce(direction * ((distance * 2) * launchVelocity));

        }
    }
}
