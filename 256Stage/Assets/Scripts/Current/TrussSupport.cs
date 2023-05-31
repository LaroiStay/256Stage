using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrussSupport : MonoBehaviour
{
    string UpPath = "Stage/Truss/TrussHelp/UpTruss";
    public Transform tt;


    void Start()
    {
        GameObject go = Manager.Resource_Instance.Instantiate(UpPath);
        go.transform.SetParent(this.transform);
        go.transform.position = tt.position;
    }

   
}
