using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMgr : MonoBehaviour {

    //AudioSource splashMusicSource;
    AudioClip splashClip;

    public GameObject musicObject;

    private float lengthMod = 0f;

	// Use this for initialization
	void Start () {
        //splashMusicSource = GetComponent<AudioSource>();
        splashClip = musicObject.GetComponent<AudioSource>().clip;
        lengthMod += splashClip.length;
        lengthMod -= 1f;

        Invoke("LoadStart", lengthMod);

	}
	
	

    void LoadStart()
    {
        Application.LoadLevel("Start");
        
    }
}
