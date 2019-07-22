using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TraduceNivel : MonoBehaviour
{
    private void Start() {
        if( GameData.idioma ){
            GameObject.Find("LevelTextContainer").GetComponentInChildren<Text>().text = "Nivell " + GameData.loadedLevel;
        }
    }

    public void traduceContenido(bool completado){
        GameObject menu = GameObject.Find("BotonesMenu");
        GameObject tFinal = GameObject.Find("levelFinishText");
        
        if(completado){
            if( GameData.idioma ){
                menu.transform.GetChild(0).GetComponentInChildren<Text>().text = "Següent Nivell";
                menu.transform.GetChild(1).GetComponentInChildren<Text>().text = "Tornar al Menú";
                tFinal.GetComponent<Text>().text = "Aconseguit!";
            }
        }else{
            if( GameData.idioma ){
                menu.transform.GetChild(0).GetComponentInChildren<Text>().text = "Reintentar";
                menu.transform.GetChild(1).GetComponentInChildren<Text>().text = "Tornar al Menú";
                tFinal.GetComponent<Text>().text = "Has fallat.";
            }else{
                menu.transform.GetChild(0).GetComponentInChildren<Text>().text = "Reintentar";
                tFinal.GetComponent<Text>().text = "Has fallado.";
            }
        }
        
    }
}