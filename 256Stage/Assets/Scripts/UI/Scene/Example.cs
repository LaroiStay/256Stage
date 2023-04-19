using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Example : UI_Popup
{
    enum Texts
    {
        Text
    }

    enum Buttons
    {
        Button
    }


    void bindThings()
    {
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));

    }

    private void Awake()
    {
        bindThings();
        change();
        Get<Button>((int)Buttons.Button).onClick.AddListener(Bu);
    }


    void change()
    {
        Get<TextMeshProUGUI>((int)Texts.Text).name = "hi";
    }


    void Bu()
    {
        Debug.Log("hi");

        Manager.Resource_Instance.Instantiate("Cub/Cube");
    }

}