using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Scene : MonoBehaviour
{
    public virtual void init()
    {
        Manager.UI_Instance.SetCanvas(gameObject, false);
    }
}
