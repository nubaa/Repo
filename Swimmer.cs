using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;
using UnityStandardAssets.Characters.FirstPerson;

public class Swimmer : MonoBehaviour {
    //CharacterController cc;
    //public FirstPersonController fpc;

    //private float waterWalk;
   // private float waterRun;
   // private float landWalk;
   // private float landRun;
    

    // Use this for initialization
    void Start () {
       // RenderSettings.fog = false;
        //RenderSettings.fogColor = new Color(0.15f, 0.1f, 0.05f, 0.3f);
        //RenderSettings.fogDensity = 0.15f;

        //the above 3 lines should be turned back on, fixing fog

        //fpc = GetComponent<FirstPersonController>();
        //waterWalk = fpc.m_WalkSpeed  / 2f;
       // waterRun = fpc.m_RunSpeed / 2f;
       // landWalk = fpc.m_WalkSpeed;
       // landRun = fpc.m_RunSpeed;
        
    }
	
    bool IsUnderwater()
    {
        return gameObject.transform.position.y < 47.25f;
    }

    bool IsOutOfWater()
    {
        return gameObject.transform.position.y >= 48.5f;
    }
	// Update is called once per frame
	void Update () {
       // RenderSettings.fog = IsUnderwater();
       //the above line should be turned back on, trying to fix fog

        /*if(IsUnderwater())
        {
           // fpc.m_WalkSpeed = waterWalk;
           // fpc.m_RunSpeed = waterRun;
           /// fpc.m_StickToGroundForce = 0f;

          // if(Input.GetKey  (KeyCode.T)&& gameObject.transform.position.y <47)
           // {
           //     Debug.Log("T was anyPressed");
           //     fpc.m_GravityMultiplier = 0f;
           //     fpc.m_StickToGroundForce = 0f;
           //     fpc.m_MoveDir.y += 0.25f;
                
           // }
            
        }
        //else if (IsOutOfWater ())
        //{
        //    
        //}*/
	}

   /* void OnTriggerExit (Collider col)
    {
        if(col.tag == "Water")
        {
           // fpc.m_WalkSpeed = landWalk;
           // fpc.m_RunSpeed = landRun;
           // fpc.m_StickToGroundForce = 10f;
          //  fpc.m_GravityMultiplier = 2f;
            //fpc.m_MoveDir.y -= 10f;
        }
    }*/
}
