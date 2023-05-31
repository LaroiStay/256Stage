using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using UnityEngine.UI;


public class PlayerSelectPage : UI_ETC
{

    string path = "UI/EE/Stage2";
    string NumPath = "UI/EE/num";


    enum Panels
    {
        stage,
        CreatePlayerPanel,
        NumberGrid,
        Manual
    }
    //enum TMP
    //{
    //    project,
    //}
    enum TMPInput
    {

        NewStageNAme
    }

    enum Buttons
    {
        Stage1,
        CreatePlayerButton,
        Blue,
        CancelButton,
        Manuel,
        Manu,
        PlayerExitButton
    }

    private void Start()
    {
        BindThings();
        DoFirstThing();
        BindFuc();
    }

    void BindThings()
    {
        Bind<Image>(typeof(Panels));
        //Bind<TextMeshProUGUI>(typeof(TMP));
        Bind<Button>(typeof(Buttons));
        Bind<TMP_InputField>(typeof(TMPInput));

    }

    void DoFirstThing()
    {
        Get<Image>((int)Panels.CreatePlayerPanel).gameObject.SetActive(false);
        Get<Image>((int)Panels.Manual).gameObject.SetActive(false);
        int ix = ES3.Load<int>("TotalCount", 0);
        if (ix != 0)
        {
            for(int i =0; i<(ix+1)/4+1; i++)
            {
                Button bu = Manager.Resource_Instance.Instantiate(NumPath).GetComponent<Button>();
                bu.transform.parent = Get<Image>((int)Panels.NumberGrid).transform;
                bu.GetComponentInChildren<TextMeshProUGUI>().text = $"{i+1}";
                int index = i;
                bu.onClick.AddListener(() => { ClickNumButton(index); });
            }
            string[] names = ES3.Load<string[]>("SceneNames");
            int [] SceneList = ES3.Load<int[]>("SceneList");
            int[] SceneTypeList = ES3.Load<int[]>("SceneTypes");
            for (int i = 0; i<ix; i++)
            {
                GameObject go = Manager.Resource_Instance.Instantiate(path);
                go.transform.parent = Get<Image>((int)Panels.stage).gameObject.transform;
                Stage2 S2 = go.GetComponent<Stage2>();
                S2.name = names[i];
                S2.SceneNum = SceneList[i];
                S2.SceneNumType = SceneTypeList[i];
                S2.NUM = i+1;
                S2.inti = i;
                S2.STA();
            }
        }
    }


    void BindFuc()
    {
        Get<Button>((int)Buttons.Stage1).onClick.AddListener(CreateNew);
        Get<Button>((int)Buttons.CreatePlayerButton).onClick.AddListener(CreateButton);
        Get<Button>((int)Buttons.Blue).onClick.AddListener(CreateNew);
        Get<Button>((int)Buttons.CancelButton).onClick.AddListener(Cancel);
        Get<Button>((int)Buttons.Manuel).onClick.AddListener(OnMan);
        Get<Button>((int)Buttons.Manu).onClick.AddListener(OffMan);
        Get<Button>((int)Buttons.PlayerExitButton).onClick.AddListener(PlayerExitButtonClick);
    }





    void CreateNew()
    {
        Get<Image>((int)Panels.CreatePlayerPanel).gameObject.SetActive(true);
    }

    void CreateButton()
    {
        string s = Get<TMP_InputField>((int)TMPInput.NewStageNAme).text;
        if (s == "")
            return;
        ES3.Save("CurrentStageName", s);
        Manager.UI_Instance.CloseETCUI<PlayerSelectPage>();

        Manager.Scene_Instance.LoadScene(Define.Scene.StageSelect);
    }


     void ClickNumButton(int i)
    {
        Debug.Log(i);
        int k = i * 4;
        Transform parent = Get<Image>((int)Panels.stage).transform;
        int childCount = parent.childCount;
        for (int ix = 0; ix < childCount; ix++)
            parent.GetChild(ix).gameObject.SetActive(false);
        for (int ix = 0; ix < childCount; ix++)
        {
            if (k <= ix && ix <= k + 3)
            {
                //Debug.Log(ix);
                parent.GetChild(ix).gameObject.SetActive(true);
            }
        }


    }


    void Cancel()
    {
        Get<Image>((int)Panels.CreatePlayerPanel).gameObject.SetActive(false);
    }

    void OnMan()
    {
        Get<Image>((int)Panels.Manual).gameObject.SetActive(true);
    }
    void OffMan()
    {
        Get<Image>((int)Panels.Manual).gameObject.SetActive(false);

    }
    void PlayerExitButtonClick()
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
