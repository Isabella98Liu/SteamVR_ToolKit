//******************************************************************************************************
// Latest Update : 2/21/2018
// Author : Isabella Liu
// this scrip should be attached to one SteamVR [controller] (right)
// Function : enable touchpad to control the forward and backward movement of the character
//            y axis of the touchpad decide the move direction
// SDK Requirement : [SteamVR Plugin] https://assetstore.unity.com/packages/templates/systems/steamvr-plugin-32647
// Notification : the forwarding direction is where user looks at
//*******************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchpadWalking : MonoBehaviour {

    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device device;
    private GameObject cameraRig;        //change the trasform of cameraRig to move the character
    private GameObject cameraEye;

    public float moveScale = 0.1f;


    // Use this for initialization
    void Start () {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        cameraRig = transform.parent.gameObject;
        cameraEye = GameObject.Find("/[CameraRig]/Camera (eye)");
    }
	
	// Update is called once per frame
	void Update () {
        device = SteamVR_Controller.Input((int)trackedObject.index);
        if (device.GetAxis().x != 0 || device.GetAxis().y != 0)     // if there is input from touchpad
            if(device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
             cameraRigMove();
	}

    private void cameraRigMove()
    {
        if (device.GetAxis().y > 0 )
            cameraRig.transform.position += new Vector3(moveScale * Mathf.Sin(cameraEye.transform.eulerAngles.y * Mathf.PI /180), 0, moveScale * Mathf.Cos(cameraEye.transform.eulerAngles.y * Mathf.PI/180));
        if (device.GetAxis().y < 0 )
            cameraRig.transform.position += new Vector3( - moveScale * Mathf.Sin(cameraEye.transform.eulerAngles.y * Mathf.PI / 180), 0, - moveScale * Mathf.Cos(cameraEye.transform.eulerAngles.y * Mathf.PI / 180));
    }
}
