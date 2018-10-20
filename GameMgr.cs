using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour {

    private bool gamePaused = false;
    private float fixedTime;
    private static int health = 100;
    

    public static bool xenolithFound;
    
    public static bool foundLorenzo = false;
    public static bool foundKeys;
    public Transform checkPoint;
    public Transform boatCheckPoint;

    public static Vector3 playerVector;
    public static Vector3 boatVector;

    //public GameObject player;
    //public GameObject boat;
    public GameObject pauseMenu;
    public GameObject buttons;
    public GameObject controlsMenu;
    public Transform playerTrans;
    public Transform boatTrans;

    // Use this for initialization
    void Awake()
    {
        pauseMenu.SetActive(false);
        //checkPoint = GameObject.Find("PlayerCP").transform;
        //boatCheckPoint = GameObject.Find("BoatCP").transform;

        if (xenolithFound)
        {

            playerTrans.position = new Vector3(playerVector.x, playerVector.y, playerVector.z);
            boatTrans.position = new Vector3(boatVector.x, boatVector.y, boatVector.z);
            //playerTrans.position = checkPoint.position;
            //boatTrans.position = boatCheckPoint.position;
            
        }
    }

    void Start () {
        print("xenolithFound = " + xenolithFound);

        fixedTime = Time.fixedDeltaTime;
        print(fixedTime);

        
        
	}
	
	// Update is called once per frame
	void Update () {
        

        if (Input.GetKeyDown(KeyCode.Escape) && !gamePaused)
        {
            PauseGame();
            gamePaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && gamePaused) {
            ResumeGame();
            gamePaused = false;
        }

        // this manages your ability to sprint
        /*if (Input.GetKey(KeyCode.LeftShift) && stamina >= 0.5f)
        {
            stamina -= runCost * Time.deltaTime;
            print("stamina is " +stamina);
        }*/

        //this manages your ability to jump
        /*if(Input.GetKey(KeyCode.Space) && stamina >= jumpCost)
        {
            stamina -= jumpCost;
            print("stamina now " + stamina);
        }*/

        // this regenerates stamina
        
	}

    public static void TakeDamage() {
        health = health -= 10;
        if (health <= 0)
        {
            health = 100;
            //xenolithFound = false;
            
            Application.LoadLevel("Death");
            
        }
    }

    

    void PauseGame() {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
        pauseMenu.SetActive(true);
        Cursor.visible = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = fixedTime;
        pauseMenu.SetActive(false);
        ControlsRemove();
        Cursor.visible = false;
        

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ControlsDisplay()
    {
        
        buttons.SetActive(false);
        controlsMenu.SetActive(true);


    }

    public void ControlsRemove()
    {
        
        buttons.SetActive(true);
        controlsMenu.SetActive(false);
    }

    public void PlayerPos()
    {
        //checkPoint.transform.position = new Vector3(playerTrans.position.x, playerTrans.position.y, playerTrans.position.z);
        //boatCheckPoint.transform.position = new Vector3(boatTrans.position.x, boatTrans.position.y, boatTrans.position.z);
        playerVector = new Vector3(playerTrans.position.x, playerTrans.position.y, playerTrans.position.z);
        boatVector = new Vector3(boatTrans.position.x, boatTrans.position.y, boatTrans.position.z);
        print("PlayerPos ran apparently");
    }

    
}
