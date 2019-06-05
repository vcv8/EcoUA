using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController instance; //Para acceder desde cualquier clase a esta clase GameController, es como un Singleton

    public float speed_scrollDown; //velocidad de caida de la basura
    public Vector2 limitSpawnX; //Limite en x para la instanciacion de los objetos

    public bool gameOver;
    public bool finishLevel;
    public float maxTimeLevel;
    float currentTimeLevel;

    private void Awake()
    {
        if (GameController.instance == null)
        {
            GameController.instance = this;

        }
        else
        {
            Destroy(gameObject);
            Debug.LogWarning("GameController ha sido instanciado por segunda vez. Esto no debería pasar nunca pero por si acaso");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentTimeLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentTimeLevel += Time.deltaTime;
        if (currentTimeLevel >= maxTimeLevel)
        {
            finishLevel = true;
        }
    }

    private void OnDestroy()
    {
        if (GameController.instance == this)
        {
            GameController.instance = null;
        }
    }

    public void TriggeredCollision(GameObject basura, bool valor)
    {
        Destroy(basura);
        Debug.Log ("Acierto?" + valor);
    }
}
