using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    void OnCollisionStay (Collision collision)
    {
        if (collision.gameObject.tag == "enemy") {
            GameMgr.TakeDamage();
        }
    }



    
}
