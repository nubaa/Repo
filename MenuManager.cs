using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public Text title;
    public GameObject buttons;
    public GameObject controlsMenu;


    void Start()
    {
        Cursor.visible = true;
    }

    public void LoadLevel (string name)
    {
        Cursor.visible = false;
        Application.LoadLevel(name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ControlsDisplay()
    {
        title.enabled = false;
        buttons.SetActive(false);
        controlsMenu.SetActive(true);

    }

    public void ControlsRemove()
    {
        controlsMenu.SetActive(false);
        title.enabled = (true);
        buttons.SetActive(true);
    }
}
