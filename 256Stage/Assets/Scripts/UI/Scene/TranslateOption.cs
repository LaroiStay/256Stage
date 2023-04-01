using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using Unity.VisualScripting;
using RTG;

public class TranslateOption : UI_Scene
{

    Define.CurrentClickMode CurrentMode = Define.CurrentClickMode.Base;
    List<Gizmo> gizmos = new List<Gizmo>();
    GameObject Currentobj;
    

    //RaycastHit hit;
    //float fixedY;
    //[HideInInspector] public static bool IsOn = false;

    enum OptionButton
    {
        HandIcon,
        TranslateIcon,
        RotationIcon,
        ScaleIcon

    }
    void OptionBindThings()
    {
        Bind<Button>(typeof(OptionButton));
    }
    void Start()
    {
        Currentobj = GameObject.Find("Plane");

        OptionBindThings();

        Get<Button>((int)OptionButton.HandIcon).onClick.AddListener(HandMouseMove);
        Get<Button>((int)OptionButton.TranslateIcon).onClick.AddListener(TranslateMouseMove);
        Get<Button>((int)OptionButton.RotationIcon).onClick.AddListener(RotationMouseMove);
        Get<Button>((int)OptionButton.ScaleIcon).onClick.AddListener(ScaleMouseMove);
    }

    void HandMouseMove()
    {

        SetButtonDefault(Define.CurrentClickMode.Handle);

        //cshCameraMouse.isAlt = true;
        //cshCameraMouse.isTranslate = false;
    }
    void TranslateMouseMove()
    {

        SetButtonDefault(Define.CurrentClickMode.Transform);

        //Debug.Log("TranslateMouse");
        //cshCameraMouse.isAlt = false;

        //cshCameraMouse.isTranslate = true;
    }
    void RotationMouseMove()
    {
        SetButtonDefault(Define.CurrentClickMode.Rotation);

        //Debug.Log("RotationMouse");
    }



    void ScaleMouseMove()
    {
        SetButtonDefault(Define.CurrentClickMode.Scale);
    }




    void SetButtonDefault(Define.CurrentClickMode ToChangmode)
    {
        Currentobj = GameObject.Find("Plane");
        gizmosClear();
        if (CurrentMode == Define.CurrentClickMode.Base)
        {
            CurrentMode = ToChangmode;
        }
        else if (CurrentMode == ToChangmode)
        {
            CurrentMode = Define.CurrentClickMode.Base;
        }
        else
        {
            Get<Button>((int)CurrentMode-1).GetComponent<Animator>().Play("anim");
            Debug.Log(CurrentMode);
            CurrentMode = ToChangmode;
        }
    }



    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Pla")
                    return;
                GameObject clickedObject = hit.transform.gameObject;
                if (clickedObject == Currentobj)
                    return;
                Currentobj = clickedObject;
                switch (CurrentMode)
                {
                    case Define.CurrentClickMode.Base:
                        break;
                    case Define.CurrentClickMode.Transform:
                        gizmosClear();
                        var transformGizmo = RTGizmosEngine.Get.CreateObjectMoveGizmo();
                        transformGizmo.SetTargetObject(clickedObject);
                        transformGizmo.SetTransformSpace(GizmoSpace.Local);
                        gizmos.Add(transformGizmo.Gizmo);
                        break;
                    case Define.CurrentClickMode.Rotation:
                        gizmosClear();
                         var rotationGizmo = RTGizmosEngine.Get.CreateObjectRotationGizmo();
                        rotationGizmo.SetTargetObject(clickedObject);
                        rotationGizmo.SetTransformSpace(GizmoSpace.Local);
                        gizmos.Add(rotationGizmo.Gizmo);
                        break;
                }
            }
           
        }

    }


    void gizmosClear()
    {
        if (gizmos.Count == 0)
            return;
        foreach (var GG in gizmos)
            GG.SetEnabled(false);
        gizmos.Clear();
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
