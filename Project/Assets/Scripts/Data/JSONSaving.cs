using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class JSONSaving : MonoBehaviour
{
    private Highscore highscore;
    private Player player;


    private string path = "";
    private string persistentPath = "";
   
    
    void Start()
    {
        CreatePlayerData();
        SetPaths();        
    }

    private void CreatePlayerData()
    {
        player = new Player();
    }
    
    private void SetPaths()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";

        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }

    private void Update()
    {
        if (Keyboard.current.xKey.wasPressedThisFrame)
            SaveData();
    }

    public void SaveData()
    {
        string savePath = path;

        Debug.Log("Saving Data at " + savePath);
        string json = JsonUtility.ToJson(player);
        Debug.Log(json);

        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
    }

    public void LoadData()
    {
        using StreamReader reader = new StreamReader(path);
        string json = reader.ReadToEnd();

        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
        Debug.Log(data.ToString());
    }



}
