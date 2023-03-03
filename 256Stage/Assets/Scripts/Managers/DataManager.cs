using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class StageData
{
    /*public PlayerDb(string _Name, bool _isUsing)
    {
        Name = _Name; isUsing = _isUsing;
    }*/

    public string StageName;
    public int StageNum = -1;

}


public class DataManager : MonoBehaviour
{
    //public string curType ="Start";
    public static DataManager instance;

    public StageData nowPlayer = new StageData();

    public string path;
    public int nowSlot = -1;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        path = Application.dataPath + "/Players/player";
        print(path);

    }
    void Start()
    {

    }
    public void SaveData()
    {
        string jdata = JsonUtility.ToJson(nowPlayer);
        File.WriteAllText(path + nowSlot.ToString(), jdata);
    }
    public void LoadData()
    {
        string jdata = File.ReadAllText(path + nowSlot.ToString());
        nowPlayer = JsonUtility.FromJson<StageData>(jdata);
    }
    public void DeleteData()
    {
        File.Delete(path + nowSlot.ToString());

    }

    public void DataClear()
    {
        nowSlot = -1;
        nowPlayer = new StageData();
    }
}
