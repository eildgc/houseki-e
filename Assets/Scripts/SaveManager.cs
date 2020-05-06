using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;

[System.Serializable]
public class PlayerScore {
    public int enemyTotalDefeated = 0;
    public int gameOverTotal = 0;
}

public class SaveManager : MonoBehaviour
{
    public PlayerScore playerScore = new PlayerScore();
    public delegate void OnLoadCallback();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int IncreaseGameOverCount(){
        playerScore.gameOverTotal += 1;
        Save();
        return playerScore.gameOverTotal;
    }
    public void Save(){
        string fileLocation = Application.persistentDataPath + "/savefile.json";
        FileStream file;

        //Revisar si el archivo ya existe
        if (File.Exists(fileLocation))
        {
            //El archivo ya existe, abrirlo
            file = File.OpenWrite(fileLocation);
        } else {
            //El archivo no existe, crearlo
            file = File.Create(fileLocation);
        }

        // BinaryFormatter binaryFormatter = new BinaryFormatter();
        // binaryFormatter.Serialize(file, gameData);

        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(PlayerScore));
        jsonSerializer.WriteObject(file, playerScore);
        
        file.Close();
        Debug.Log("Saved to location: " + fileLocation);
    }
    public void Load(OnLoadCallback callback){
        string fileLocation = Application.persistentDataPath + "/savefile.json";
        FileStream file;

        if (File.Exists(fileLocation)) {
            //El archivo ya existe, leerlo
            file = File.OpenRead(fileLocation);
        } else {
            //El archivo no existe, error
            Debug.LogError("File not found: " + fileLocation);
            return;
        }

        // BinaryFormatter binaryFormatter = new BinaryFormatter();
        // gameData = (GameData) binaryFormatter.Deserialize(file);

        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(PlayerScore));
        playerScore = (PlayerScore) jsonSerializer.ReadObject(file);

        file.Close();
        Debug.Log("Loaded file: " + fileLocation);

        callback.Invoke();
    }
}
