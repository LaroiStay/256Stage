using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TempHierarchyButton : UI_Base
{
    [HideInInspector] public GameObject go;
    GameObject Cam;
    TranslateOption TO;
    float distance = 10f;
    [HideInInspector] public string nameS;
    [HideInInspector] public int KeyS;

    enum Texts
    {
        Text
    }
    
    enum Buttons
    {
        TempHierarchyButton
    }

    private void Start()
    {
        Cam = GameObject.Find("Main Camera");
        TO = GameObject.Find("TranslateOption").GetComponent<TranslateOption>();
    }


    void BindThing()
    {
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Button>(typeof(Buttons));
    }

    public void setName(string name, int key)
    {
        nameS = name;
        KeyS = key;
        BindThing();
        Get<TextMeshProUGUI>((int)Texts.Text).text = $"  > {name}{key}";
    }

    public void setGameObject(GameObject tempgo)
    {
        go = tempgo;
        Get<Button>((int)Buttons.TempHierarchyButton).onClick.AddListener(ClickButton);
    }

    void ClickButton()
    {
        if (CurrentObject.selectedCurrentObject == null)
        {
            CurrentObject.selectedCurrentObject = go;
            TO.SetButtonStateOther(Define.CurrentClickMode.Transform , CurrentObject.selectedCurrentObject);
            Vector3 direction = CurrentObject.selectedCurrentObject.transform.position - Cam.transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction, Cam.transform.up);

            // 카메라를 오브젝트에서 일정 거리만큼 떨어진 위치로 이동
            Cam.transform.position = CurrentObject.selectedCurrentObject.transform.position - rotation * Vector3.forward * distance;
            Cam.transform.rotation = rotation;
            Cam.transform.localEulerAngles = new Vector3(Cam.transform.localEulerAngles.x, Cam.transform.localEulerAngles.y, 0);
        }
        else /*(CurrentObject.selectedCurrentObject != go)*/
        {

            TO.SetButtonStateOther(Define.CurrentClickMode.Transform , go);
            CurrentObject.selectedCurrentObject = go;
            Vector3 direction = CurrentObject.selectedCurrentObject.transform.position - Cam.transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction, Cam.transform.up);

            // 카메라를 오브젝트에서 일정 거리만큼 떨어진 위치로 이동
            Cam.transform.position = CurrentObject.selectedCurrentObject.transform.position - rotation * Vector3.forward * distance;
            Cam.transform.rotation = rotation;
            Cam.transform.localEulerAngles = new Vector3(Cam.transform.localEulerAngles.x, Cam.transform.localEulerAngles.y, 0);
        }
        //else
        //{
        //    TO.SetButtonStateOther(Define.CurrentClickMode.Base);
        //    Cam.transform.LookAt(CurrentObject.selectedCurrentObject.transform);
        //    CurrentObject.selectedCurrentObject = null;
        //}
    }

}
