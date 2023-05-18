using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamInFo : MonoBehaviour
{
    Camera c;
    void Start()
    {
        c = GetComponentInChildren<Camera>();
        c.enabled = false;
    }

    public Camera GetCam()
    {
        c = GetComponentInChildren<Camera>();
        return c;
    }
   
}
