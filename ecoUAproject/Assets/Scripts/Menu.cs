﻿using System.Collections;
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
                go = GameObject.Find("LevelSelector");
                if(go != null && go.activeSelf){
                    if(Input.GetKeyDown(KeyCode.Escape)){
                        ShowMenu();
                    }
                }
            }
        }
    }

    public void StartLevel()
    {
    	GameData.loadedLevel = GameObject.Find("GameController").GetComponent<GameData>().LevelInteger;
        SceneManager.LoadScene(1);
    }

    public void toLevel(int nivel)
    {
    	if(GameObject.Find("GameController").GetComponent<GameData>().LevelInteger >= nivel){
    		GameData.loadedLevel = nivel;
        	SceneManager.LoadScene(1);
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
