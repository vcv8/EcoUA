using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TraduceCreditos : MonoBehaviour
{
    private bool started = false;

    private void Start() {

        traduceContenido();
        started = true;
    }

    private void OnEnable() {
        if(started){
            traduceContenido();
        }
    }

    private void traduceContenido(){
        GameObject contenido = transform.GetChild(1).GetChild(0).GetChild(0).gameObject;
        
        if( GameData.idioma ){
            transform.GetComponentInChildren<Text>().text = "Crèdits";
            transform.GetChild(2).gameObject.GetComponentInChildren<Text>().text = "Tornar";

            // Categoria 1
            contenido.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Desenvolupament";
            
            // Categoria 2
            contenido.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Idea Original";

            // Categoria 3
            contenido.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "En col·laboració amb";

            // Categoria 4
            contenido.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = "Atribucions";
            contenido.transform.GetChild(4).GetChild(1).GetComponent<Text>().text = "Neim Beats - Música de Nivells\n(Beautiful, Blue fire, Babylon)";

            // Atribuciones 2
            contenido.transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "LittleRobotSoundFactory - So d'Encert\n(Jingle_Win_Synth_02)";
        }else{
            transform.GetComponentInChildren<Text>().text = "Créditos";
            transform.GetChild(2).gameObject.GetComponentInChildren<Text>().text = "Volver";

            // Categoria 1
            contenido.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Diseño y Desarrollo";
            
            // Categoria 2
            contenido.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Idea Original";

            // Categoria 3
            contenido.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "En colaboración con";

            // Categoria 4
            contenido.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = "Atribuciones";
            contenido.transform.GetChild(4).GetChild(1).GetComponent<Text>().text = "Neim Beats - Música de Niveles\n(Beautiful, Blue fire, Babylon)";

            // Atribuciones 2
            contenido.transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "LittleRobotSoundFactory - Sonido de Acierto\n(Jingle_Win_Synth_02)";
        }
    }
}
