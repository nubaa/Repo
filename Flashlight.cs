using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {

    public Transform camera;
    Light light;
    private AudioSource audioSource;

    //private int interval = 4;

	// Use this for initialization
	void Start () {
        light = GetComponentInChildren<Light>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
       /* if (Time.frameCount % interval == 0)
        {
            transform.rotation = camera.rotation;
        }*/
        if (Input.GetKeyDown(KeyCode.F))
        {
            light.enabled = !light.enabled;
            audioSource.Play();
        }
	}
}
