using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Stage2 : MonoBehaviour
{

    public TextMeshProUGUI good;
    public Button Clickbutton;
    [HideInInspector] public string name;
    [HideInInspector] public int SceneNum;
    [HideInInspector] public int SceneNumType;
    [HideInInspector] public int NUM;


   




    public void STA()
    {
        good.text = name;
        Clickbutton.onClick.AddListener(MoveScene);
    }


    void MoveScene()
    {

        //ES3.Save("Current")
        
        Manager.UI_Instance.CloseETCUI<PlayerSelectPage>();
        ES3.Save("CurrentStageName", name);
        ES3.Save("CurrentSceneInfo1", SceneNum);
        ES3.Save("CurrentSceneInfo2", SceneNumType);

        Manager.Scene_Instance.LoadScene(Define.Scene.First);
        //switch (NUM)
        //{
        //    case 1:

        //        Manager.Scene_Instance.LoadScene(Define.Scene.First);
        //        break;
        //    case 2:

        //        Manager.Scene_Instance.LoadScene(Define.Scene.Second);
        //        break;
        //    case 3:

        //        Manager.Scene_Instance.LoadScene(Define.Scene.Third);
        //        break;
        //    default:
        //        return;
        //        break;
            
        //}

    }





}
