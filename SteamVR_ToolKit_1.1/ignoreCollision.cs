//******************************************************************************************************
// Latest Update : 3/3/2018
// Author : Isabella Liu
// this script should be attached to SteamVR [CameraRig]
// Function : ignore the collision between CameraRig rigidbody and dragable object's regidobdy when user using controller dragging objects
// SDK Requirement : [SteamVR Plugin] https://assetstore.unity.com/packages/templates/systems/steamvr-plugin-32647
// Notification : None
//*******************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignoreCollision : MonoBehaviour {

    private GameObject cameraEye;

    private void Start()
    {
        cameraEye = GameObject.Find("/[CameraRig]/Camera (eye)");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Cube")
        {
//            Debug.Log("Cube collider entered CameraRig, ignoreCollision enable.");
            Physics.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider>());
            Physics.IgnoreCollision(collision.collider, cameraEye.GetComponent<Collider>());
        }
    }
}
