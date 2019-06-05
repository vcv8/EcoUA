using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorItems : MonoBehaviour
{
    public GameObject[] allBasuraItems;

    public float spawnRate; //Tasa a la que aparecen los items barua
    private float timeSinceLastSpawnBasura; //Tiempo entre una basura y la siguiente

    void Start()
    {
        timeSinceLastSpawnBasura = spawnRate;
    }

    void Update()
    {
        timeSinceLastSpawnBasura += Time.deltaTime; //Vamos comprobando y actualizando el tiempo 
        if (timeSinceLastSpawnBasura >= spawnRate && !GameController.instance.finishLevel) //Entra cada vez que se supere SpawnRate
        {
            GameObject itemBasura = allBasuraItems[Random.Range(0, allBasuraItems.Length)]; //Objeto aleatorio 
            float spawnXPosition = Random.Range(GameController.instance.limitSpawnX.x, GameController.instance.limitSpawnX.y); //Posicion aleatoria

            Instantiate(itemBasura, new Vector2(spawnXPosition, 6.0f), Quaternion.identity); //Instanciamos objeto

            timeSinceLastSpawnBasura = 0;
        }
    }
}
