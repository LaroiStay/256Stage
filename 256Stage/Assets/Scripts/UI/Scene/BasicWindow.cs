using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BasicWindow : UI_ETC
{
    float m_time = 0.25f;
    static List<bool> IsSelect = new List<bool>();
    static bool CurrentState = false;
    //int Box_Length =1;
    int Camera_Lenght = 1;
    int Curtain_Length = 4;
    int Floor_Length = 15;
    int Light_Length = 7;
    int Other_Length = 3;
    int Screen_Length = 1;
    int Speaker_Length= 10;
    int Stage_Length = 8;
    int Truss_Length = 12;
    

    List<int> tempList = new List<int>();
    Dictionary<string, int> myDictionary = new Dictionary<string, int>();

    enum Panels
    {
        RealSelect,
        ColorPanel,
        SelectObjectPanel,
        MenuSelect
    }

    enum Scrollbars
    {
        MenuScroll
    }

    enum Menu
    {
        Camera,
        Curtain,
        Floor,
        Light,
        Other,
        Screen,
        Speaker,
        Stage,
        Truss,
    }


    void BindThings()
    {
        Bind<Image>(typeof(Panels));
        Bind<Scrollbar>(typeof(Scrollbars));
    }

    void ListAdds()
    {
        //tempList.Add(Box_Length);
        tempList.Add(Camera_Lenght);
        tempList.Add(Curtain_Length);
        tempList.Add(Floor_Length);
        tempList.Add(Light_Length);
        tempList.Add(Other_Length);
        tempList.Add(Screen_Length);
        tempList.Add(Speaker_Length);
        tempList.Add(Stage_Length);
        tempList.Add(Truss_Length);
    }


    private void Start()
    {
        ListAdds();
        BindThings();
        Transform tempTransform = Get<Image>((int)Panels.SelectObjectPanel).transform;
        string[] names = Enum.GetNames(typeof(Menu));
        Get<Image>((int)Panels.RealSelect).gameObject.transform.position = new Vector3(Get<Image>((int)Panels.RealSelect).gameObject.transform.position.x, 1000f, Get<Image>((int)Panels.RealSelect).gameObject.transform.position.z);
        for (int i =0; i< names.Length; i++)
        {
            GameObject go = Manager.Resource_Instance.Instantiate("UI/ETC/SelectBinding",tempTransform);
            go.GetComponent<SelectBinding>().setName(names[i],i);
            IsSelect.Add(false);
            myDictionary.Add(names[i], tempList[i]);
        }
        Get<Scrollbar>((int)Scrollbars.MenuScroll).gameObject.SetActive(false);

    }

    public void ClickButton(int buttonIndex)
    {

        if(CurrentState == false)
        {
            CurrentState = true;
            for (int i = 0; i < IsSelect.Count; i++)
                IsSelect[i] = false;
            IsSelect[buttonIndex] = true;
            ShowMenu(Enum.GetName(typeof(Menu),buttonIndex));
        }
        else if(CurrentState== true && IsSelect[buttonIndex] == true)
        {
            CurrentState = false;
            for (int i = 0; i < IsSelect.Count; i++)
                IsSelect[i] = false;
            CloseMenu();
        }
        else if(CurrentState == true && IsSelect[buttonIndex] == false)
        {
            DeleteAllInSelectMenu();
            for (int i = 0; i < IsSelect.Count; i++)
                IsSelect[i] = false;
            IsSelect[buttonIndex] = true;
            ShowMenu(Enum.GetName(typeof(Menu), buttonIndex));
        }
    }


    void ShowMenu(string tempText)
    {
        int keyvalue = 0;
        myDictionary.TryGetValue(tempText,out keyvalue);
        for (int i=0; i<keyvalue; i++)
        {
            Manager.Resource_Instance.Instantiate("UI/ETC/RealSelectButton", Get<Image>((int)Panels.MenuSelect).transform).GetComponent<RealSelectButton>().SetImage(tempText, i+1);
        }
        StartCoroutine(DownMenu());
    }


    void CloseMenu()
    {

        DeleteAllInSelectMenu();
        Get<Scrollbar>((int)Scrollbars.MenuScroll).gameObject.SetActive(false);
        StartCoroutine(UpMenu());
    }


    void DeleteAllInSelectMenu()
    {
        int count = Get<Image>((int)Panels.MenuSelect).transform.childCount;
        for (int i = 0; i < count; i++)
        {
            Manager.Resource_Instance.Destroy(Get<Image>((int)Panels.MenuSelect).transform.GetChild(i).gameObject);
        }
    }




    IEnumerator DownMenu()
    {
        GameObject go = Get<Image>((int)Panels.RealSelect).gameObject;
        Vector3 vecc = go.transform.position;
        float time = 0f;
        while (time < m_time)
        {
            time += Time.deltaTime;
            go.transform.position = new Vector3(vecc.x, 1080- 180 -100*time/m_time, vecc.z);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        go.transform.position = new Vector3(vecc.x, 1080 - 230 - 50, vecc.z);
    }


    IEnumerator UpMenu()
    {
        GameObject go = Get<Image>((int)Panels.RealSelect).gameObject;
        Vector3 vecc = go.transform.position;
        float time = 0f;
        while (time < m_time)
        {
            time += Time.deltaTime;
            go.transform.position = new Vector3(vecc.x, 845 + 100 * time / m_time, vecc.z);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        
    }

}
