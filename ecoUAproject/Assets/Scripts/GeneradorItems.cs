using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorItems : MonoBehaviour
{
    public GameObject[] allBasuraItems;

    public float spawnRate; //Tasa a la que aparecen los items basura
    private float timeSinceLastSpawnBasura; //Tiempo entre una basura y la siguiente
    private bool started;

    void Start()
    {
        timeSinceLastSpawnBasura = spawnRate;
        started = false;
    }

    void Update()
    {
        if(started){
            timeSinceLastSpawnBasura += Time.deltaTime; //Vamos comprobando y actualizando el tiempo 
            if (timeSinceLastSpawnBasura >= spawnRate && !GameController.instance.finishGen) //Entra cada vez que se supere SpawnRate
            {
                GameObject itemBasura = allBasuraItems[Random.Range(0, allBasuraItems.Length)]; //Objeto aleatorio 
                float spawnXPosition = Random.Range(GameController.instance.limitSpawnX.x, GameController.instance.limitSpawnX.y); //Posicion aleatoria

                Instantiate(itemBasura, new Vector2(spawnXPosition, 6.0f), Quaternion.identity); //Instanciamos objeto

                timeSinceLastSpawnBasura = 0;

                GetComponent<GameController>().maxScore += 1;
            }
        }
    }

    public void startGenerator(){
        started = true;
    }
}
