using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;


public class StageSelect : UI_ETC
{
    int MAX = 10000;
    int MIN = 100;
    Define.Scene SceneType = Define.Scene.UnKnown;



    enum Buttons
    {
        HomeButton,
        stage1,
        stage2,
        stage3,
        DoneButton
    }

    enum Texts
    {
        StageNameText
    }
    enum Panels
    {
        StageSizePage,
    }

    enum TMP_Input
    {
        InputX,
        InputY,
    }

    private void Start()
    {
        BindThings();
        SetFuc();
        DoFirstThing();
    }

    void BindThings()
    {
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Image>(typeof(Panels));
        Bind<TMP_InputField>(typeof(TMP_Input));
    }
    void DoFirstThing()
    {
        PanelsActiveFalse();
        SetName();
    }
    void SetFuc()
    {
        Get<Button>((int)Buttons.stage1).onClick.AddListener(PanelsActiveTrue_Stage1);
        Get<Button>((int)Buttons.stage2).onClick.AddListener(PanelsActiveTrue_Stage2);
        Get<Button>((int)Buttons.stage3).onClick.AddListener(PanelsActiveTrue_Stage3);
        Get<Button>((int)Buttons.DoneButton).onClick.AddListener(DoneButtonClick);
        Get<Button>((int)Buttons.HomeButton).onClick.AddListener(ClickHomeButton);
        //Get<Button>((int)Buttons.HomeButton).onClick.AddListener();
    }


    void SetName()
    {
        string s = ES3.Load<string>("CurrentStageName");
        Get<TextMeshProUGUI>((int)Texts.StageNameText).text = s;
    }

    void PanelsActiveFalse()
    {
        Get<Image>((int)Panels.StageSizePage).gameObject.SetActive(false);
    }

    void PanelsActiveTrue_Stage1()
    {
       // Get<Image>((int)Panels.StageSizePage).gameObject.SetActive(true);
        SceneType = Define.Scene.Kwon;
        ES3.Save("CurrentSceneType", 1);
        int ll = ES3.Load<int>("CurrentSceneCount", 0);
        ES3.Save("CurrentSceneCount", ll);
        Manager.UI_Instance.CloseETCUI<StageSelect>();
        Manager.Scene_Instance.LoadScene(SceneType);

    }
    void PanelsActiveTrue_Stage2()
    {
        //Get<Image>((int)Panels.StageSizePage).gameObject.SetActive(true);
        SceneType = Define.Scene.Proscenium;
        ES3.Save("CurrentSceneType", 2);
        int ll = ES3.Load<int>("CurrentSceneCount", 0);
        ES3.Save("CurrentSceneCount", ll);
        Manager.UI_Instance.CloseETCUI<StageSelect>();
        Manager.Scene_Instance.LoadScene(SceneType);
    }
    void PanelsActiveTrue_Stage3()
    {
        //Get<Image>((int)Panels.StageSizePage).gameObject.SetActive(true);
        SceneType = Define.Scene.SceneSample1;
        ES3.Save("CurrentSceneType", 3);
        int ll = ES3.Load<int>("CurrentSceneCount", 0);
        ES3.Save("CurrentSceneCount", ll);
        Manager.UI_Instance.CloseETCUI<StageSelect>();
        Manager.Scene_Instance.LoadScene(SceneType);
    }


    void ClickHomeButton()
    {
        ES3.Save("CurrentStageName", "");
        Manager.UI_Instance.CloseETCUI<StageSelect>();
        Manager.Scene_Instance.LoadScene(Define.Scene.PlayerSelect);

    }


    void DoneButtonClick()
    {
        int num, num1;
        if (TryGetIntFromInputField(Get<TMP_InputField>((int)TMP_Input.InputX), out num) && TryGetIntFromInputField(Get<TMP_InputField>((int)TMP_Input.InputY), out num1))
        {
            ES3.Save("CurrentInputX", num);
            ES3.Save("CurrentInputY", num1);
        }
        int ll = ES3.Load<int>("CurrentSceneCount", 1);
        ES3.Save("CurrentSceneCount", ll);
        Manager.UI_Instance.CloseETCUI<StageSelect>();
        Manager.Scene_Instance.LoadScene(SceneType);

    }

    private bool TryGetIntFromInputField(TMP_InputField inputField, out int result)
    {
        if (int.TryParse(inputField.text, out result))
        {
            if (result > MIN && result < MAX)
            {
                return true;
            }
            else
            {
                Debug.LogWarning("Input value is not in range!");
                return false;
            }
        }
        else
        {
            return false;
        }
    }




    //public GameObject StageSizePanel;

    //public TMP_Text StageSaveName;
    //public TMP_Text StageNum;
    //public TMP_Text StageX;
    //public TMP_Text StageY;

    //public TMP_Text InputX;
    //public TMP_Text InputY;


    //void Start()
    //{
    //    StageSaveName.text = DataManager.instance.nowPlayer.StageName;
    //    StageNum.text = DataManager.instance.nowPlayer.StageNum.ToString();
    //    StageX.text = DataManager.instance.nowPlayer.StageX.ToString();
    //    StageY.text = DataManager.instance.nowPlayer.StageY.ToString();
    //    SelectSetting(DataManager.instance.nowPlayer.StageNum);
    //}



    //public void Save()
    //{
    //    DataManager.instance.SaveData();
    //}
    //public void SelectSetting(int number)
    //{
    //    for (int i = 0; i < 4; i++)
    //    {
    //        if (number == i)
    //        {
    //            DataManager.instance.nowPlayer.StageNum = number;
    //            StageNum.text = DataManager.instance.nowPlayer.StageNum.ToString();
    //        }

    //    }

    //}
    //public void ShowSizePage()
    //{
    //    StageSizePanel.gameObject.SetActive(true);
    //}
    //public void GotoToolPage()
    //{

    //    DataManager.instance.nowPlayer.StageX = InputX.text;
    //    DataManager.instance.nowPlayer.StageY = InputY.text;
    //    DataManager.instance.SaveData();

    //    //SceneManager.LoadScene(3);
    //}
    //public void GotoHome()
    //{
    //    //SceneManager.LoadScene(0);
    //}
}
