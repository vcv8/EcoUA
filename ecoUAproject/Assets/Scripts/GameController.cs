using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static GameController instance; //Para acceder desde cualquier clase a esta clase GameController, es como un Singleton

    //Variables globales
    public float speed_scrollDown; //velocidad de caida de la basura
    public Vector2 limitSpawnX; //Limite en x para la instanciacion de los objetos+

    //Textos
    public int score;
    public int  maxScore;
    public Text scoreText;
    public Text levelFinishText;
    public Text scoreEndText;

    //Game over, finish level y tiempos del nivel
    public bool finishLevel;
    public bool finishGen;
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
        score = 0;
        float maxScoref = maxTimeLevel/GetComponent<GeneradorItems>().spawnRate;
        if((maxTimeLevel%GetComponent<GeneradorItems>().spawnRate) != 0f){
            maxScore = (int) maxScoref+1;
        }else{
            maxScore = (int) maxScoref;
        }
        Debug.Log(maxScore);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();

        currentTimeLevel += Time.deltaTime;
        if (currentTimeLevel >= maxTimeLevel)
        {
            finishGen = true;

            object[] basuras = FindObjectsOfType<ElemBasura>();

            if(basuras.Length == 0){
                finishLevel = true;
                levelFinishText.gameObject.SetActive(true);
                if(score == maxScore){
                    scoreEndText.text = "Oro";
                    scoreEndText.color =  new Color(1f, 0.9f, 0.01f, 1f);
                }else if(score < ((maxScore*80)/100)){
                    scoreEndText.text = "Bronce";
                    scoreEndText.color =  new Color(0.7264151f, 0.6003513f, 0.373487f, 1f);
                }else{
                    scoreEndText.text = "Plata";
                    scoreEndText.color =  new Color(0.8679245f, 0.8679245f, 0.8679245f, 1f);
                }
                scoreEndText.gameObject.SetActive(true);
            }
        }
    }

    private void OnDestroy()
    {
        if (GameController.instance == this)
        {
            GameController.instance = null;
        }
    }
}
