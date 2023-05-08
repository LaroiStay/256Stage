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
    [HideInInspector] public Define.Scene SceneType = Define.Scene.UnKnown;
    [HideInInspector] public int SceneNum;
    //[HideInInspector] public Vector3[] GameobjectPos;
    //[HideInInspector] public Vector3[] GameobjectRotation;
    //[HideInInspector] public string[] ObjectName;
    //[HideInInspector] public int[] ObjectKey;



    public void STA()
    {
        good.text = name;
        //Clickbutton.onClick.AddListener(MoveScene);
    }


    //void MoveScene()
    //{

    //    ES3.Save("Current")
    //    Manager.Scene_Instance.LoadScene(SceneType);
    //    Manager.UI_Instance.CloseETCUI<PlayerSelectPage>();
    //}


    


}
