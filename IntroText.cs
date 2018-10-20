using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(AudioSource))]
[System.Serializable]
public class IntroText : MonoBehaviour {

    private bool textVisible = false;
    private bool secondTextBool = false;
    private bool stopText = false;
    //private Dialogue dialogue;
    //public Text itemText;
    //public Text myText;
    //public bool isThisXenolith;

    //public GameObject xenolith;
    //public Xenolith xenoScript;


    //private bool eKey = false;
    //private bool stingPlayed = false;
    public AudioClip typeSound;
    //public AudioSource uniqueSound;

    [TextArea(3, 10)]
    public string itemInfo = "Replace";
    public string secondInfo;
    private float startDelay = 0.2f;
    private float typeDelay = 0.03f;
    private AudioSource scribbleSource;


    public string levelString;
    public Text newText;
    //Text secondText;

    /*void Awake()
    {
        newText = GameObject.Find("528TestText").GetComponent<Text>();
    }*/

    void Start()
    {
        scribbleSource = GetComponent<AudioSource>();
        ShowItemText();
    }


    void Update()
    {
        if (secondInfo == null)
        {
            Debug.Log(this + " has a null secondInfo");
        }
        if (Input.GetKeyDown("e"))
        {
            if (textVisible == false) { ShowItemText(); }
            else if (secondTextBool)
            {
                if (stopText)
                {
                    RemoveItemText();
                    Application.LoadLevel(levelString);
                }
                else
                {
                    StartNewCR();
                }
            }
            //gameObject.BroadcastMessage("TriggerDialogue");
        }
        /*if (textVisible && eKey == false)
        {
            Invoke("RemoveItemText", 0.5f);
        }*/
        //commented the above out since we don't need to detect vision in the intro

    }

    void ShowItemText()
    {
        //newText.color = Color.clear;
        newText.color = Color.white;
        //newText.text = itemInfo;
        textVisible = true;
        scribbleSource.PlayOneShot(typeSound);
        StartCoroutine("TypeIn");

        
    }

    void RemoveItemText()
    {

        newText.color = Color.clear;
        textVisible = false;
        secondTextBool = false;
        stopText = false;
        newText.text = "";
        
    }

    /*void OnTriggerEnter(Collider col)
    {
        if (col.tag == "ItemDetector")
        {
            // print("penis");
            //playerInteract = true;
            //print("Success! " + hit);
            //myText.text = "E";
            // myText.color = Color.white;
            if (uniqueSound != null && !stingPlayed)
            {
                uniqueSound.Play();
                stingPlayed = true;
            }
            eKey = true;
            print("eKey is " + eKey);
        }

    }*/

    /*void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "ItemDetector")
        {
            //myText.color = Color.clear;
            eKey = false;
            print("eKey is " + eKey);
            //Invoke("RemoveItemText", 3 * Time.deltaTime);
        }
    }*/

    public IEnumerator TypeIn()
    {
        yield return new WaitForSeconds(startDelay);
        for (int i = 0; i < itemInfo.Length; i++)
        {
            if (i == itemInfo.Length - 1)
            {
                Debug.Log("i is " + i);

                secondTextBool = true;
                scribbleSource.Stop();

            }
            /*if (textVisible && eKey == false)
            {
                Invoke("RemoveItemText", 0.5f);
                break;
            }*/
            newText.text = itemInfo.Substring(0, i);
            //GetComponent<AudioSource>().PlayOneShot(typeSound);
            yield return new WaitForSeconds(typeDelay);
        }
    }

    void StartNewCR()
    {
        scribbleSource.PlayOneShot(typeSound);
        StartCoroutine("TypeSecond");
    }

    public IEnumerator TypeSecond()
    {
        yield return new WaitForSeconds(startDelay);

        for (int a = 0; a <= secondInfo.Length; a++)
        {
            print(a);
            if (a == secondInfo.Length - 1)
            {
                //Debug.Log("i is " + a);
                print("reached if statement");
                scribbleSource.Stop();
                stopText = true;
                //RemoveItemText();

            }
            else if (a == secondInfo.Length && a < 1)
            {

                RemoveItemText();
                break;
            }
            /*if (textVisible && eKey == false)
            {
                Invoke("RemoveItemText", 0.5f);
                break;
            }*/
            newText.text = secondInfo.Substring(0, a);
            //GetComponent<AudioSource>().PlayOneShot(typeSound);
            yield return new WaitForSeconds(typeDelay);
        }
    }
}
