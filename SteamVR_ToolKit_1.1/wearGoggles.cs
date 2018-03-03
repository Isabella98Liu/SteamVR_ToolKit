//******************************************************************************************************
// Latest Update : 3/3/2018
// Author : Isabella Liu
// this script should be attached to [Frame] under [SafetyGlasses]
// Function : adding visual effect after wear goggles  (when the distance between goggles and CameraEye is small enough)
// SDK Requirement : [SteamVR Plugin] https://assetstore.unity.com/packages/templates/systems/steamvr-plugin-32647
// Notification : None
//*******************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wearGoggles : MonoBehaviour {

    private GameObject cameraEye;

	// Use this for initialization
	void Start () {
        cameraEye = GameObject.Find("/[CameraRig]/Camera (eye)");
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(gameObject.transform.position, cameraEye.transform.position);
        //       Debug.Log("The distance between Eye and Goggles are : " + distance);
        if (distance < 0.3f)
        {
            Debug.Log("You have wear your safty goggles.");
        }
	}

}
