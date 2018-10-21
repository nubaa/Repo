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
		thisCreature.enabled = Xenolith.xenoVision
        //Debug.Log("xenoVision is " + Xenolith.xenoVision);
	}
}
