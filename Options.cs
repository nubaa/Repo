using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour {

    public float gammaCorrection;
    
    // Use this for initialization
	void Start () {
        RenderSettings.ambientLight = new Color(gammaCorrection, gammaCorrection, gammaCorrection, 1f);
        //RenderSettings.ambientSkyColor = new Color(gammaCorrection, gammaCorrection, gammaCorrection, 1f);
    }
	
	
}
