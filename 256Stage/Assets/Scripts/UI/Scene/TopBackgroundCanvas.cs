using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RTG;
using System;

public class TopBackgroundCanvas : UI_ETC
{
    int CurrentScene = ES3.Load<int>("CurrentSceneCount", 0)+1;
    TranslateOption TLO;
    RTUndoRedo RTGRedo;
    bool flag = true;
    enum Panels
    {
        FilePanel
    }
    enum Buttons
    {
        RedoButton,
        UndoButton,
        //FileButton,
        //EditButton,
        TrashButton,
        SaveButton
    }

    private void Start()
    {
        BindThings();
        FirstDoThing();
        SetButtonFunc();
    }

    void BindThings()
    {
        Bind<Image>(typeof(Panels));
        Bind<Button>(typeof(Buttons));
    }


    void FirstDoThing()
    {
        RTGRedo = GameObject.Find("RTUndoRedo").GetComponent<RTUndoRedo>();
        TLO = GameObject.Find("TranslateOption").GetComponent<TranslateOption>();
    }

    void SetButtonFunc()
    {
        Get<Button>((int)Buttons.RedoButton).onClick.AddListener(RedoButtonFunc);
        Get<Button>((int)Buttons.UndoButton).onClick.AddListener(UndoButtonFunc);
        //Get<Button>((int)Buttons.FileButton).onClick.AddListener(FileButtonFunc);
        Get<Button>((int)Buttons.TrashButton).onClick.AddListener(TrashButtonFunc);
        Get<Button>((int)Buttons.SaveButton).onClick.AddListener(SaveFuc);
        //ES3AutoSave
    }



    void SaveFuc()
    {
        List<GameObject> activeChildren = new List<GameObject>();
        List<TempHierarchyButton> ActiveTempHier = new List<TempHierarchyButton>();
        List<int> KeySBundle = new List<int>();
        List<string> nameSBundle = new List<string>();
        List<Vector3> RotationBundle = new List<Vector3>();
        List<Vector3> PosBundle = new List<Vector3>();
        GameObject HiCan = GameObject.Find("RealHierarchyPanel");

        for (int i = 0; i < HiCan.transform.childCount; i++)
        {
            GameObject child = HiCan.transform.GetChild(i).gameObject;
            if (child.activeSelf)
            {
                activeChildren.Add(child);
            }
        }
        for (int i = 0; i < activeChildren.Count; i++)
            ActiveTempHier.Add(activeChildren[i].GetComponent<TempHierarchyButton>());
        for (int i = 0; i < ActiveTempHier.Count; i++)
        {
            KeySBundle.Add(ActiveTempHier[i].KeyS);
            nameSBundle.Add(ActiveTempHier[i].nameS);
            RotationBundle.Add(ActiveTempHier[i].go.transform.localEulerAngles);
            PosBundle.Add(ActiveTempHier[i].go.transform.position);
        }

        if (flag)
        {
            flag = false;


            string currentName = ES3.Load<string>("CurrentStageName");
            string[] defaultNames = new string[] { };
            string[] names = ES3.Load<string[]>("SceneNames", defaultNames);
            string[] newNames = new string[names.Length + 1];
            for (int i = 0; i < names.Length; i++)
                newNames[i] = names[i];
            newNames[newNames.Length - 1] = currentName;
            for(int i = 0; i< newNames.Length; i++)
                Debug.Log(newNames[i]);
            ES3.Save<string[]>("SceneNames", newNames);
            int  ix =  ES3.Load<int>("TotalCount", 0);
            ix++;
            ES3.Save<int>("TotalCount", ix);



            int[] defaultint = { };
            int[] sceneList = ES3.Load("SceneList", defaultint);
            int index = sceneList.Length;
            Array.Resize(ref sceneList, sceneList.Length + 1);
            int newValue = CurrentScene;
            sceneList[index] = newValue;
            ES3.Save("SceneList", sceneList);


            int[] defaultIInt = { };
            int[] sceneTypeList = ES3.Load("CurrentSceneTypes", defaultIInt);
            int indexx = sceneTypeList.Length;
            Array.Resize(ref sceneTypeList, sceneTypeList.Length + 1);
            int newValuee = ES3.Load<int>("CurrentSceneType");
            sceneTypeList[indexx] = newValuee;
            ES3.Save("SceneList", sceneTypeList);



            //int iiii = ES3.Load<int>("CurrentSceneCount");
            //ES3.Save<int>($"{CurrentScene}Type", iiii);



        }
        ES3.Save<int[]>($"{CurrentScene}KeyS", KeySBundle.ToArray());
        ES3.Save<string[]>($"{CurrentScene}NameS", nameSBundle.ToArray());
        ES3.Save<Vector3[]>($"{CurrentScene}Rotation", RotationBundle.ToArray());
        ES3.Save<Vector3[]>($"{CurrentScene}Pos", PosBundle.ToArray());
       







    }




    void TrashButtonFunc()
    {
        if (CurrentObject.selectedCurrentObject == null)
            return;

        if (CurrentObject.HierarchyButtons.Count == 0)
            return;
        GameObject value = null;
        //PostObjectSpawnAction DeleteValue = null;
        CurrentObject.HierarchyButtons.TryGetValue(CurrentObject.selectedCurrentObject,out value);
        if (value == null)
            return;

        List<GameObject> goList = new List<GameObject>();
        //CurrentObject.HierarchyButtonsDetail.TryGetValue(CurrentObject.selectedCurrentObject, out DeleteValue);
        // if (DeleteValue == null)
        //return;
        //DeleteValue.OnRemovedFromUndoRedoStack();
        GameObject go__ = CurrentObject.selectedCurrentObject;
        goList.Add(value);
        goList.Add(go__);

        var DesTTT = new PostObjectDesAction(goList);
        DesTTT.Execute();
        value.SetActive(false);
        CurrentObject.selectedCurrentObject.SetActive(false);
        TLO.gizmosClear();
        CurrentObject.selectedCurrentObject = null;
    }

        void RedoButtonFunc()
        {
            RTGRedo.Redo();
        }

        void UndoButtonFunc()
        {
            RTGRedo.Undo();
        }
        void FileButtonFunc()
        {
            Debug.Log("FileButton");
        }

    
}
