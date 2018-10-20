using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpookySound : MonoBehaviour {

    private AudioClip audioClip;

    private bool didAudioPlay = false;

    

    void OnTriggerEnter(Collider collider) {

        if (collider.tag == "PlayerFPS")
        {
            PlaySpookySound();
        }
        
    }

    void PlaySpookySound() {

        if (didAudioPlay == false) {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            didAudioPlay = true;
        }
    }
}
