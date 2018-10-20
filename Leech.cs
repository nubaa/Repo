using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leech : MonoBehaviour {

    private SkinnedMeshRenderer thisCreature;

    void Start()
    {
        thisCreature = GetComponent<SkinnedMeshRenderer>();
        thisCreature.enabled = false;
    }

	
	// Update is called once per frame
	void Update () {
		if(Xenolith.xenoVision == true)
        {
            thisCreature.enabled   = true;
        } else if(Xenolith.xenoVision == false)
        {
            thisCreature.enabled  = false;
        }
        //Debug.Log("xenoVision is " + Xenolith.xenoVision);
	}
}
