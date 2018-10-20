using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text nameText;
    public Text dialogueText;
    public Animator animator;

    private Queue<string> sentences;


	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
	}

    //void Update()
   // {
      //  if (Input.GetKeyDown("e") && ItemInfo.eKey == true)
       // {
       //     print("senstences.Count is " +sentences.Count);
       // }
   // }
	
    public void StartDialogue (Dialogue dialogue)
    {
        //Debug.Log("Starting conversation with " + dialogue.name);

        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        //sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count <=0)
        {
            EndDialogue();
            return;
        }
        else
        {

            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
            
        }
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        sentences.Clear();
        animator.SetBool("IsOpen", false);
        
    }
	
}
