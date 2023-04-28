using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using Unity.VisualScripting;
using RTG;

public class TranslateOption : UI_ETC
{
    ObjectTransformGizmo TG = null;
    Define.CurrentClickMode CurrentMode = Define.CurrentClickMode.Base;
    List<Gizmo> gizmos = new List<Gizmo>();
    GameObject Currentobj;


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

    }
    void TranslateMouseMove()
    {

        SetButtonDefault(Define.CurrentClickMode.Transform);

    }
    void RotationMouseMove()
    {
        SetButtonDefault(Define.CurrentClickMode.Rotation);

    }



    void ScaleMouseMove()
    {
        SetButtonDefault(Define.CurrentClickMode.Scale);
    }




    public void SetButtonDefault(Define.CurrentClickMode ToChangmode)
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
            CurrentMode = ToChangmode;
        }
    }

    public void SetButtonStateOther(Define.CurrentClickMode ToChangmode, GameObject go)
    {

        if (ToChangmode == Define.CurrentClickMode.Base)
        {
            Get<Button>((int)CurrentMode-1).GetComponent<Animator>().Play("anim");
            CurrentMode = Define.CurrentClickMode.Base;

        }
        else if (ToChangmode == Define.CurrentClickMode.Transform)
        {
            if(CurrentMode == Define.CurrentClickMode.Base)
            {
                CurrentMode = Define.CurrentClickMode.Transform;
                Get<Button>((int)CurrentMode - 1).GetComponent<Animator>().Play("anim 0");
                gizmosClear();
                TG = RTGizmosEngine.Get.CreateObjectMoveGizmo();
                TG.SetTargetObject(go);
                TG.SetTransformSpace(GizmoSpace.Local);
                gizmos.Add(TG.Gizmo);
            }
            else if (CurrentMode == Define.CurrentClickMode.Transform)
            {
                CurrentMode = Define.CurrentClickMode.Transform;
                gizmosClear();
                TG = RTGizmosEngine.Get.CreateObjectMoveGizmo();
                TG.SetTargetObject(go);
                TG.SetTransformSpace(GizmoSpace.Local);
                gizmos.Add(TG.Gizmo);

            }
            else
            {
                Get<Button>((int)CurrentMode - 1).GetComponent<Animator>().Play("anim");
                CurrentMode = Define.CurrentClickMode.Transform;
                Get<Button>((int)CurrentMode - 1).GetComponent<Animator>().Play("anim 0");
                gizmosClear();
                TG = RTGizmosEngine.Get.CreateObjectMoveGizmo();
                TG.SetTargetObject(go);
                TG.SetTransformSpace(GizmoSpace.Local);
                gizmos.Add(TG.Gizmo);
            }
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
                if (hit.transform.tag != "Obj")
                    return;
                GameObject clickedObject = hit.transform.gameObject.GetComponentInParent<Detect>().gameObject;
                Debug.Log(clickedObject);
                if (clickedObject == Currentobj)
                    return;
                Currentobj = clickedObject;
                switch (CurrentMode)
                {
                    case Define.CurrentClickMode.Base:
                        break;
                    case Define.CurrentClickMode.Transform:
                        gizmosClear();
                        TG = RTGizmosEngine.Get.CreateObjectMoveGizmo();
                        TG.SetTargetObject(clickedObject);
                        TG.SetTransformSpace(GizmoSpace.Local);
                        CurrentObject.selectedCurrentObject = clickedObject;
                        gizmos.Add(TG.Gizmo);
                        break;
                    case Define.CurrentClickMode.Rotation:
                        gizmosClear();
                        TG = RTGizmosEngine.Get.CreateObjectRotationGizmo();
                        TG.SetTargetObject(clickedObject);
                        TG.SetTransformSpace(GizmoSpace.Local);
                        CurrentObject.selectedCurrentObject = clickedObject;
                        gizmos.Add(TG.Gizmo);
                        break;
                }
            }
           
        }
        if (TG != null)
            TG.RefreshPositionAndRotation();

    }


    public void gizmosClear()
    {
        if (gizmos.Count == 0)
            return;
        foreach (var GG in gizmos)
            GG.SetEnabled(false);
        gizmos.Clear();
    }






}
