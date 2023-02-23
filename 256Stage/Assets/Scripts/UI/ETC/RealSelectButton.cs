using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RealSelectButton : UI_Base
{
    string m_name;
    int m_key;

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
        m_name = name;
        m_key = key;
        BindThing();
        Get<Button>((int)Buttons.Button).image.sprite = Manager.Resource_Instance.Load<Sprite>($"Image/Stage/{name}/{name}{key}");
        setFunc();
    }

    void setFunc()
    {
        Get<Button>((int)Buttons.Button).onClick.AddListener(InstantiatePrefab);
    }
    void InstantiatePrefab()
    {
        Manager.Resource_Instance.Instantiate($"Stage/{m_name}/{m_name}{m_key}");
        FindObjectOfType<HierarchyCanvas>().PlusPrefabsInHierarchy(m_name, m_key);
    }


}
