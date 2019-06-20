using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour {
    public int LevelInteger { get; set; }
    public int[] ScoreIntegers { get; set; }
    public int  totalLevels;

    [SerializeField]
    private Text textLevel;
    [SerializeField]
    private Text textScore;

    private void Start() {
        ScoreIntegers = new int[totalLevels];    
    }

    public void CreateData(int level, int score)
    {
        LevelInteger = level;
        ScoreIntegers[level] = score;
    }

    public void ShowData()
    {
        textLevel.text = LevelInteger.ToString();
        textScore.text = ScoreIntegers[LevelInteger].ToString();
    }
}