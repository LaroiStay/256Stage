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
    HierarchyCanvas HC;
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
        HC = GetComponentInParent<HierarchyCanvas>();
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
            HC.dkwhwrkxek();
            int k = GetChildIndex(transform.parent.gameObject, this.gameObject);
            CurrentObject.selectedCurrentObject = go;
            HC.GetNum(CurrentObject.selectedCurrentObject, k);
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
            HC.dkwhwrkxek();
            TO.SetButtonStateOther(Define.CurrentClickMode.Transform , go);
            int k = GetChildIndex(transform.parent.gameObject, this.gameObject);
            CurrentObject.selectedCurrentObject = go;
            HC.GetNum(CurrentObject.selectedCurrentObject, k);
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




    int GetChildIndex(GameObject parent, GameObject child)
    {
        Transform parentTransform = parent.transform;
        Transform childTransform = child.transform;

        for (int i = 0; i < parentTransform.childCount; i++)
        {
            if (parentTransform.GetChild(i) == childTransform)
            {
                return i;
            }
        }
        return -1; // 자식 오브젝트가 부모 오브젝트의 자식 리스트에 없는 경우
    }
}
