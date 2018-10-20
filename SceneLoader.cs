using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {

    private bool loadScene = false;

    [SerializeField]
    private int scene;
    [SerializeField]
    private Text loadingText;

    void Start()
    {
        loadScene = true;
        StartCoroutine(LoadNewScene());
    }

    void Update()
    {
        if (loadScene)
        {
            loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));
        }
    }

    IEnumerator LoadNewScene()
    {
        AsyncOperation levelLoad = Application.LoadLevelAsync(scene);
        while (!levelLoad.isDone)
        {
            yield return null;
        }
    }


}
