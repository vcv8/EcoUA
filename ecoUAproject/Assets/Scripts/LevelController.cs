using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{	
	private GameController gameController;
    private GeneradorItems generadorItems;

    // Start is called before the first frame update
    void Start()
    {
    	gameController = GetComponent<GameController>();
        generadorItems = GetComponent<GeneradorItems>();
        loadLevel(GameData.loadedLevel);
    }

    public void loadLevel(int nivel){
    	gameController.speed_scrollDown += (0.08f * nivel);
        gameController.maxTimeLevel += (2f * nivel);
        
        if( gameController.maxTimeLevel > 45 ){
            Debug.Log("Maximo tiempo alcanzado");
            gameController.maxTimeLevel = 45;
        }
        
        generadorItems.spawnRate -= (0.06f * nivel);
    }
}
