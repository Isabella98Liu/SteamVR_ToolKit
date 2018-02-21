//******************************************************************************************************
// Latest Update : 2/14/2018
// Author : Isabella Liu
// this scrip should be attached to all SteamVR [controller]
// Function : enable correspond animation when user activate several buttons
//            [Fist Hold]      -->    Grip Button
//            [Finger Point]   -->    Trigger Button
// SDK Requirement : [SteamVR Plugin] https://assetstore.unity.com/packages/templates/systems/steamvr-plugin-32647
//                   [Realistic VR Hand] https://assetstore.unity.com/packages/3d/characters/realistic-vr-hands-90046
// Notification : same name trigger of animator should be set, transaction should be set in animator inspector
//*******************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller_hand_animation : MonoBehaviour {

    public GameObject handModel;

    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;   //gripButton Setting
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;    //triggerButton Setting

    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device device;
    

	// Use this for initialization
	void Start () {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
	}

	// Update is called once per frame
	void FixedUpdate () {
        device = SteamVR_Controller.Input((int)trackedObject.index);
        if (device.GetPress(triggerButton))
            FingerPut();
        else  FingerUnput();
        if (device.GetPress(gripButton))
            FistHold();
        else FistUnhold();       
	}

    void FistHold() {
        handModel.GetComponent<Animator>().ResetTrigger("gripButtonUnpressed");
        handModel.GetComponent<Animator>().SetTrigger("gripButtonPressed");
    }

    void FistUnhold() {
        handModel.GetComponent<Animator>().ResetTrigger("gripButtonPressed");
        handModel.GetComponent<Animator>().SetTrigger("gripButtonUnpressed");
    }

    void FingerPut() {
        handModel.GetComponent<Animator>().ResetTrigger("triggerButtonUnpressed");
        handModel.GetComponent<Animator>().SetTrigger("triggerButtonPressed");
    }

    void FingerUnput()
    {
        handModel.GetComponent<Animator>().ResetTrigger("triggerButtonPressed");
        handModel.GetComponent<Animator>().SetTrigger("triggerButtonUnpressed");
    }
}


