using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HierarchyCanvas : UI_ETC 
{
    public bool IsCanDo = true;

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
    GameObject tempGo;
    //enum Images
    //{
    //    HierarchyPanel,
    //    RealHierarchyPanel
    //}
    enum Texts
    {
        Text
    }

    enum Buttons
    {
        On,
        Close
    }
    enum Images
    {
        HierarchyPanel,
        RealHierarchyPanel,
        PosText,
        PosX,
        PosY,
        PosZ,
        RoText,
        RoX,
        RoY,
        RoZ,
        Empty
    }


    private void Awake()
    {
        BindThings();
        SetText();
        BindFucToButtons();
        FirstSetting();
    }
    private void Update()
    {
        if (!IsCanDo)
        {
            if (tempGo == null)
                return;
            Transform ttt = tempGo.transform;
            Get<Image>((int)Images.PosX).GetComponentInChildren<TMP_InputField>().text = ttt.transform.position.x.ToString();
            Get<Image>((int)Images.PosY).GetComponentInChildren<TMP_InputField>().text = ttt.transform.position.y.ToString();
            Get<Image>((int)Images.PosZ).GetComponentInChildren<TMP_InputField>().text = ttt.transform.position.z.ToString();
            Get<Image>((int)Images.RoX).GetComponentInChildren<TMP_InputField>().text = ttt.transform.localEulerAngles.x.ToString();
            Get<Image>((int)Images.RoY).GetComponentInChildren<TMP_InputField>().text = ttt.transform.localEulerAngles.y.ToString();
            Get<Image>((int)Images.RoZ).GetComponentInChildren<TMP_InputField>().text = ttt.transform.localEulerAngles.z.ToString();

            return;


        }

        if (tempGo == null)
            return;
        Transform tt = tempGo.transform;
        string str0 = null;
        float f0 = 0.0f;
        float f1 = 0.0f;
        float f2 = 0.0f;
        float f3 = 0.0f;
        float f4 = 0.0f;
        float f5 = 0.0f;
        str0 = Get<Image>((int)Images.PosX).GetComponentInChildren<TMP_InputField>().text;
        if (float.TryParse(str0, out f0))
            tt.position = new Vector3(f0, tt.position.y, tt.position.z);
        str0 = Get<Image>((int)Images.PosY).GetComponentInChildren<TMP_InputField>().text;
        if (float.TryParse(str0, out f1))
            tt.position = new Vector3(tt.position.x, f1, tt.position.z);
        str0 = Get<Image>((int)Images.PosZ).GetComponentInChildren<TMP_InputField>().text;
        if (float.TryParse(str0, out f2))
            tt.position = new Vector3(tt.position.x, tt.position.y, f2);
        str0 = Get<Image>((int)Images.RoX).GetComponentInChildren<TMP_InputField>().text;
        if (float.TryParse(str0, out f3))
            tt.eulerAngles = new Vector3(f3, tt.eulerAngles.y, tt.eulerAngles.z);
        str0 = Get<Image>((int)Images.RoY).GetComponentInChildren<TMP_InputField>().text;
        if (float.TryParse(str0, out f4))
            tt.eulerAngles = new Vector3(tt.eulerAngles.x, f4, tt.eulerAngles.z);
        str0 = Get<Image>((int)Images.RoZ).GetComponentInChildren<TMP_InputField>().text;
        if (float.TryParse(str0, out f5))
            tt.eulerAngles = new Vector3(tt.eulerAngles.x, tt.eulerAngles.y, f5);

    }


    void BindThings()
    {
        //Bind<Image>(typeof(Panels));
        Bind<Image>(typeof(Images));
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

        GameObject TempGo = Manager.Resource_Instance.Instantiate("UI/ETC/TempHierarchyButton", Get<Image>((int)Images.RealHierarchyPanel).transform);
        if (name == "Speaker")
        {

            CurrentMusicAudioS.audioSourceDic.Add(go.GetComponent<AudioSource>(), "");
        }
        else if (name == "Camera")
        {
            CamInFo CIF = go.GetComponent<CamInFo>();
            CO.AddOption(CIF.GetCam());
        }
        else if (name == "Light")
        {
            CurrentObject.LightObj.Add(go,1);
        }
            TempHierarchyButton HiButton = TempGo.GetOrAddComponent<TempHierarchyButton>();
        HiButton.setName(name, key);
        HiButton.setGameObject(go);
        CurrentObject.HierarchyButtons.Add(go, TempGo);
        TempGo.transform.SetSiblingIndex(CurrentObject.i);
        CurrentObject.i++;
        Plus30();
        return TempGo;
    }


    public void ObjectSave()
    {
        if (Get<Image>((int)Images.RealHierarchyPanel).transform.childCount == 0)
            return;
        int iii = Get<Image>((int)Images.RealHierarchyPanel).transform.childCount;
        for (int kk = 0; kk< iii; kk++){

           
            GameObject go = Get<Image>((int)Images.RealHierarchyPanel).transform.GetChild(0).gameObject;
            go.transform.parent = ObjectsMove.transform;
        }
    }


    public void ObjectsLoad()
    {
        if (ObjectsMove.transform.childCount == 0)
            return;
        //falsefalse();
        int iii = ObjectsMove.transform.childCount;
        for (int kk = 0; kk < iii; kk++)
        {
            GameObject go = ObjectsMove.transform.GetChild(0).gameObject;
            go.transform.parent = Get<Image>((int)Images.RealHierarchyPanel).transform;
            Plus30();
        }
    }


   void FirstSetting()
    {
        Get<Button>((int)Buttons.On).gameObject.SetActive(false);
        Get<Image>((int)Images.Empty).gameObject.SetActive(false);
        Get<Image>((int)Images.PosText).gameObject.SetActive(false);
        Get<Image>((int)Images.PosX).gameObject.SetActive(false);
        Get<Image>((int)Images.PosY).gameObject.SetActive(false);
        Get<Image>((int)Images.PosZ).gameObject.SetActive(false);
        Get<Image>((int)Images.RoText).gameObject.SetActive(false);
        Get<Image>((int)Images.RoX).gameObject.SetActive(false);
        Get<Image>((int)Images.RoY).gameObject.SetActive(false);
        Get<Image>((int)Images.RoZ).gameObject.SetActive(false);
    }


    void BindFucToButtons()
    {
        Get<Button>((int)Buttons.Close).onClick.AddListener(Close);
        Get<Button>((int)Buttons.On).onClick.AddListener(On);

    }

    void Close()
    {
        Debug.Log("good");
        Get<Image>((int)Images.HierarchyPanel).gameObject.SetActive(false);
        Get<TextMeshProUGUI>((int)Texts.Text).gameObject.SetActive(false);
        Get<Button>((int)Buttons.On).gameObject.SetActive(true);
        Get<Button>((int)Buttons.Close).gameObject.SetActive(false);


    }
    void On()
    {
        Get<Image>((int)Images.HierarchyPanel).gameObject.SetActive(true);
        Get<TextMeshProUGUI>((int)Texts.Text).gameObject.SetActive(true);
        Get<Button>((int)Buttons.On).gameObject.SetActive(false);
        Get<Button>((int)Buttons.Close).gameObject.SetActive(true);
    }


    public void falsefalse()
    {
        tempGo = null;
        int k = Get<Image>((int)Images.RealHierarchyPanel).gameObject.transform.childCount;
        Get<Image>((int)Images.Empty).gameObject.SetActive(false);
        Get<Image>((int)Images.PosText).gameObject.SetActive(false);
        Get<Image>((int)Images.PosX).gameObject.SetActive(false);
        Get<Image>((int)Images.PosY).gameObject.SetActive(false);
        Get<Image>((int)Images.PosZ).gameObject.SetActive(false);
        Get<Image>((int)Images.RoText).gameObject.SetActive(false);
        Get<Image>((int)Images.RoX).gameObject.SetActive(false);
        Get<Image>((int)Images.RoY).gameObject.SetActive(false);
        Get<Image>((int)Images.RoZ).gameObject.SetActive(false);

        Get<Image>((int)Images.Empty).gameObject.transform.SetSiblingIndex(k);
        Get<Image>((int)Images.RoZ).gameObject.transform.SetSiblingIndex(k);
        Get<Image>((int)Images.RoY).gameObject.transform.SetSiblingIndex(k);
        Get<Image>((int)Images.RoX).gameObject.transform.SetSiblingIndex(k);
        Get<Image>((int)Images.RoText).gameObject.transform.SetSiblingIndex(k);
        Get<Image>((int)Images.PosZ).gameObject.transform.SetSiblingIndex(k);
        Get<Image>((int)Images.PosY).gameObject.transform.SetSiblingIndex(k);
        Get<Image>((int)Images.PosX).gameObject.transform.SetSiblingIndex(k);
        Get<Image>((int)Images.PosText).gameObject.transform.SetSiblingIndex(k);
    }

    public void AllOn()
    {
        Get<Image>((int)Images.Empty).gameObject.SetActive(true);
        Get<Image>((int)Images.PosText).gameObject.SetActive(true);
        Get<Image>((int)Images.PosX).gameObject.SetActive(true);
        Get<Image>((int)Images.PosY).gameObject.SetActive(true);
        Get<Image>((int)Images.PosZ).gameObject.SetActive(true);
        Get<Image>((int)Images.RoText).gameObject.SetActive(true);
        Get<Image>((int)Images.RoX).gameObject.SetActive(true);
        Get<Image>((int)Images.RoY).gameObject.SetActive(true);
        Get<Image>((int)Images.RoZ).gameObject.SetActive(true);
    }


    public void GetNum(GameObject go, int i)
    {
        if (i == -1)
            return;
        i++;
        if(tempGo == go)
        {

            tempGo = null;
            int k =  Get<Image>((int)Images.RealHierarchyPanel).gameObject.transform.childCount;
            Get<Image>((int)Images.Empty).gameObject.SetActive(false);
            Get<Image>((int)Images.PosText).gameObject.SetActive(false);
            Get<Image>((int)Images.PosX).gameObject.SetActive(false);
            Get<Image>((int)Images.PosY).gameObject.SetActive(false);
            Get<Image>((int)Images.PosZ).gameObject.SetActive(false);
            Get<Image>((int)Images.RoText).gameObject.SetActive(false);
            Get<Image>((int)Images.RoX).gameObject.SetActive(false);
            Get<Image>((int)Images.RoY).gameObject.SetActive(false);
            Get<Image>((int)Images.RoZ).gameObject.SetActive(false);

            Get<Image>((int)Images.Empty).gameObject.transform.SetSiblingIndex(k);
            Get<Image>((int)Images.RoZ).gameObject.transform.SetSiblingIndex(k);
            Get<Image>((int)Images.RoY).gameObject.transform.SetSiblingIndex(k);
            Get<Image>((int)Images.RoX).gameObject.transform.SetSiblingIndex(k);
            Get<Image>((int)Images.RoText).gameObject.transform.SetSiblingIndex(k);
            Get<Image>((int)Images.PosZ).gameObject.transform.SetSiblingIndex(k);
            Get<Image>((int)Images.PosY).gameObject.transform.SetSiblingIndex(k);
            Get<Image>((int)Images.PosX).gameObject.transform.SetSiblingIndex(k);
            Get<Image>((int)Images.PosText).gameObject.transform.SetSiblingIndex(k);
        
        }
        else
        {
            tempGo = go;

            if (tempGo == null)
                return;
            Transform tt = tempGo.transform;
            Get<Image>((int)Images.PosX).GetComponentInChildren<TMP_InputField>().text = tt.position.x.ToString();
            Get<Image>((int)Images.PosY).GetComponentInChildren<TMP_InputField>().text = tt.position.y.ToString();
            Get<Image>((int)Images.PosZ).GetComponentInChildren<TMP_InputField>().text = tt.position.z.ToString();
            Get<Image>((int)Images.RoX).GetComponentInChildren<TMP_InputField>().text = tt.eulerAngles.x.ToString();
            Get<Image>((int)Images.RoY).GetComponentInChildren<TMP_InputField>().text = tt.eulerAngles.y.ToString();
            Get<Image>((int)Images.RoZ).GetComponentInChildren<TMP_InputField>().text = tt.eulerAngles.z.ToString();


            Get<Image>((int)Images.Empty).gameObject.SetActive(true);
            Get<Image>((int)Images.PosText).gameObject.SetActive(true);
            Get<Image>((int)Images.PosX).gameObject.SetActive(true);
            Get<Image>((int)Images.PosY).gameObject.SetActive(true);
            Get<Image>((int)Images.PosZ).gameObject.SetActive(true);
            Get<Image>((int)Images.RoText).gameObject.SetActive(true);
            Get<Image>((int)Images.RoX).gameObject.SetActive(true);
            Get<Image>((int)Images.RoY).gameObject.SetActive(true);
            Get<Image>((int)Images.RoZ).gameObject.SetActive(true);

            Get<Image>((int)Images.Empty).gameObject.transform.SetSiblingIndex(i);
            Get<Image>((int)Images.RoZ).gameObject.transform.SetSiblingIndex(i);
            Get<Image>((int)Images.RoY).gameObject.transform.SetSiblingIndex(i);
            Get<Image>((int)Images.RoX).gameObject.transform.SetSiblingIndex(i);
            Get<Image>((int)Images.RoText).gameObject.transform.SetSiblingIndex(i);
            Get<Image>((int)Images.PosZ).gameObject.transform.SetSiblingIndex(i);
            Get<Image>((int)Images.PosY).gameObject.transform.SetSiblingIndex(i);
            Get<Image>((int)Images.PosX).gameObject.transform.SetSiblingIndex(i);
            Get<Image>((int)Images.PosText).gameObject.transform.SetSiblingIndex(i);
        }
    }

    public void SetPosFalse()
    {
        Get<Image>((int)Images.Empty).gameObject.SetActive(false);
        Get<Image>((int)Images.PosText).gameObject.SetActive(false);
        Get<Image>((int)Images.PosX).gameObject.SetActive(false);
        Get<Image>((int)Images.PosY).gameObject.SetActive(false);
        Get<Image>((int)Images.PosZ).gameObject.SetActive(false);
        Get<Image>((int)Images.RoText).gameObject.SetActive(false);
        Get<Image>((int)Images.RoX).gameObject.SetActive(false);
        Get<Image>((int)Images.RoY).gameObject.SetActive(false);
        Get<Image>((int)Images.RoZ).gameObject.SetActive(false);
    }

    public void dkwhwrkxek()
    {
        int ii = 10000;
        Get<Image>((int)Images.Empty).gameObject.transform.SetSiblingIndex(ii);
        Get<Image>((int)Images.RoZ).gameObject.transform.SetSiblingIndex(ii);
        Get<Image>((int)Images.RoY).gameObject.transform.SetSiblingIndex(ii);
        Get<Image>((int)Images.RoX).gameObject.transform.SetSiblingIndex(ii);
        Get<Image>((int)Images.RoText).gameObject.transform.SetSiblingIndex(ii);
        Get<Image>((int)Images.PosZ).gameObject.transform.SetSiblingIndex(ii);
        Get<Image>((int)Images.PosY).gameObject.transform.SetSiblingIndex(ii);
        Get<Image>((int)Images.PosX).gameObject.transform.SetSiblingIndex(ii);
        Get<Image>((int)Images.PosText).gameObject.transform.SetSiblingIndex(ii);
    }

    public void Plus30()
    {
        if(Get<Image>((int)Images.RealHierarchyPanel).transform.childCount >= 26)
        Get<Image>((int)Images.RealHierarchyPanel).GetComponent<RectTransform>().sizeDelta = 
            new Vector2(Get<Image>((int)Images.RealHierarchyPanel).GetComponent<RectTransform>().sizeDelta.x,
            Get<Image>((int)Images.RealHierarchyPanel).GetComponent<RectTransform>().sizeDelta.y + 30f);
    }
    public void Minus30()
    {
        if (Get<Image>((int)Images.RealHierarchyPanel).transform.childCount >= 26)
            Get<Image>((int)Images.RealHierarchyPanel).GetComponent<RectTransform>().sizeDelta =
           new Vector2(Get<Image>((int)Images.RealHierarchyPanel).GetComponent<RectTransform>().sizeDelta.x,
           Get<Image>((int)Images.RealHierarchyPanel).GetComponent<RectTransform>().sizeDelta.y - 30f);
    }

    //public void Plus270()
    //{
    //    if (Get<Image>((int)Images.RealHierarchyPanel).transform.childCount >= 17)
    //    {
    //        int k = Get<Image>((int)Images.RealHierarchyPanel).transform.childCount + 9 - 26;
            
    //        Get<Image>((int)Images.RealHierarchyPanel).GetComponent<RectTransform>().sizeDelta =
    //       new Vector2(Get<Image>((int)Images.RealHierarchyPanel).GetComponent<RectTransform>().sizeDelta.x,
    //       Get<Image>((int)Images.RealHierarchyPanel).GetComponent<RectTransform>().sizeDelta.y + 30f*k);
    //    }
    //}

    //public void Minus270()
    //{
    //    if (Get<Image>((int)Images.RealHierarchyPanel).transform.childCount >= 17)
    //    {
    //        int k = Get<Image>((int)Images.RealHierarchyPanel).transform.childCount + 9 - 26;

    //        Get<Image>((int)Images.RealHierarchyPanel).GetComponent<RectTransform>().sizeDelta =
    //       new Vector2(Get<Image>((int)Images.RealHierarchyPanel).GetComponent<RectTransform>().sizeDelta.x,
    //       Get<Image>((int)Images.RealHierarchyPanel).GetComponent<RectTransform>().sizeDelta.y - 30f * k);
    //    }
    //}

}
