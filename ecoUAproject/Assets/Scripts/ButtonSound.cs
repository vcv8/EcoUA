using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioClip pressButtonSound;
    private AudioSource source;

    void Awake () {
        source = GetComponent<AudioSource>();
    }

    public void playSound(){
        source.PlayOneShot(pressButtonSound, 0.5f);
    }
}
