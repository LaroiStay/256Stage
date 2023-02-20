using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectBinding : UI_Base
{
    string m_text;
    static bool CurrentState = false;
    static bool isCurrent = false;


    enum Images
    {
        Image
    }
    enum Buttons
    {
        Button
    }

    enum Texts
    {
        Text
    }


    void BindThings()
    {
        Bind<Image>(typeof(Images));
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));
    }

    public void setName(string temptext)
    {
        m_text = temptext;
        BindThings();
        Get<TextMeshProUGUI>((int)Texts.Text).text = temptext;
        setImage();
        setFunc();
    }

    void setImage()
    {
        Sprite temps = Manager.Resource_Instance.Load<Sprite>($"Image/Stage/{m_text}/{m_text}01");
        Get<Image>((int)Images.Image).sprite = temps;
    }

    void setFunc()
    {
        Get<Button>((int)Buttons.Button).onClick.AddListener(ShowMenuBar);
    }

    void ShowMenuBar()
    {
        if(CurrentState == false)
        {
            FindObjectOfType<BasicWindow>().ShowMenu(m_text);
            isCurrent = true;
            CurrentState = true;
        }


    }


}
