using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : BaseScene
{
    string name;
    int CurrentType;
    int CurrnetSceneNum;


    string KwonPath = "SceneType/KwonS";
    string ProPath = "SceneType/ProsceniumS";
    string SamplePath = "SceneType/CircleS";
    string BaseObejctPath = "Stage";


    private void Start()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();
        name = ES3.Load<string>("CurrentStageName");
        CurrnetSceneNum = ES3.Load<int>("CurrentSceneInfo1");
        
        CurrentType = ES3.Load<int>("CurrentSceneInfo2");


        switch (CurrentType)
        {
            case 1:

                Manager.Resource_Instance.Instantiate(KwonPath);
                SceneType = Define.Scene.Kwon;
                break;
            case 2:

                Manager.Resource_Instance.Instantiate(ProPath);
                SceneType = Define.Scene.Proscenium;
                break;
            case 3:

                Manager.Resource_Instance.Instantiate(SamplePath);
                SceneType = Define.Scene.SceneSample1;
                break;
            default:
                return;
                break;

        }

        Debug.Log(CurrnetSceneNum);

        Manager.UI_Instance.ShowUI<BasicWindow>();
        Manager.UI_Instance.ShowUI<HierarchyCanvas>();
        Manager.UI_Instance.ShowUI<TranslateOption>();
        Manager.UI_Instance.ShowUI<TopBackgroundCanvas>();
        Manager.UI_Instance.ShowUI<BottomCanvas>();
        LoadObject();
    }
    public override void Clear()
    {
       
    }



    void LoadObject()
    {


        Vector3[] Ro = ES3.Load<Vector3[]>($"{CurrnetSceneNum}Rotation");
        Vector3[] Pos = ES3.Load<Vector3[]>($"{CurrnetSceneNum}Pos");
        int[] Ke = ES3.Load<int[]>($"{CurrnetSceneNum}KeyS");
        string[] Na = ES3.Load<string[]>($"{CurrnetSceneNum}NameS");


        HierarchyCanvas Hiera = GameObject.Find("HierarchyCanvas").GetComponent<HierarchyCanvas>();
        TopBackgroundCanvas Top = GameObject.Find("TopBackgroundCanvas").GetComponent<TopBackgroundCanvas>();
        for (int i = 0; i < Ro.Length; i++)
        {
            GameObject go = Manager.Resource_Instance.Instantiate($"{BaseObejctPath}/{Na[i]}/{Na[i]}{Ke[i]}");
            //go.transform.position = CurrentObject.objectMake.transform.position;
            go.transform.localEulerAngles = Ro[i];
            go.transform.position = Pos[i];
            Hiera.PlusPrefabsInHierarchy(Na[i], Ke[i], go);
        }
        Top.SetFlagfalse();
        Top.SetCurrentScene(CurrnetSceneNum);

    }



}
