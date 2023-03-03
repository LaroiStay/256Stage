using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TempHierarchyButton : UI_Base
{
    GameObject go;

    enum Texts
    {
        Text
    }
    
    enum Buttons
    {
        TempHierarchyButton
    }


    void BindThing()
    {
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Button>(typeof(Buttons));
    }

    public void setName(string name, int key)
    {
        BindThing();
        Get<TextMeshProUGUI>((int)Texts.Text).text = $"{name}{key}";
    }

    public void setGameObject(GameObject tempgo)
    {
        go = tempgo;
        Get<Button>((int)Buttons.TempHierarchyButton).onClick.AddListener(ClickButton);
    }

    void ClickButton()
    {
        if (CurrentObject.selectedCurrentObject == null)
            CurrentObject.selectedCurrentObject = go;
        else if (CurrentObject.selectedCurrentObject != go)
            CurrentObject.selectedCurrentObject = go;
        else
            CurrentObject.selectedCurrentObject = null;
        Debug.Log(CurrentObject.selectedCurrentObject);
    }

}
