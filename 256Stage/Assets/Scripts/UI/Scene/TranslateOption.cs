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
    
    enum OptionButton{
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
    }
    void TranslateMouseMove()
    {
        Debug.Log("TranslateMouse");
        //IsOn = true;
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
        if (IsOn)
        {
            Collider[] colliders = CurrentObject.selectedCurrentObject.GetComponentsInChildren<Collider>();
            if (colliders.Length > 0)
                for (int i = 0; i < colliders.Length; i++)
                    colliders[i].enabled = false;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                CurrentObject.selectedCurrentObject.transform.position = hit.point;
            }
        }
    }*/
    
    /*private void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // ���콺 ��ǥ���� ��� ray

        // �ٴڿ� ray hit�� �� ��� ������Ʈ�� ��ǥ�� �浹�� ��ǥ�� �ٲ۴�..
        // ���� y��ǥ�� �ٲ�� �ȵǹǷ� ������ ������ fixedY�� �ٲٵ��� �Ѵ�.
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Floor")))
        {
            Debug.Log(hit.transform.name);
            Vector3 nextPos = hit.point;
            nextPos.y = fixedY;
            transform.position = nextPos;
        }
    }*/
}