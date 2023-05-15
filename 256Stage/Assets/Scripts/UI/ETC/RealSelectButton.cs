using System.Collections;
using System.Collections.Generic;
using RTG;
using UnityEngine;
using UnityEngine.UI;

public class RealSelectButton : UI_Base
{
    [HideInInspector] public string m_name;
    [HideInInspector] public int m_key;

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
        if (name == "Light"||name == "Screen"||name == "Speaker")
            this.gameObject.AddComponent<IsLight>();
        setFunc();
    }

    void setFunc()
    {
        Get<Button>((int)Buttons.Button).onClick.AddListener(InstantiatePrefab);
    }
    void InstantiatePrefab()
    {
        GameObject go = Manager.Resource_Instance.Instantiate($"Stage/{m_name}/{m_name}{m_key}");
        go.transform.position = CurrentObject.objectMake.transform.position;
        GameObject go2= FindObjectOfType<HierarchyCanvas>().PlusPrefabsInHierarchy(m_name, m_key, go);
        
        List<GameObject> goList = new List<GameObject>();
        goList.Add(go);
        goList.Add(go2);
        var postObjectSpawnAction = new PostObjectSpawnAction(goList);
        postObjectSpawnAction.Execute();
        //CurrentObject.HierarchyButtonsDetail.Add(go2, postObjectSpawnAction);
    }


}
