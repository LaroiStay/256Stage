using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectBinding : UI_Base
{
    string m_text;
    int index;


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

    public void setName(string temptext,int i)
    {
        index = i;
        m_text = temptext;
        BindThings();
        //Get<TextMeshProUGUI>((int)Texts.Text).text = temptext;
        setImage();
        setFunc();
    }

    void setImage()
    {
        Sprite temps = Manager.Resource_Instance.Load<Sprite>($"Image/StageIcon/{m_text}Icon");
        Get<Image>((int)Images.Image).sprite = temps;
    }

    void setFunc()
    {
        Get<Button>((int)Buttons.Button).onClick.AddListener(ShowMenuBar);
    }

    void ShowMenuBar()
    {
        FindObjectOfType<BasicWindow>().ClickButton(index);
    }


}
