//******************************************************************************************************
// Latest Update : 2/21/2018
// Author : Isabella Liu
// this scrip should be attached to one SteamVR [controller] (left)
// Function : enable touchpad to control the rotate of [CameraRig] / the rotation of the character;
//            different angle stands for different rotation speed.
// SDK Requirement : [SteamVR Plugin] https://assetstore.unity.com/packages/templates/systems/steamvr-plugin-32647
// Notification : Axis of [CameraRig] and [controller] should be the same as the world axis
//*******************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchpadHeadRotate : MonoBehaviour {

    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device device;
    private GameObject cameraRig;
    private Vector3 cameraRigRotation;
    private float cameraRigRotationAngle;

    public float rotateScale = 1.0f;


	// Use this for initialization
	void Start () {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        cameraRig = transform.parent.gameObject;
    
	}

	// Update is called once per frame
	void Update () {
        device = SteamVR_Controller.Input((int)trackedObject.index);
        if (device.GetAxis().x != 0 || device.GetAxis().y != 0)   // if there is input from touchpad
            CameraRigRotate();

	}

    private void CameraRigRotate()    // Rotate [CameraRig]
    {
        cameraRigRotationAngle = CameraRigRotation();
        cameraRigRotation = new Vector3(0f, cameraRigRotationAngle * rotateScale / 100 , 0f); 
        cameraRig.transform.Rotate(cameraRigRotation, Space.World);
    }

    private float CameraRigRotation()   // Calculate the rotation angle of touchpad point, scale ( -180, 180)
    {
        float RotationAngle = 0f;
        RotationAngle = Mathf.Atan(device.GetAxis().x / device.GetAxis().y) * 180 / Mathf.PI;
        if (device.GetAxis().y < 0 && device.GetAxis().x > 0)  // fourth quadrant, adjust angle into scale
            RotationAngle += 180;
        if (device.GetAxis().y < 0 && device.GetAxis().x < 0)  // third quadrant
            RotationAngle += (-180);
        return RotationAngle;

    }

}
