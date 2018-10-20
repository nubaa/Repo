using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class PlaneKeys : MonoBehaviour {

    public Text bigText;
    public Text smallText;
    public PlayableDirector director;

    public void ChangeKeysText()
    {
        smallText.text = "Head upriver to the plane";
        bigText.text = "Get to the plane and escape";
        director.Play();
    }
}
