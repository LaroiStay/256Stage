using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RTG;

public class TopBackgroundCanvas : UI_ETC
{
    TranslateOption TLO;
    RTUndoRedo RTGRedo;
    enum Panels
    {
        FilePanel
    }
    enum Buttons
    {
        RedoButton,
        UndoButton,
        FileButton,
        EditButton,
        TrashButton
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
        Get<Button>((int)Buttons.FileButton).onClick.AddListener(FileButtonFunc);
        Get<Button>((int)Buttons.TrashButton).onClick.AddListener(TrashButtonFunc);
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
