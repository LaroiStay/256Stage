using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using Unity.VisualScripting;

public class TranslateOption : UI_Scene
{
    //RaycastHit hit;
    //float fixedY;
    //[HideInInspector] public static bool IsOn = false;

    enum OptionButton
    {
        HandIcon, TranslateIcon, RotationIcon, ScaleIcon

    }
    void OptionBindThings()
    {
        Bind<Button>(typeof(OptionButton));
    }
    void Start()
    {
        OptionBindThings();

        Get<Button>((int)OptionButton.HandIcon).onClick.AddListener(HandMouseMove);
        Get<Button>((int)OptionButton.TranslateIcon).onClick.AddListener(TranslateMouseMove);
        Get<Button>((int)OptionButton.RotationIcon).onClick.AddListener(RotationMouseMove);
        Get<Button>((int)OptionButton.ScaleIcon).onClick.AddListener(ScaleMouseMove);
    }

    void HandMouseMove()
    {
        Debug.Log("HandMouse");
        cshCameraMouse.isAlt = true;

        cshCameraMouse.isTranslate = false;
    }
    void TranslateMouseMove()
    {
        Debug.Log("TranslateMouse");

        cshCameraMouse.isAlt = false;

        cshCameraMouse.isTranslate = true;
    }
    void RotationMouseMove()
    {

        Debug.Log("RotationMouse");
    }
    void ScaleMouseMove()
    {
        Debug.Log("ScaleMouse");
    }

    /*void Update()
    {
    }*/
    
    /*private void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 마우스 좌표에서 쏘는 ray

        // 바닥에 ray hit이 된 경우 오브젝트의 좌표를 충돌된 좌표로 바꾼다..
        // 물론 y좌표는 바뀌면 안되므로 사전에 저장한 fixedY로 바꾸도록 한다.
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Floor")))
        {
            Debug.Log(hit.transform.name);
            Vector3 nextPos = hit.point;
            nextPos.y = fixedY;
            transform.position = nextPos;
        }
    }*/
}
