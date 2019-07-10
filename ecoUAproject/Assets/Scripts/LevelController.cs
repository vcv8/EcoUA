using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{	
	private GameController gameController;


    // Start is called before the first frame update
    void Start()
    {
    	gameController = GetComponent<GameController>();
        loadLevel(GameData.loadedLevel);
    }

    public void loadLevel(int nivel){
    	gameController.speed_scrollDown += (0.1f * nivel);
    	gameController.maxTimeLevel += (2f * nivel);
    }
}
