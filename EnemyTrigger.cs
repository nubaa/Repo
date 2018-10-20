using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour {

    public GameObject leech;
    public GameObject endGameText;

    void OnTriggerExit(Collider collider)
    {
        if (GameMgr.xenolithFound && collider.tag == "PlayerFPS")
        {
            leech.SetActive(true);
        }
        if (collider.tag == "ItemDetector")
        {
            Invoke("RemoveText", 2f);
        }
    }

    void OnTriggerEnter(Collider player1)
    {
        

        if (player1.tag == "ItemDetector")
        {
            endGameText.SetActive(true);
            
        }
    }

    

    void RemoveText()
    {
        endGameText.SetActive(false);
    }
}
