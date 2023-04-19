using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RTG;

public class TopBackgroundCanvas : UI_ETC
{

    RTUndoRedo RTGRedo;
    enum Panels
    {
        FilePanel
    }
    enum Buttons {
        RedoButton,
        UndoButton,
        FileButton,
        EditButton
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

    }

    void SetButtonFunc()
    {
        Get<Button>((int)Buttons.RedoButton).onClick.AddListener(RedoButtonFunc);
        Get<Button>((int)Buttons.UndoButton).onClick.AddListener(UndoButtonFunc);
        Get<Button>((int)Buttons.FileButton).onClick.AddListener(FileButtonFunc);
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
