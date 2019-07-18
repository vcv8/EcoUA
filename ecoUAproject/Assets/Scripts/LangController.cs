using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LangController : MonoBehaviour
{
    private void Start() {
        UpdateTexts();
    }

    public void CambiaIdioma(){
        if(GameData.idioma){
            GameData.idioma = false;
        }else{
            GameData.idioma = true;
        }

        UpdateTexts();
        GetComponent<SaveScript>().SaveData();
    }

    // Modifica el idioma con el que se muestran los textos del juego.
    public void UpdateTexts(){
        // Traduccion Menu
        if( SceneManager.GetActiveScene().name == "Menu" ){

            Debug.Log("inMENU");

            if(GameData.idioma){
                GameObject.Find("BotonIdioma").GetComponentInChildren<Text>().text = "Jugar en castellano";
                GameObject.Find("BotonJugar").GetComponentInChildren<Text>().text = "A reciclar!";
                GameObject.Find("BotonNiveles").GetComponentInChildren<Text>().text = "Llista de Nivells";
                GameObject.Find("Level").GetComponent<Text>().text = "Nivell " + GetComponent<GameData>().LevelInteger;
            }else{
                GameObject.Find("BotonIdioma").GetComponentInChildren<Text>().text = "Jugar en valencià";
                GameObject.Find("BotonJugar").GetComponentInChildren<Text>().text = "¡A reciclar!";
                GameObject.Find("BotonNiveles").GetComponentInChildren<Text>().text = "Lista de Niveles";
                GameObject.Find("Level").GetComponent<Text>().text = "Nivel " + GetComponent<GameData>().LevelInteger;
            }


        //Traduccion Niveles
        }else{

        }
    }
}
