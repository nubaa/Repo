using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "PlayerFPS")
        {
            SendMessageUpwards("XenoFindPlayer");
        }
    }
}
