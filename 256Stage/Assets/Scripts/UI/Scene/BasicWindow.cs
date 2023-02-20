using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BasicWindow : UI_Scene
{
    float m_time = 0.3f;
    enum Panels
    {
        RealSelect,
        ColorPanel,
        SelectObjectPanel
    }


    enum Menu
    {
        Box,
        Curtain,
        Floor,
        Light,
        Other,
        Speaker,
        Truss,
    }


    void BindThings()
    {
        Bind<Image>(typeof(Panels));
    }


    private void Start()
    {
        BindThings();
        Transform tempTransform = Get<Image>((int)Panels.SelectObjectPanel).transform;
        string[] names = Enum.GetNames(typeof(Menu));
        for(int i =0; i< names.Length; i++)
        {
            GameObject go = Manager.Resource_Instance.Instantiate("UI/ETC/SelectBinding",tempTransform);
            go.GetComponent<SelectBinding>().setName(names[i]);
        }
        

    }

    public void ShowMenu(string tempText)
    {
        StartCoroutine(DownMenu());
    }


    public void CloseMenu()
    {
        StartCoroutine(UpMenu());
    }

    IEnumerator DownMenu()
    {
        GameObject go = Get<Image>((int)Panels.RealSelect).gameObject;
        Debug.Log(go);
        Vector3 vecc = go.transform.position;
        float time = 0f;
        while (time < m_time)
        {
            time += Time.deltaTime;
            go.transform.position = new Vector3(vecc.x, 1080- 90 -100*time/m_time, vecc.z);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        go.transform.position = new Vector3(vecc.x, 1080 - 140 - 50, vecc.z);
    }


    IEnumerator UpMenu()
    {
        GameObject go = Get<Image>((int)Panels.RealSelect).gameObject;
        Debug.Log(go);
        Vector3 vecc = go.transform.position;
        float time = 0f;
        while (time < m_time)
        {
            time += Time.deltaTime;
            go.transform.position = new Vector3(vecc.x, 890 + 100 * time / m_time, vecc.z);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        
    }

}
