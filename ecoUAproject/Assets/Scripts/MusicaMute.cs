using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicaMute : MonoBehaviour
{
    public Sprite off;
    public Sprite on;
    private void Start() {
        if(GameData.musica){
            GetComponent<Image>().sprite = on;
        }else{
            GetComponent<Image>().sprite = off;
        }
    }
    public void onMute(){
        if(GameData.musica){
            GameData.musica = false;
            GetComponent<Image>().sprite = off;
        }else{
            GameData.musica = true;
            GetComponent<Image>().sprite = on;
        }
    }
}
