using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelList : MonoBehaviour
{
	private GameObject[] botones;
	private	GameObject[] medallas;
	private GameData gameData;

	private bool started = false;

	public Sprite[] medSprites;

    void Start()
    {
		creaBotones();

    	botones = GameObject.FindGameObjectsWithTag("blevel");
    	medallas = GameObject.FindGameObjectsWithTag("mlevel");
    	gameData = GameObject.Find("GameController").GetComponent<GameData>();

        rellenaMedallas();
        destapaBotones();

		started = true;
    }

	private void OnEnable() {
		if(started){
			updateBotones();
		}
	}

    public void rellenaMedallas(){
    	int[] scores = gameData.ScoreIntegers;

    	if(medallas.Length > 0){
    		for(int i = 0; i < medallas.Length; i++){
    			//Debug.Log("Medalla "+ i);
    			if(scores[i+1] == 0){
    				medallas[i].GetComponent<Image>().sprite = medSprites[0];
    			}else if(scores[i+1] == 1){
    				medallas[i].GetComponent<Image>().sprite = medSprites[1];
				}else if(scores[i+1] == 2){
					medallas[i].GetComponent<Image>().sprite = medSprites[2];
				}else if(scores[i+1] == 3){
					medallas[i].GetComponent<Image>().sprite = medSprites[3];
				}
    		}
    	}
    }

    public void destapaBotones(){
    	int level = gameData.LevelInteger;

    	if(botones.Length > 0){
    		for(int i = botones.Length-1; i >= level; i--){
    			botones[i].GetComponent<Button>().enabled = false;
    		}
    		for(int i = 0; i < level; i++){
    			botones[i].GetComponent<Button>().enabled = true;
    		}
    	}
    }

	private void creaBotones(){

		if( GameData.idioma ){
			transform.parent.parent.parent.GetComponentInChildren<Text>().text = "Selecciona Nivell";
			transform.parent.parent.parent.GetChild(2).GetComponentInChildren<Text>().text = "Tornar";
		}else{
			transform.parent.parent.parent.GetComponentInChildren<Text>().text = "Selecciona Nivel";
			transform.parent.parent.parent.GetChild(2).GetComponentInChildren<Text>().text = "Volver";
		}

		int numLevels = GameData.totalLevels - 1;
		GameObject boton = transform.GetChild(0).gameObject;

		if( GameData.idioma ){
			boton.GetComponentInChildren<Text>().text = "Nivell 1";
		}else{
			boton.GetComponentInChildren<Text>().text = "Nivel 1";
		}

		for(int i = 2; i <= numLevels; i++){
			GameObject iBoton = (GameObject)Instantiate(boton, transform);
			
			if( GameData.idioma ){
				iBoton.GetComponentInChildren<Text>().text = "Nivell " + i;	
			}else{
				iBoton.GetComponentInChildren<Text>().text = "Nivel " + i;
			}
		}

		GameObject[] btns = GameObject.FindGameObjectsWithTag("blevel");

		for(int i = 0; i < btns.Length; i++){
			int num = i+1;
			btns[i].GetComponent<Button>().onClick.AddListener( delegate { GetComponent<Menu>().toLevel(num); } );
		}
	}

	private void updateBotones(){
		
		if( GameData.idioma ){
			transform.parent.parent.parent.GetComponentInChildren<Text>().text = "Selecciona Nivell";
			transform.parent.parent.parent.GetChild(2).GetComponentInChildren<Text>().text = "Tornar";
		}else{
			transform.parent.parent.parent.GetComponentInChildren<Text>().text = "Selecciona Nivel";
			transform.parent.parent.parent.GetChild(2).GetComponentInChildren<Text>().text = "Volver";
		}

		int numLevels = GameData.totalLevels - 1;
		GameObject boton = transform.GetChild(0).gameObject;

		if( GameData.idioma ){
			boton.GetComponentInChildren<Text>().text = "Nivell 1";
		}else{
			boton.GetComponentInChildren<Text>().text = "Nivel 1";
		}

		for(int i = 2; i <= numLevels; i++){
			GameObject iBoton = transform.GetChild(i -1).gameObject;
			
			if( GameData.idioma ){
				iBoton.GetComponentInChildren<Text>().text = "Nivell " + i;	
			}else{
				iBoton.GetComponentInChildren<Text>().text = "Nivel " + i;
			}
		}
	}
}
