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
    
    [HideInInspector] public string name;
    [HideInInspector] public int SceneNum;
    [HideInInspector] public int SceneNumType;
    [HideInInspector] public int NUM;

    string BasePath = "Image/StageaCapture/StageCaptureThrust";
    string CirPath = "Image/StageaCapture/StageCaptureArena";
    string Pro = "Image/StageaCapture/StageCapturePro";



    public void STA()
    {
        good.text = name;
        Clickbutton.onClick.AddListener(MoveScene);
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

        //ES3.Save("Current")
        
        Manager.UI_Instance.CloseETCUI<PlayerSelectPage>();
        ES3.Save("CurrentStageName", name);
        ES3.Save("CurrentSceneInfo1", SceneNum);
        ES3.Save("CurrentSceneInfo2", SceneNumType);
        Manager.Scene_Instance.LoadScene(Define.Scene.First);
    }





}
