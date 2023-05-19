using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HierarchyCanvas : UI_ETC 
{
    GameObject ObjectsMove
    {
        get
        {
            GameObject go = GameObject.Find("ObjectsMove");
            if (go == null)
                go = new GameObject { name = "ObjectsMove" };
            return go;
        }
    }
    GameObject COgo;
    CamOptions CO;
    enum Panels
    {
        HierarchyPanel,
        RealHierarchyPanel
    }
    enum Texts
    {
        Text
    }

    enum Buttons
    {
        On,
        Close
    }


    private void Awake()
    {
        BindThings();
        SetText();
        BindFucToButtons();
        FirstSetting();
    }

    void BindThings()
    {
        Bind<Image>(typeof(Panels));
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));
    }

    void SetText()
    {
        Get<TextMeshProUGUI>((int)Texts.Text).text = "Hierarchy";
    }

    public GameObject PlusPrefabsInHierarchy(string name, int key,GameObject go)
    {
        if(CO == null)
        {
            COgo = GameObject.Find("CamOptions");
            if(COgo == null)
            {
                CO = Manager.UI_Instance.ShowUI<CamOptions>();
            }
            else
                CO = GameObject.Find("CamOptions").GetComponent<CamOptions>();
        }

        GameObject TempGo = Manager.Resource_Instance.Instantiate("UI/ETC/TempHierarchyButton", Get<Image>((int)Panels.RealHierarchyPanel).transform);
        if (name == "Speaker")
            CurrentMusicAudioS.audioSourceDic.Add(go.GetComponent<AudioSource>(), "");
        else if(name == "Camera")
        {
            CamInFo CIF = go.GetComponent<CamInFo>();
            CO.AddOption(CIF.GetCam());
           //CO.AddOption()
        }
        TempHierarchyButton HiButton = TempGo.GetOrAddComponent<TempHierarchyButton>();
        HiButton.setName(name, key);
        HiButton.setGameObject(go);
        CurrentObject.HierarchyButtons.Add(go, TempGo);
        return TempGo;
    }


    public void ObjectSave()
    {
        if (Get<Image>((int)Panels.RealHierarchyPanel).transform.childCount == 0)
            return;

        int iii = Get<Image>((int)Panels.RealHierarchyPanel).transform.childCount;
        for (int kk = 0; kk< iii; kk++){

           
            GameObject go = Get<Image>((int)Panels.RealHierarchyPanel).transform.GetChild(0).gameObject;
            go.transform.parent = ObjectsMove.transform;
        }
    }


    public void ObjectsLoad()
    {
        if (ObjectsMove.transform.childCount == 0)
            return;
        int iii = ObjectsMove.transform.childCount;
        for (int kk = 0; kk < iii; kk++)
        {
            GameObject go = ObjectsMove.transform.GetChild(0).gameObject;
            go.transform.parent = Get<Image>((int)Panels.RealHierarchyPanel).transform;
        }
    }




   void FirstSetting()
    {
        Get<Button>((int)Buttons.On).gameObject.SetActive(false);
    }

    void BindFucToButtons()
    {
        Get<Button>((int)Buttons.Close).onClick.AddListener(Close);
        Get<Button>((int)Buttons.On).onClick.AddListener(On);

    }

    void Close()
    {
        Debug.Log("good");
        Get<Image>((int)Panels.HierarchyPanel).gameObject.SetActive(false);
        Get<TextMeshProUGUI>((int)Texts.Text).gameObject.SetActive(false);
        Get<Button>((int)Buttons.On).gameObject.SetActive(true);
        Get<Button>((int)Buttons.Close).gameObject.SetActive(false);


    }
    void On()
    {
        Get<Image>((int)Panels.HierarchyPanel).gameObject.SetActive(true);
        Get<TextMeshProUGUI>((int)Texts.Text).gameObject.SetActive(true);
        Get<Button>((int)Buttons.On).gameObject.SetActive(false);
        Get<Button>((int)Buttons.Close).gameObject.SetActive(true);
    }

}
