using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaMenu : MonoBehaviour
{
    private AudioSource source;
    private bool sonando;

    void Awake () {
        source = GetComponent<AudioSource>();
    }
    
    void Start() {
        if(GameData.musica){
            source.Play(0);
        }
    }

    private void Update() {
        if(!GameData.musica){
            if(sonando){
                source.Stop();
                sonando = false;
                GetComponent<SaveScript>().SaveData();
            }
        }else{
            if(!sonando){
                source.Play(0);
                sonando = true;
                GetComponent<SaveScript>().SaveData();
            }
        }
    }
}
