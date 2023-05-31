using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using RTG;
using System.Linq;

public class TranslateOption : UI_ETC
{
    ObjectTransformGizmo TG = null;
    Define.CurrentClickMode CurrentMode ;
    List<Gizmo> gizmos = new List<Gizmo>();
    GameObject Currentobj;
    CamOptions CO;
    HierarchyCanvas HC;
    GameObject tempSaveScreenObj;
    int tempSaveInt;
    string tempSavestring;
    bool flag = true;
    string pattern = @"\d+$";
    private Vector3 PlusVec = new Vector3(0.5f, 0f, 0f);
    Vector3 TempSaveVec;
    Vector3 TempSaveRot;

    enum OptionButton
    {
        HandIcon,
        TranslateIcon,
        RotationIcon,

    }
    void OptionBindThings()
    {
        Bind<Button>(typeof(OptionButton));
    }
    void Awake()
    {
        Currentobj = GameObject.Find("Plane");
        OptionBindThings();
        Get<Button>((int)OptionButton.HandIcon).onClick.AddListener(HandMouseMove);
        Get<Button>((int)OptionButton.TranslateIcon).onClick.AddListener(TranslateMouseMove);
        Get<Button>((int)OptionButton.RotationIcon).onClick.AddListener(RotationMouseMove);
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



    //void ScaleMouseMove()
    //{
    //    SetButtonDefault(Define.CurrentClickMode.Scale);
    //}




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
             if(CO == null)
                        CO = GameObject.Find("CamOptions").GetComponent<CamOptions>();
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
                if(clickedObject.name == "Screen1")
                {

                    CO.OnCamOption(clickedObject.transform.position, clickedObject.GetComponent<Screen_>().QuadObj);
                    if(tempSaveScreenObj == clickedObject)
                    {
                        CO.OFFCamOption();
                        tempSaveScreenObj = null;
                    }
                    else
                    {
                        tempSaveScreenObj = clickedObject;
                    }
                }
                else
                {
                    CO.OFFCamOption();
                }
                if (clickedObject == Currentobj)
                    return;
                Currentobj = clickedObject;
                CurrentObject.selectedCurrentObject = clickedObject;

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
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.C)&&CurrentObject.selectedCurrentObject != null&&CurrentMode != Define.CurrentClickMode.Base)
        {
            string originalString = CurrentObject.selectedCurrentObject.name;
            Match match = Regex.Match(originalString, pattern);
            string lastNumberString = match.Value;
            tempSaveInt = int.Parse(lastNumberString);
            string pattern2 = @"^[A-Za-z]+";
            Match match2 = Regex.Match(originalString, pattern2);
            tempSavestring = match2.Value;
            TempSaveVec = CurrentObject.selectedCurrentObject.transform.position + PlusVec;
            TempSaveRot = CurrentObject.selectedCurrentObject.transform.eulerAngles;
        }
        else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.V)&&flag && CurrentMode != Define.CurrentClickMode.Base && !EventSystem.current.IsPointerOverGameObject())
        {
            flag = false;
            if (tempSaveInt == 0)
                return;
            if (HC == null)
                HC = GameObject.Find("HierarchyCanvas").GetComponent<HierarchyCanvas>();
            GameObject go = Manager.Resource_Instance.Instantiate($"Stage/{tempSavestring}/{tempSavestring}{tempSaveInt}");
            go.transform.position = TempSaveVec;
            go.transform.eulerAngles = TempSaveRot;
            TempSaveVec = go.transform.position + PlusVec;
            GameObject go2 = FindObjectOfType<HierarchyCanvas>().PlusPrefabsInHierarchy(tempSavestring, tempSaveInt, go);
            List<GameObject> goList = new List<GameObject>();
            goList.Add(go);
            goList.Add(go2);
            var postObjectSpawnAction = new PostObjectSpawnAction(goList);
            postObjectSpawnAction.Execute();
            postObjectSpawnAction.OnRemovedFromUndoRedoStack();
            HC.Plus30();
        }
        else if(CurrentObject.selectedCurrentObject == null)
        {
            tempSaveInt = 0;
            tempSavestring = "";
        }
        else
        {
            flag = true;
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
