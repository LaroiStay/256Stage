using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class StageSlectScene : MonoBehaviour
{
    public TMP_Text StageSaveName;
    public TMP_Text StageNum;


    void Start()
    {
        StageSaveName.text += DataManager.instance.nowPlayer.StageName;
        StageNum.text = DataManager.instance.nowPlayer.StageNum.ToString();
        SelectSetting(DataManager.instance.nowPlayer.StageNum);
    }



    public void Save()
    {
        DataManager.instance.SaveData();
    }
    public void SelectSetting(int number)
    {
        for (int i = 0; i < 4; i++)
        {
            if (number == i)
            {
                DataManager.instance.nowPlayer.StageNum = number;
                StageNum.text = DataManager.instance.nowPlayer.StageNum.ToString();
            }

        }

    }
    public void GotoToolPage()
    {
        DataManager.instance.SaveData();
        //SceneManager.LoadScene();
    }
}
