using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class Lorenzo : MonoBehaviour {

    public Transform lorenzoSpawnPoints;
    public Text bigText;
    public Text smallText;
    public PlayableDirector director;
    //public static bool foundLorenzo = false;

    private Transform[] spawnPoints;

    void Start()
    {
        if (!GameMgr.foundLorenzo)
        {
            spawnPoints = lorenzoSpawnPoints.GetComponentsInChildren<Transform>();
            int i = Random.Range(1, spawnPoints.Length);
            transform.position = spawnPoints[i].transform.position;
        }
    }

    public void ChangeText()
    {
        smallText.text = "Find the plane keys";
        bigText.text = "Find the plane keys";
       // director.enabled = true;
        print("ChangeText() was run.");
        director.Play();
    }
}
