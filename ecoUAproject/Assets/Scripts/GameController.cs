using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public Image scoreEndImage;
    public GameObject botonesFinal;

    //Game over, finish level y tiempos del nivel
    public bool finishLevel;
    public bool finishGen;
    public float maxTimeLevel;
    float currentTimeLevel;
    float introTime;
    private bool startLevel;
    public Sprite[] medallas;


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
        maxScore = 0;
        introTime = 0;
        GameObject.FindWithTag("IntroLevel").GetComponent<Text>().text = "Nivel " + GameData.loadedLevel;
    }

    // Update is called once per frame
    void Update()
    {
        if(!startLevel){
            introTime += Time.deltaTime;
            
            if(introTime > 1.5f && introTime < 2.2f){
                GameObject.Find("LevelTextContainer").GetComponent<Animator>().SetTrigger("DoAnimation");
                if(GameObject.Find("FlechasContainer") != null && GameObject.Find("FlechasContainer").activeSelf){
                    GameObject.Find("FlechasContainer").SetActive(false);
                }
                
            }else if(introTime >= 2.2f){
                //GameObject.Find("FlechasContainer").SetActive(false);
                GetComponent<GeneradorItems>().startGenerator();
                currentTimeLevel = 0;
                startLevel = true;
            }
        }else{
            scoreText.text = score.ToString();

            currentTimeLevel += Time.deltaTime;
            if (currentTimeLevel >= maxTimeLevel)
            {
                finishGen = true;

                object[] basuras = FindObjectsOfType<ElemBasura>();

                // Finalizacion total de nivel
                if(basuras.Length == 0){
                    if(!finishLevel){
                        levelEnd();
                        finishLevel = true;
                    }
                }
            }

            if(Input.GetKeyDown(KeyCode.Escape)){
                SceneManager.LoadScene(0);
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

    private void levelEnd()
    {
        //Cargamos resultados anteriores
        GetComponent<SaveScript>().LoadData();

        levelFinishText.gameObject.SetActive(true);

        GameObject botonNext = botonesFinal.transform.GetChild (0).gameObject;

        if(score < ((maxScore*40)/100)){
            scoreEndImage.sprite = medallas[0];
            //scoreEndText.text = "=(";
            //scoreEndText.color =  new Color(0.5f, 0.5f, 0.5f, 1f);

            botonNext.GetComponent<Button>().onClick.AddListener( delegate{ GameObject.Find("BotonesMenu").GetComponent<Menu>().nextLevel(false); } );

            botonNext.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Reintentar";
            GameObject.Find("levelFinishText").GetComponent<Text>().text = "Nivel fracasado.";

        }else if(score == maxScore){
            scoreEndImage.sprite = medallas[3];
            //scoreEndText.text = "Oro";
            //scoreEndText.color =  new Color(1f, 0.9f, 0.01f, 1f);
            GetComponent<GameData>().CreateData(GameData.loadedLevel, 3);

            botonNext.GetComponent<Button>().onClick.AddListener( delegate{ GameObject.Find("BotonesMenu").GetComponent<Menu>().nextLevel(true); } );
        }else if(score < ((maxScore*70)/100)){
            scoreEndImage.sprite = medallas[1];
            //scoreEndText.text = "Bronce";
            //scoreEndText.color =  new Color(0.7264151f, 0.6003513f, 0.373487f, 1f);
            GetComponent<GameData>().CreateData(GameData.loadedLevel, 1);

            botonNext.GetComponent<Button>().onClick.AddListener( delegate{ GameObject.Find("BotonesMenu").GetComponent<Menu>().nextLevel(true); } );
        }else{
            scoreEndImage.sprite = medallas[2];
            //scoreEndText.text = "Plata";
            //scoreEndText.color =  new Color(0.8679245f, 0.8679245f, 0.8679245f, 1f);
            GetComponent<GameData>().CreateData(GameData.loadedLevel, 2);

            botonNext.GetComponent<Button>().onClick.AddListener( delegate{ GameObject.Find("BotonesMenu").GetComponent<Menu>().nextLevel(true); } );
        }

        //Guardar Resultados
        GetComponent<SaveScript>().SaveData();

        scoreEndImage.gameObject.SetActive(true);
        botonesFinal.SetActive(true);
    }
}
