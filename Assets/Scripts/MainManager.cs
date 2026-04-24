using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private static MainManager instance;
    public static MainManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }

    public Color TeamColor = Color.white;

    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;

        string json = JsonUtility.ToJson(data);
        Debug.Log(json);
        PlayerPrefs.SetString("saveData", json);

        //PlayerPrefs.SetFloat("teamColor.a", TeamColor.a);
        //PlayerPrefs.SetFloat("teamColor.r", TeamColor.r);
        //PlayerPrefs.SetFloat("teamColor.g", TeamColor.g);
        //PlayerPrefs.SetFloat("teamColor.b", TeamColor.b);
    }

    public void LoadColor()
    {
        //string json = PlayerPrefs.GetString("saveData");
        //Debug.Log(json);
        //SaveData data = JsonUtility.FromJson<SaveData>(json);
        //TeamColor = data.TeamColor;

        string p = Application.persistentDataPath; //"C:\\Users\\User";
        string fileName = "savefile.json";
        string fullPath = Path.Combine(p, fileName);
        if (File.Exists(fullPath))
        {
            string json = PlayerPrefs.GetString("saveData");
            Debug.Log(json);

            SaveData data = JsonUtility.FromJson<SaveData>(json);
            File.WriteAllText(fullPath, fileName);
            Debug.Log(fullPath);
            TeamColor = data.TeamColor;
        }
        

        //PlayerPrefs.GetFloat("teamColor.a", TeamColor.a);
        //PlayerPrefs.GetFloat("teamColor.r", TeamColor.r);
        //PlayerPrefs.GetFloat("teamColor.g", TeamColor.g);
        //PlayerPrefs.GetFloat("teamColor.b", TeamColor.b);
    }
}
