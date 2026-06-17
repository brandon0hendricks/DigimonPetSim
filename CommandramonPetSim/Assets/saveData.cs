using System.IO;
using UnityEngine;

public class saveData : MonoBehaviour
{

    public DigimonInformation digimonInformation;
    private string saveFilePath;
    public static saveData instance;

    private void Awake()
    {
        digimonInformation = DigimonController.instance.digimonInformation;
        LoadGame();
        // Set the file path for saving the data
        saveFilePath = Application.persistentDataPath + "/digimonData.json";
    }
    public void SaveGame()
    {
        GameData data = new GameData();

        data.level = digimonInformation.level;
        data.portrait = digimonInformation.portrait;
        data.exp = digimonInformation.exp;
        data.currentForm = digimonInformation.currentForm;
        data.chaos = digimonInformation.chaos;
        data.order = digimonInformation.order;

        // Convert to JSON and save
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(saveFilePath, json);


        Debug.Log("Game saved to: " + saveFilePath);
    }

    public void LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            GameData data = JsonUtility.FromJson<GameData>(json);
            digimonInformation.level = data.level;
            digimonInformation.portrait = data.portrait;
            digimonInformation.exp = data.exp;
            digimonInformation.currentForm = data.currentForm;
            digimonInformation.chaos = data.chaos;
            digimonInformation.order = data.order;
            Debug.Log("Game loaded from: " + saveFilePath);
        }
        else
        {
            Debug.LogWarning("No save file found at: " + saveFilePath);
        }
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}



[System.Serializable]
public class GameData
{
    //basic information about the digimon
    public int level;
    public Sprite portrait;
    public int exp;
    public string currentForm;

    //used to detirmine next evolution
    public int chaos;
    public int order;
}