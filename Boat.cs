using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour {

    public float turnSpeed = 300f;
    public float accelSpeed = 500f;
    public AudioSource audioSource;
    public AudioClip boatSound;
    public AudioClip motorOn;
    public AudioClip motorStop;
    
    private Rigidbody rigidBody;
    private bool anyPressed = false;
    private bool nonePressed;

	// Use this for initialization
	void Start () {
        rigidBody = this.GetComponent<Rigidbody>();
        //audioSource.clip = boatSound;
        
	}
	
	// Update is called once per frame
	void Update () {
        float rotate = Input.GetAxis("Horizontal");
        float accelerate = Input.GetAxis("Vertical");

        //are any of the driving keys pressed?
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            //if they weren't previously pressed:
            if (!anyPressed)
            {
                audioSource.clip = motorOn;
                audioSource.Play();
                Invoke("PlayMotor", motorOn.length);
                anyPressed = true;
                nonePressed = false;
            }
        } 

        //this IF is supposed to check if you stop the motor
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            print("Get key up I guess");
            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
            {
                print("inside the if statement");
                //audioSource.Pause();
                audioSource.clip = motorStop;
                audioSource.Play();
                Invoke("StopMotor", motorStop.length);
            }
        }


        //are none of the driving keys pressed?
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            nonePressed = true;
            anyPressed = false;
            print("flip turned upside down");
        }

        rigidBody.AddTorque(0, turnSpeed * Time.deltaTime * rotate, 0);
        rigidBody.AddForce(transform.forward * accelerate * accelSpeed * Time.deltaTime);

	}
    protected void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
    }

    void PlayMotor()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            audioSource.clip = boatSound;
            audioSource.Play();
        }
    }

    void StopMotor()
    {
        if (nonePressed)
        {
            audioSource.Pause();
        }
    }
}
