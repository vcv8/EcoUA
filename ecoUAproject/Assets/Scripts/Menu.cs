using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

	public void Start()
    {
    	GameObject gController = GameObject.Find("GameController");
		gController.GetComponent<SaveScript>().LoadData();
		gController.GetComponent<GameData>().ShowData();
    }

    public void Update() {
        if( SceneManager.GetActiveScene().name == "Menu" ) {
            GameObject go = GameObject.Find("BotonesMenu");
            if(go != null && go.activeSelf){
                if(Input.GetKeyDown(KeyCode.Escape)){
                    QuitGame();
                }
            }else{
                //go = GameObject.Find("LevelSelector");
                //if(go != null && go.activeSelf){
                    if(Input.GetKeyDown(KeyCode.Escape)){
                        ShowMenu();
                    }
                //}
            }
        }
    }

    public void StartLevel()
    {
    	GameData.loadedLevel = GameObject.Find("GameController").GetComponent<GameData>().LevelInteger;
        loadLevel();
    }

    public void nextLevel(bool next)
    {        
        GameData gd = GameObject.Find("GameController").GetComponent<GameData>();

        if(next){
            //Debug.Log("Avanzmaos a nivel que sigue a " + GameData.loadedLevel);
            
            if( gd.LevelInteger >= (GameData.loadedLevel+1) ) {
    		    GameData.loadedLevel++;
        	    loadLevel();
    	    }
        }else{
            restartLevel();
        }
    	
    }

    public void restartLevel()
    {
        //Debug.Log("Avanzmaos a nivel" + GameData.loadedLevel);
        loadLevel();
    }

    public void toLevel(int nivel)
    {
    	if(GameObject.Find("GameController").GetComponent<GameData>().LevelInteger >= nivel){
    		GameData.loadedLevel = nivel;
        	loadLevel();
    	}
    }

    private void loadLevel(){
        int loadLvl = GameData.loadedLevel;
        int maxScenes = 25;

        while(loadLvl > maxScenes){
            loadLvl -= maxScenes;
        }

        if(loadLvl <= 5){
            SceneManager.LoadScene(1);
        } else if(loadLvl > 5 && loadLvl <= 10) {
            SceneManager.LoadScene(2);
        } else if(loadLvl > 10 && loadLvl <= 15) {
            SceneManager.LoadScene(3);
        } else if(loadLvl > 15 && loadLvl <= 20) {
            SceneManager.LoadScene(4);
        } else if(loadLvl > 20 && loadLvl <= 25) {
            SceneManager.LoadScene(5);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Game Exited.");
        Application.Quit();
    }

    public void ShowMenu()
    {
        SceneManager.LoadScene(0);
    }
}
