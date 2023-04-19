using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class StageSlectScene : MonoBehaviour
{
    public GameObject StageSizePanel;

    public TMP_Text StageSaveName;
    public TMP_Text StageNum;
    public TMP_Text StageX;
    public TMP_Text StageY;

    public TMP_Text InputX;
    public TMP_Text InputY;


    void Start()
    {
        StageSaveName.text = DataManager.instance.nowPlayer.StageName;
        StageNum.text = DataManager.instance.nowPlayer.StageNum.ToString();
        StageX.text = DataManager.instance.nowPlayer.StageX.ToString();
        StageY.text = DataManager.instance.nowPlayer.StageY.ToString();
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
    public void ShowSizePage()
    {
        StageSizePanel.gameObject.SetActive(true);
    }
    public void GotoToolPage()
    {
        
        DataManager.instance.nowPlayer.StageX = InputX.text;
        DataManager.instance.nowPlayer.StageY = InputY.text;
        DataManager.instance.SaveData();
        
        //SceneManager.LoadScene(3);
    }
    public void GotoHome()
    {
        //SceneManager.LoadScene(0);
    }
}
