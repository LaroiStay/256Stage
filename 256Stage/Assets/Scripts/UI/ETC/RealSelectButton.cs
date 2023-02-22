using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RealSelectButton : UI_Base
{
    
    enum Buttons
    {
        Button
    }


    void BindThing()
    {
        Bind<Button>(typeof(Buttons));
    }

    public void SetImage(string name,int key)
    {
        BindThing();
        //Debug.Log(Manager.Resource_Instance.Load<Sprite>($"Image/Stage/{name}/{name}{key}"));
        Get<Button>((int)Buttons.Button).image.sprite = Manager.Resource_Instance.Load<Sprite>($"Image/Stage/{name}/{name}{key}");
    }


}
