using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[RequireComponent(typeof(GameData))]
public class SaveScript : MonoBehaviour {
    private GameData gameData;
    private string savePath;

    private void Start() {
        gameData = GetComponent<GameData>();
        savePath = Application.persistentDataPath + "/scores.save";
    }

    public void SaveData()
    {
        var save = new Save()
        {
            SavedLevel = gameData.LevelInteger,
            SavedScores = gameData.ScoreIntegers,
            SavedLang = GameData.idioma
        };

        var binaryFormatter = new BinaryFormatter();
        using (var fileStream = File.Create(savePath))
        {
            binaryFormatter.Serialize(fileStream, save);
        }

        Debug.Log("Data Saved");
    }

    public void LoadData()
    {
        if (File.Exists(savePath))
        {
            Save save;
 
            var binaryFormatter = new BinaryFormatter();
            using (var fileStream = File.Open(savePath, FileMode.Open))
            {
                save = (Save)binaryFormatter.Deserialize(fileStream);
            }

            if(save.SavedScores.Length < gameData.ScoreIntegers.Length){
                for(int i = 0; i < save.SavedScores.Length; i++){
                    gameData.ScoreIntegers[i] = save.SavedScores[i];
                }
                
            }else{
                gameData.ScoreIntegers = save.SavedScores;
            }
            
            gameData.LevelInteger = save.SavedLevel;
            GameData.idioma = save.SavedLang;

            gameData.ShowData();
    
            Debug.Log("Data Loaded");
            Debug.Log("Idioma " + GameData.idioma);
        }
        else
        {
            Debug.LogWarning("Save file doesn't exist.");
            gameData.CreateData(0, 0);
            SaveData();
        }
    }
}