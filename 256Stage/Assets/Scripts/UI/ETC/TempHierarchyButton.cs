using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TempHierarchyButton : UI_Base
{
    enum Texts
    {
        Text
    }


    void BindThing()
    {
        Bind<TextMeshProUGUI>(typeof(Texts));
    }

    public void setName(string name, int key)
    {
        BindThing();
        Get<TextMeshProUGUI>((int)Texts.Text).text = $"{name}{key}";
    }
}
