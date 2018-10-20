using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(AudioSource))]
[System.Serializable]
public class ItemInfo : MonoBehaviour {

    private bool textVisible = false;
    private bool secondTextBool = false;
    private bool stopText = false;
    private AudioSource scribbleSource;
    //private Dialogue dialogue;
    //public Text itemText;
    //public Text myText;
    public bool isThisXenolith;
    public bool isThisKeys;
    
    public GameObject xenolith;
    public GameObject lorenzo;
    public GameObject planeKeys;
    public Xenolith xenoScript;
    public GameMgr gameManager;

    
    private bool eKey = false;
    private bool stingPlayed = false;
    public AudioClip typeSound;
    public AudioSource uniqueSound;

    [TextArea(3, 10)]
    public string itemInfo = "Replace";
    public string secondInfo;
    private float startDelay = 0.2f;
    private float typeDelay = 0.03f;

    //i made newText public and commented out the Awake method. now i can drag and drop as needed.
    Text newText;
    //Text secondText;

    void Awake()
    {
        newText = GameObject.Find("528TestText").GetComponent<Text>();
        scribbleSource = GetComponent<AudioSource>();
    }
    

    void Update() {
        if(secondInfo == null)
        {
            Debug.Log(this + " has a null secondInfo");
        }
        if (Input.GetKeyDown("e"))
        {
            if (eKey == true && textVisible == false) { ShowItemText(); }
            else if (secondTextBool)
            {
                if (stopText)
                {
                    RemoveItemText();
                }
                else
                {
                    StartNewCR();
                }
            }
            //gameObject.BroadcastMessage("TriggerDialogue");
        }
        if (textVisible && eKey == false)
        {
            Invoke("RemoveItemText", 0.5f);
        }
        
    }

    void ShowItemText() {
        //newText.color = Color.clear;
        newText.color = Color.white;
        //newText.text = itemInfo;
        textVisible = true;
        scribbleSource.PlayOneShot(typeSound);
        StartCoroutine("TypeIn");
        if (isThisXenolith)
        {
            xenolith.SetActive(true);
        }
    }

    void RemoveItemText()
    {
        
        newText.color = Color.clear;
        textVisible = false;
        secondTextBool = false;
        stopText = false;
        newText.text = "";
        xenolith.SetActive(false);
        scribbleSource.Stop();
    }

    void OnTriggerEnter(Collider col) {
        if (col.tag == "ItemDetector") {
            // print("penis");
            //playerInteract = true;
            //print("Success! " + hit);
            //myText.text = "E";
            // myText.color = Color.white;
            if(uniqueSound != null && !stingPlayed)
            {
                uniqueSound.Play();
                stingPlayed = true;
            }
            eKey = true;
            print("eKey is " + eKey);
        } 
        
    }

    void OnTriggerExit(Collider collider) {
        if (collider.tag == "ItemDetector") {
            //myText.color = Color.clear;
            eKey = false;
            print("eKey is " + eKey);
            //Invoke("RemoveItemText", 3 * Time.deltaTime);
        }
    }

    public IEnumerator TypeIn()
    {
        yield return new WaitForSeconds(startDelay);
        for(int i = 0; i < itemInfo.Length; i++)
        {
            if (i == itemInfo.Length - 1)
            {
                Debug.Log("i is " + i);
                scribbleSource.Stop();
                secondTextBool = true;
            
            }
            
            if (textVisible && eKey == false)
            {
                Invoke("RemoveItemText", 0.5f);
                scribbleSource.Stop();
                break;
            }
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
                if (isThisXenolith)
                {
                    print("inside if statement");
                    GameMgr.xenolithFound = true;

                    xenoScript.XenoUI();
                    gameManager.PlayerPos();
                } else if (isThisKeys)
                {
                    GameMgr.foundKeys = true;
                    gameManager.PlayerPos();
                }
                if (this.tag == "Lorenzo")
                {
                    GameMgr.foundLorenzo = true;
                    //Invoke("TellLorenzo", 3f);
                    TellLorenzo();
                    print("got to the method in item info");
                }
                if (this.tag == "PlaneKeys")
                {
                    GameMgr.foundKeys = true;
                    //Invoke("TellLorenzo", 3f);
                    TellKeys();
                    print("got to the method in item info");
                }

                scribbleSource.Stop();
                
                stopText = true;
                //RemoveItemText();

            } else if(a==secondInfo.Length && a < 1)
            {
                scribbleSource.Stop();
                
                RemoveItemText();
                
                break;
            }
            if (textVisible && eKey == false)
            {
                Invoke("RemoveItemText", 0.5f);
                scribbleSource.Stop();
                break;
            }
            newText.text = secondInfo.Substring(0, a);
            //GetComponent<AudioSource>().PlayOneShot(typeSound);
            yield return new WaitForSeconds(typeDelay);
        }
    }

    void TellLorenzo()
    {
        lorenzo.GetComponent<Lorenzo>().ChangeText();
    }

    void TellKeys()
    {
        planeKeys.GetComponent<PlaneKeys>().ChangeKeysText();
    }

    //void ShowText()
    // {
    //    myText.text = "E";
    //    myText.color = Color.white;
    //}
}



