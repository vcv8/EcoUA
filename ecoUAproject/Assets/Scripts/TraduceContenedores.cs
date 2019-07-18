using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TraduceContenedores : MonoBehaviour
{
    public int contentSize;
    private bool started = false;
    private string[] traducciones;
    private string[] originales;

    private void Start() {
        originales = new string[contentSize];
        traducciones = new string[contentSize];

        originales[0]   = "Envases de plástico, latas y bricks.";
        traducciones[0] = "Envasos de plàstic, llandes i bricks.";
        originales[1]   = "Papel y cartón.";
        traducciones[1] = "Paper y cartó.";
        originales[2]   = "Vidrio.";
        traducciones[2] = "Vidre.";
        originales[3]   = "Orgánico.";
        traducciones[3] = "Orgànic.";
        originales[4]   = "Resto.";
        traducciones[4] = "Altres.";

        traduceContenido();
        started = true;
    }

    private void OnEnable() {
        if(started){
            traduceContenido();
        }
    }

    private void traduceContenido(){
        if( GameData.idioma ){
            transform.GetComponentInChildren<Text>().text = "Contenidors";
            transform.GetChild(2).gameObject.GetComponentInChildren<Text>().text = "Tornar";
        }else{
            transform.GetComponentInChildren<Text>().text = "Contenedores";
            transform.GetChild(2).gameObject.GetComponentInChildren<Text>().text = "Volver";
        }

        GameObject contenido = transform.GetChild(1).GetChild(0).GetChild(0).gameObject;

        for(int i = 0; i < contentSize; i++){
            GameObject elem = contenido.transform.GetChild(i).gameObject;

            if( GameData.idioma ){
                elem.GetComponentInChildren<Text>().text = traducciones[i];
            }else{
                elem.GetComponentInChildren<Text>().text = originales[i];
            }
        }
    }
}
