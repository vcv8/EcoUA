using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelList : MonoBehaviour
{
	private GameObject[] botones;
	private	GameObject[] medallas;
	private GameData gameData;

	public Sprite[] medSprites;


    // Start is called before the first frame update
    void Start()
    {
    	botones = GameObject.FindGameObjectsWithTag("blevel");
    	medallas = GameObject.FindGameObjectsWithTag("mlevel");
    	gameData = GameObject.Find("GameController").GetComponent<GameData>();

        rellenaMedallas();
        destapaBotones();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
