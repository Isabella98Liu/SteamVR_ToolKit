//******************************************************************************************************
// Latest Update : 2/15/2018
// Author : Isabella Liu
// this scrip should be attached to two SteamVR [controller]
// Function : enable [controller] drag objects by pressing the Grip Button
//            throw objects by releasing the Grip Button
// SDK Requirement : [SteamVR Plugin] https://assetstore.unity.com/packages/templates/systems/steamvr-plugin-32647
// Notification : None
//*******************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gripDrag : MonoBehaviour {

    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device device;

    public float throwSpeed = 2.0f;

    // Use this for initialization
    void Start () {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
    }
	
	// Update is called once per frame
	void Update () {
        device = SteamVR_Controller.Input((int)trackedObject.index);
	}

    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.tag == "Cube") {
            //if grip button is pressed down, grab objects
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
            {
                collision.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                collision.collider.transform.SetParent(gameObject.transform, true);  //set worldpositionstay here to true to make sure the object's  world position do not change after set parent
            }
            //if grip button is pressed up, object released
            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
            {
                collision.collider.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                collision.collider.gameObject.transform.SetParent(null);
                TossObject(collision.collider.attachedRigidbody);
            }
        }
    }

    private void TossObject(Rigidbody rigidbody) {
        Transform origin = trackedObject.origin ? trackedObject.origin : trackedObject.transform.parent;
        if (origin != null)
        {
            rigidbody.velocity = origin.TransformVector((device.velocity));
            rigidbody.angularVelocity = origin.TransformVector((device.angularVelocity));
        }
        else   // if the controller's axis does not change ( the same as the cameraRig's world axis)
        {
            rigidbody.velocity = device.velocity;
            rigidbody.angularVelocity = device.angularVelocity;
        }
    }
}
