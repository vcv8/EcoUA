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
    private bool completado;

    //Sondio
    public AudioClip levelComp;
    public AudioClip levelFail;
    public AudioClip[] song;
    private AudioSource source;
    private AudioSource finSource;
    private bool faded;

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

        source = GetComponent<AudioSource>();

        int numsongs = song.Length;
        int lev = GameData.loadedLevel;
        while( lev > numsongs ){
            lev -= numsongs;
        }

        source.clip = song[lev-1];
    }

    // Start is called before the first frame update
    void Start()
    {
        currentTimeLevel = 0;
        score = 0;
        maxScore = 0;
        introTime = 0;
        GameObject.FindWithTag("IntroLevel").GetComponent<Text>().text = "Nivel " + GameData.loadedLevel;
        finSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
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
                //Duplicado fuera de canvas
                if(GameObject.Find("Flechas") != null && GameObject.Find("Flechas").activeSelf){
                    GameObject.Find("Flechas").SetActive(false);
                }
                
            }else if(introTime >= 2.2f){
                // Comienza musica
                if(GameData.musica){
                    source.Play(0);
                }

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
                if(SceneManager.GetActiveScene().name != "Menu"){
                    SceneManager.LoadScene(0);
                }
            }
        }

        if(currentTimeLevel >= maxTimeLevel){
            if(!faded){
                faded = true;
                StartCoroutine(FadeOut(0.002f));
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
        // Cargamos resultados anteriores
        GetComponent<SaveScript>().LoadData();

        Debug.Log("loadedlevel " + GameData.loadedLevel);
        Debug.Log("totallevels " + GameData.totalLevels);
        // Crea nuevo nivel si estabamos en el ultimo
        if( GameData.loadedLevel == (GameData.totalLevels-1) ){
            GameData.totalLevels ++;
        }

        Debug.Log("loadedlevel " + GameData.loadedLevel);
        Debug.Log("totallevels " + GameData.totalLevels);

        levelFinishText.gameObject.SetActive(true);

        GameObject botonNext = botonesFinal.transform.GetChild (0).gameObject;

        if(score < ((maxScore*40)/100)){
            scoreEndImage.sprite = medallas[0];

            botonNext.GetComponent<Button>().onClick.AddListener( delegate{ GameObject.Find("BotonesMenu").GetComponent<Menu>().nextLevel(false); } );

            completado = false;
    
            finSource.PlayOneShot(levelFail, 0.2f);

        }else if(score == maxScore){
            scoreEndImage.sprite = medallas[3];
            GetComponent<GameData>().CreateData(GameData.loadedLevel, 3);

            botonNext.GetComponent<Button>().onClick.AddListener( delegate{ GameObject.Find("BotonesMenu").GetComponent<Menu>().nextLevel(true); } );
            completado = true;
            finSource.PlayOneShot(levelComp, 0.2f);
        }else if(score < ((maxScore*70)/100)){
            scoreEndImage.sprite = medallas[1];
            GetComponent<GameData>().CreateData(GameData.loadedLevel, 1);

            botonNext.GetComponent<Button>().onClick.AddListener( delegate{ GameObject.Find("BotonesMenu").GetComponent<Menu>().nextLevel(true); } );
            completado = true;
            finSource.PlayOneShot(levelComp, 0.2f);
        }else{
            scoreEndImage.sprite = medallas[2];
            GetComponent<GameData>().CreateData(GameData.loadedLevel, 2);

            botonNext.GetComponent<Button>().onClick.AddListener( delegate{ GameObject.Find("BotonesMenu").GetComponent<Menu>().nextLevel(true); } );
            completado = true;
            finSource.PlayOneShot(levelComp, 0.2f);
        }

        // Guardar Resultados
        GetComponent<SaveScript>().SaveData();

        scoreEndImage.gameObject.SetActive(true);
        botonesFinal.SetActive(true);

        // Traduce textos de resultado
        GetComponent<TraduceNivel>().traduceContenido(completado);
    }


    // CORUTINA DE SONIDO

    private IEnumerator FadeOut(float speed){

        float audioVolume = source.volume;

        while(source.volume >= 0){
            audioVolume -= speed;
            source.volume = audioVolume;
            yield return new WaitForSeconds (0.1f);
        }
        
        source.Stop();
    }

}
