using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour {
    public int LevelInteger { get; set; }
    public int[] ScoreIntegers { get; set; }
    public static int totalLevels = 31; // Numero total de niveles jugables + 1
    public static int loadedLevel = 0;  // Nivel que va a cargarse en la escena de nivel
    public static bool idioma = false;  // Idioma de textos del juego. 0:Castellano 1:Valenciano
    public static bool musica = true;   // True: Se reproduce musica. False: No se reproduce musica.

    [SerializeField]
    private Text textLevel;
    //[SerializeField]
    //private Text textScore;

    private void Start() {
        UpdateData();
    }

    public void CreateData(int level, int score)
    {
        if(level+1 > LevelInteger){
            if(level+1 < ScoreIntegers.Length){
                LevelInteger = level+1;
            }
        }
        if(score > ScoreIntegers[level]){
            ScoreIntegers[level] = score;
        }
    }

    public void ShowData()
    {
        //METODO DESFASADO
        if( SceneManager.GetActiveScene().name == "Menu" ) {
            //textLevel.text = "Nivel " + LevelInteger.ToString();
            //textScore.text = ScoreIntegers[LevelInteger].ToString();
        }else{
            Debug.Log("No place to show data.");
        }
    }

    public void UpdateData(){
        ScoreIntegers = new int[totalLevels]; 
    }
}