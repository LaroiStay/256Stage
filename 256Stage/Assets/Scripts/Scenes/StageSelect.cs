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


    enum Panels
    {
        Manual
    }

    enum Buttons
    {
        HomeButton,
        stage1,
        stage2,
        stage3,
        Manuel,
        Manu,
        StageExitButton
        //DoneButton
    }

    enum Texts
    {
        StageNameText,
        StageText
    }
    //enum Panels
    //{
    //    StageSizePage,
    //}

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
        //Bind<Image>(typeof(Panels));
        Bind<TMP_InputField>(typeof(TMP_Input));
        Bind<Image>(typeof(Panels));
    }
    void DoFirstThing()
    {
        //PanelsActiveFalse();
        SetName();
        Get<Image>((int)Panels.Manual).gameObject.SetActive(false);
    }
    void SetFuc()
    {
        Get<Button>((int)Buttons.stage1).onClick.AddListener(PanelsActiveTrue_Stage1);
        Get<Button>((int)Buttons.stage2).onClick.AddListener(PanelsActiveTrue_Stage2);
        Get<Button>((int)Buttons.stage3).onClick.AddListener(PanelsActiveTrue_Stage3);
      //  Get<Button>((int)Buttons.DoneButton).onClick.AddListener(DoneButtonClick);
        Get<Button>((int)Buttons.HomeButton).onClick.AddListener(ClickHomeButton);
        //Get<Button>((int)Buttons.HomeButton).onClick.AddListener();
        Get<Button>((int)Buttons.Manu).onClick.AddListener(OffMan);
        Get<Button>((int)Buttons.Manuel).onClick.AddListener(OnMan);
        Get<Button>((int)Buttons.StageExitButton).onClick.AddListener(StageExitButtonClick);
    }


    void SetName()
    {
        string s = ES3.Load<string>("CurrentStageName");
        Get<TextMeshProUGUI>((int)Texts.StageText).text = @$"StageName: 
{s}";


    }

    //void PanelsActiveFalse()
    //{
    //    // Get<Image>((int)Panels.StageSizePage).gameObject.SetActive(false);
    //}

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


    void OnMan()
    {
        Get<Image>((int)Panels.Manual).gameObject.SetActive(true);
    }

    void OffMan()
    {
        Get<Image>((int)Panels.Manual).gameObject.SetActive(false);

    }


    //void DoneButtonClick()
    //{
    //    int num, num1;
    //    if (TryGetIntFromInputField(Get<TMP_InputField>((int)TMP_Input.InputX), out num) && TryGetIntFromInputField(Get<TMP_InputField>((int)TMP_Input.InputY), out num1))
    //    {
    //        ES3.Save("CurrentInputX", num);
    //        ES3.Save("CurrentInputY", num1);
    //    }
    //    int ll = ES3.Load<int>("CurrentSceneCount", 1);
    //    ES3.Save("CurrentSceneCount", ll);
    //    Manager.UI_Instance.CloseETCUI<StageSelect>();
    //    Manager.Scene_Instance.LoadScene(SceneType);

    //}

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

    void StageExitButtonClick()
    {
#if UNITY_EDITOR // 에디터에서는 종료됨
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBGL // 웹에서는 종료됨
        Application.OpenURL("about:blank");
#else // 안드로이드, iOS 등에서는 백그라운드로 전환됨
        Application.Quit();
#endif
    }
}
