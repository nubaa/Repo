using Assets.SwimmingSystem.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;

public class SwitchMode : MonoBehaviour {

    public GameObject boat;
    public GameObject boatMultiRig;
    public GameObject player;
    public GameObject playerStartPos;
    public GameObject flashlight;
    public Camera fpsCamera;
    public Camera boatCamera;
    public CapsuleCollider fpsCapsule;

    //private MouseLook boatMouse;





    public FirstPersonController fpsScript;
    public Swim swimScript;
    private bool nextToBoat;
    public static bool drivingBoat = false;
    


	// Use this for initialization
	void Start () {
        
        FPSMode();
        fpsScript = player.GetComponent<FirstPersonController>();
	}
	
	// Update is called once per frame
	void Update () {
        //set to boat mode//
        if (Input.GetKeyDown("1")&& nextToBoat == true && !drivingBoat)
        {
            DriveBoat();
            //print("drive mode");
        }
        //set to first person mode//
        else if (Input.GetKeyDown("1") && drivingBoat == true )
        {
            FPSMode();
            //print("fps mode");

        }
        if (drivingBoat)
        {
            player.transform.position = playerStartPos.transform.position;
            //RotateBoatView();
        }
        //boatMouse.UpdateCursorLock();




    }

    void OnTriggerStay(Collider theCollision)
    {
        //print("Trigger stay");
        if (theCollision.gameObject.tag == "BoatDetector")
        {
            nextToBoat = true;
            print(nextToBoat);
        

    }

    }

    void OnTriggerExit(Collider exitCollision)
    {
        if (exitCollision.gameObject.tag == "BoatDetector")
        {
            nextToBoat = false;
            //print(nextToBoat);
    
    }


    }

    void DriveBoat()
    {
        //build if statement to detect collision here!!!!

        //boatMouse.Init(transform, boatCamera.transform );
        flashlight.SetActive(false);
        boat.GetComponent<Rigidbody>().isKinematic = false;
        boat.GetComponent<Boat>().enabled = true;
        boatMultiRig.SetActive(true);
        fpsCamera.enabled = false;
        fpsCapsule.enabled = false;
        //player.SetActive(false);
        fpsScript.enabled = false;
        drivingBoat = true;
        player.GetComponent<Swim>().GetOutWater();
        player.GetComponent<Swim>().CalledExitWater();
        
    }

    void FPSMode()
    {

        flashlight.SetActive(true);
        boat.GetComponent<Rigidbody>().isKinematic = true;
        boat.GetComponent<Boat>().enabled = false;
        boatMultiRig.SetActive(false);
        fpsCamera.enabled = true;
        fpsCapsule.enabled = true;
        //player.SetActive(true);
        fpsScript.enabled = true;
        player.transform.position = playerStartPos.transform.position;
        drivingBoat = false;
        //player.transform.rotation = boat.transform.rotation;
        print("fps mode engaged");

    }

    //

}
