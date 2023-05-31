using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class CamOptions : UI_ETC
{

    Dictionary<Camera, string> Cam_Dic = new Dictionary<Camera, string>();
    Dictionary<GameObject, Material> Quad_Dic = new Dictionary<GameObject, Material>();
    private TMP_Dropdown dropdown;
    GameObject CurrentQuad = null;
    int i = 0;
    bool flag = true;

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
        if(flag)
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
        Material Mat = null;
        Quad_Dic.TryGetValue(QuadObj,out Mat);
        if(Mat == null)
            Quad_Dic.Add(QuadObj, QuadObj.GetComponent<MeshRenderer>().material);
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
        i++;
        string s = $"Cam{i}";
        Cam_Dic.Add(c, s);
        if(dropdown == null)
        {
            Bind<TMP_Dropdown>(typeof(Tmp_Drop));
            dropdown = Get<TMP_Dropdown>((int)Tmp_Drop.Dropdown);
            flag = false;
        }
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
        if (Cam_Dic.Count == 0)
        {
            Get<TMP_Dropdown>((int)Tmp_Drop.Dropdown).AddOptions(sList);
            return;
        }

        List<GameObject> filteredGameObjects = new List<GameObject>();
        foreach (KeyValuePair<GameObject, Material> pair in Quad_Dic)
        {
            if (pair.Value.name == $"Tex {s[s.Length - 1]}")
            {

                Debug.Log($"{pair.Value.name}, Tex {s[s.Length - 1]}   ----1");
                filteredGameObjects.Add(pair.Key);
            }
            else
            {
                Debug.Log($"{pair.Value.name}, Tex {s[s.Length - 1]}   ----2");
            }
        }
       
        GameObject[] filteredArray = filteredGameObjects.ToArray();
        if(filteredArray.Length != 0)
            for(int i=0; i< filteredArray.Length; i++)
                filteredArray[i].SetActive(false);


        Cam_Dic.Remove(c);
        string[] valuesArray = Cam_Dic.Values.ToArray();
        foreach (string value in valuesArray)
            sList.Add(value);
        Get<TMP_Dropdown>((int)Tmp_Drop.Dropdown).AddOptions(sList);
        Debug.Log(i);
        i--;
        Debug.Log(i);
    }

    private void OnDropdownValueChanged(int index)
    {
        SetCamOption(index);
    }

    private void SetCamOption(int i)
    {
        Camera tempCam = null;
        if (i == 0)
        {
            CurrentQuad.SetActive(false);
            return;
        }
        else if( i== 1)
            tempCam = Cam_Dic.Keys.First();
        else
            tempCam = Cam_Dic.Keys.Skip(i-1).First();

       

        Material CamMat = Manager.Resource_Instance.Load<Material>($"Prefabs/RenderTex/Tex {i}");
        RenderTexture RenderTex = Manager.Resource_Instance.Load<RenderTexture>($"Prefabs/RenderTex/Tex_{i}");
        CamMat.mainTexture = RenderTex;
        tempCam.targetTexture = RenderTex;

        if (Quad_Dic.ContainsKey(CurrentQuad))
        {
            Quad_Dic[CurrentQuad] = CamMat;
            Debug.Log(Quad_Dic[CurrentQuad].name);
        }

        CurrentQuad.SetActive(true);
        tempCam.enabled = true;
        CurrentQuad.GetComponent<MeshRenderer>().material = CamMat;
    }
}
