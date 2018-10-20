using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.PostProcessing;


public class Eyes : MonoBehaviour {

    public float itemSightDist = 3f;
    public Slider sanitySlider;
    public PostProcessingBehaviour xenoPost;
    public PostProcessingProfile normalView;
    public PostProcessingProfile xenoView;
    
    private bool visionOn = false;
    //public static bool playerInteract = false;


    //private Camera fpsCamera;
    //private float defaultFOV;
    
    
    private float sanity = 100f;
    private float sanityLossRate = 4f;
    private float sanityRegenRate = 0.25f;


    // Use this for initialization
    void Start () {
        //fpsCamera = GetComponent<Camera>();
        // defaultFOV = fpsCamera.fieldOfView;
        sanitySlider.value = sanity;
        
        
        
        
	}
	
	// Update is called once per frame
	void Update () {
        //would it be better if I used Vector3.forward? idk
        //RaycastHit hit;
        //Ray itemRay = new Ray(transform.position, transform.forward);
        //Debug.DrawRay(transform.position, transform.forward * itemSightDist );
        //if (Physics.Raycast (itemRay, out hit, itemSightDist))
        sanitySlider.value = sanity;

        if (GameMgr.xenolithFound)
        {
            if (Input.GetKeyDown("q") && !visionOn)
            {
                //gameObject.SendMessage("StartVision");
                xenoPost.profile = xenoView;
                visionOn = true;

            }
            else if (Input.GetKeyDown("q") && visionOn)
            {
                //gameObject.SendMessage("EndVision");
                xenoPost.profile = normalView;
                visionOn = false;
            }

            if (visionOn)
            {
                sanity -= Time.deltaTime * sanityLossRate;
            }

            if (!visionOn && sanity > 0f && sanity < 100f)
            {
                sanity += Time.deltaTime * sanityRegenRate;
            }
        }


        if (sanity <= 0f)
        {
            Application.LoadLevel ("Insanity");
        }
        //print(sanity);
    }

    
}
