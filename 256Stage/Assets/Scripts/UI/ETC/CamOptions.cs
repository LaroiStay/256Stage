using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class CamOptions : UI_ETC
{

    Dictionary<Camera, string> Cam_Dic = new Dictionary<Camera, string>();
    private TMP_Dropdown dropdown;
    GameObject CurrentQuad = null;
    int i = 0;

    enum Tmp_Drop
    {
        Dropdown
    }



    private void Start()
    {
        BindThings();
        DoFirsthing();
    }


    void BindThings()
    {
        Bind<TMP_Dropdown>(typeof(Tmp_Drop));
    }

    void DoFirsthing()
    {
        dropdown = Get<TMP_Dropdown>((int)Tmp_Drop.Dropdown);
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        dropdown.gameObject.SetActive(false);
    }


    public void OnCamOption(Vector3 vec,GameObject QuadObj)
    {
        CurrentQuad = QuadObj;
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(vec);
        Get<TMP_Dropdown>((int)Tmp_Drop.Dropdown).gameObject.SetActive(true);
        Get<TMP_Dropdown>((int)Tmp_Drop.Dropdown).gameObject.transform.position = new Vector3(screenPosition.x, screenPosition.y, 0);
    }
    public void OFFCamOption()
    {
        CurrentQuad = null;
        Get<TMP_Dropdown>((int)Tmp_Drop.Dropdown).gameObject.SetActive(false);
    }

    public void AddOption(Camera c)
    {
        Debug.Log(c);
        i++;
        string s = $"Cam{i}";
        Cam_Dic.Add(c, s);
        dropdown.options.Add(new TMP_Dropdown.OptionData($"{s}"));
        

    }

    public void DeleteCam(Camera c)
    {
        string s = null;
        Cam_Dic.TryGetValue(c, out s);
        if (s == null)
            return;
        Get<TMP_Dropdown>((int)Tmp_Drop.Dropdown).ClearOptions();

        List<string> sList = new List<string>();
        sList.Add("None");

        if(Cam_Dic.Count == 0)
        {
            Get<TMP_Dropdown>((int)Tmp_Drop.Dropdown).AddOptions(sList);
            return;
        }
        string[] valuesArray = Cam_Dic.Values.ToArray();
        foreach (string value in valuesArray)
            sList.Add(value);
        Get<TMP_Dropdown>((int)Tmp_Drop.Dropdown).AddOptions(sList);
        Cam_Dic.Remove(c);
        i--;
    }

    private void OnDropdownValueChanged(int index)
    {
        SetCamOption(index);
    }

    private void SetCamOption(int i)
    {
        if (i == 0)
            return;
        
        Debug.Log(i);
    }
}
