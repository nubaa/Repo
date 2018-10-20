using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    public float fadeInTime;
    public float startDelay;

    private Image introPanel;
    private Color currentColor = Color.black;

	// Use this for initialization
	void Start () {
        introPanel = GetComponent<Image>();

	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad >= startDelay)
        {
            if (Time.timeSinceLevelLoad - startDelay < fadeInTime)
            {
                float alphaChange = Time.deltaTime / fadeInTime;
                currentColor.a -= alphaChange;
                introPanel.color = currentColor;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        
	}
}
