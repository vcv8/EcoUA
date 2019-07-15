using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaMenu : MonoBehaviour
{
    private AudioSource source;

    void Awake () {
        source = GetComponent<AudioSource>();
    }
    
    void Start() {
        source.Play(0);
    }
}
