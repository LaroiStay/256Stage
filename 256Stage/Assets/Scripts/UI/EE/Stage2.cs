using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Stage2 : MonoBehaviour
{

    public TextMeshProUGUI good;
    public Button Clickbutton;
    public Image im;
    public Button bu;
    public Image underImage;
    public TextMeshProUGUI etcText;
    
    [HideInInspector] public string name;
    [HideInInspector] public int SceneNum;
    [HideInInspector] public int SceneNumType;
    [HideInInspector] public int NUM;
    [HideInInspector] public int inti;

    string BasePath = "Image/StageaCapture/StageCaptureThrust";
    string CirPath = "Image/StageaCapture/StageCaptureArena";
    string Pro = "Image/StageaCapture/StageCapturePro";



    public void STA()
    {
        good.text = name;
        Clickbutton.onClick.AddListener(MoveScene);
        bu.onClick.AddListener(() => { Trash(inti); });
        int ii = Random.RandomRange(1, 4);
        if (SceneNumType == 1)
            im.sprite = Manager.Resource_Instance.Load<Sprite>($"{BasePath}{ii}");
        else if(SceneNumType == 2)
            im.sprite = Manager.Resource_Instance.Load<Sprite>($"{Pro}{ii}");
        else
            im.sprite = Manager.Resource_Instance.Load<Sprite>($"{CirPath}{ii}");
    }

    void MoveScene()
    {
        Manager.UI_Instance.CloseETCUI<PlayerSelectPage>();
        ES3.Save("CurrentStageName", name);
        ES3.Save("CurrentSceneInfo1", SceneNum);
        ES3.Save("CurrentSceneInfo2", SceneNumType);
        Manager.Scene_Instance.LoadScene(Define.Scene.First);
    }


    void Trash(int i)
    {

       


        string [] s = ES3.Load<string[]>("SceneNames");
        Debug.Log(s);


       

        List<string> sList = new List<string>(s);
        sList.RemoveAt(i);
        s = sList.ToArray();
        ES3.Save<string []>("SceneNames", s);
       

        int[] intint = ES3.Load<int[]>("SceneList");
        List<int> IList = new List<int>(intint);
        IList.RemoveAt(i);
        intint = IList.ToArray();
        ES3.Save<int[]>("SceneList", intint);


        int[] intint_ = ES3.Load<int[]>("SceneTypes");


        List<int> IList_ = new List<int>(intint_);
        IList_.RemoveAt(i);
        intint_ = IList_.ToArray();
        ES3.Save<int[]>("SceneTypes", intint_);


        int ix = ES3.Load<int>("TotalCount", 0);
        ix--;
        ES3.Save("TotalCount", ix);

        Manager.UI_Instance.CloseETCUI<PlayerSelectPage>();
        Manager.Scene_Instance.LoadScene(Define.Scene.PlayerSelect);

    }
}
