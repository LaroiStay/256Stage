using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HierarchyCanvas : UI_ETC 
{
    
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


    private void Start()
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

    public void PlusPrefabsInHierarchy(string name, int key,GameObject go)
    {
        TempHierarchyButton HiButton = Manager.Resource_Instance.Instantiate("UI/ETC/TempHierarchyButton", Get<Image>((int)Panels.RealHierarchyPanel).transform).GetOrAddComponent<TempHierarchyButton>();
        HiButton.setName(name, key);
        HiButton.setGameObject(go);
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
