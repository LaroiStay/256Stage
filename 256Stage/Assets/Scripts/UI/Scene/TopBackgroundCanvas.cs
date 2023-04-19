using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RTG;

public class TopBackgroundCanvas : UI_ETC
{

    RTUndoRedo RTGRedo;

    enum Buttons {
        RedoButton,
        UndoButton,
    }

    private void Start()
    {
        BindThings();
        FirstDoThing();
        SetButtonFunc();
    }

    void BindThings()
    {
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
    }



    void RedoButtonFunc()
    {
        RTGRedo.Redo();
    }

    void UndoButtonFunc()
    {
        RTGRedo.Undo();
    }


}
