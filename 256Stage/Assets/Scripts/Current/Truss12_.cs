using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truss12_ : MonoBehaviour
{
    string UpPath = "Stage/Truss/TrussHelp/UpTruss";
    string DownPath = "Stage/Truss/TrussHelp/DownTruss";
    public Transform trasn1;
    public Transform trasn2;
    public Transform trasn3;


    void Start()
    {
        GameObject go1 = Manager.Resource_Instance.Instantiate(UpPath);
        go1.transform.SetParent(this.transform);
        go1.transform.position = trasn1.position;
        GameObject go2 = Manager.Resource_Instance.Instantiate(DownPath);
        go2.transform.SetParent(this.transform);
        go2.transform.position = trasn1.position;



        GameObject go3 = Manager.Resource_Instance.Instantiate(UpPath);
        go3.transform.SetParent(this.transform);
        go3.transform.position = trasn2.position;
        GameObject go4 = Manager.Resource_Instance.Instantiate(DownPath);
        go4.transform.SetParent(this.transform);
        go4.transform.position = trasn2.position;



        GameObject go5 = Manager.Resource_Instance.Instantiate(UpPath);
        go5.transform.SetParent(this.transform);
        go5.transform.position = trasn3.position;
        GameObject go6 = Manager.Resource_Instance.Instantiate(DownPath);
        go6.transform.SetParent(this.transform);
        go6.transform.position = trasn3.position;
    }


}
