using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Xenolith : MonoBehaviour {

    AudioSource audioSource;
    public static bool xenoVision = false;
    //public GameObject xenoObject;
    //public Transform uiPosition;
    //public Light spookyLight;
    public GameObject xenoTooltip;
    //public GameObject physicalXenolith;
    public GameObject xenoNormal;
    public GameObject xenoActive;
    //public GameMgr gameManager;



    float xenoIntensity = 4f;
    float xenoBaseLine = 2f;
    //public bool isVisionOn = false;
    //public GameObject monsterTest;

    //private Image stone;

	// Use this for initialization
	void Start () {

        // stone = GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();
        RemoveVision();
        
	}

    // Update is called once per frame
    void Update()
    {
        if (GameMgr.xenolithFound)
        {
            if (Input.GetKeyDown("q"))
            {
                
                if (xenoVision)
                {
                    RemoveVision();
                }
                else
                {
                    //stone.enabled = true;
                    //isVisionOn = true;
                    xenoVision = true;
                    xenoActive.SetActive(true);
                    
                    //audioSource.Play();
                    audioSource.mute = false;
                    //monsterTest.SetActive(true);
                   // spookyLight.intensity = xenoIntensity;
                }

            }
        }
    }

    public void XenoUI()
    {

        //xenoObject.transform.SetParent(uiPosition);
        //xenoObject.transform.position = uiPosition.transform.position;
        //xenoObject.transform.rotation = uiPosition.transform.rotation;
        //physicalXenolith.SetActive(false);
        xenoTooltip.SetActive(true);
        xenoNormal.SetActive(true);
        
        Invoke("StopXenoTip", 6f);
        //gameManager.PlayerPos();

    }

    

    void StopXenoTip()
    {
        xenoTooltip.SetActive(false);
    }

    void RemoveVision()
    {
        //stone.enabled = false;
       // isVisionOn  = false;
        xenoVision = false;
        //audioSource.Pause();
        audioSource.mute = true;
        xenoActive.SetActive(false);
        //spookyLight.intensity = xenoBaseLine;
        //monsterTest.SetActive(false);
        
    }
}
