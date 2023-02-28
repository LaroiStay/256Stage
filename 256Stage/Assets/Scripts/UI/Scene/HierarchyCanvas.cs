using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HierarchyCanvas : UI_Scene 
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

    private void Start()
    {
        BindThings();
        SetText();
    }

    void BindThings()
    {
        Bind<Image>(typeof(Panels));
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


}
