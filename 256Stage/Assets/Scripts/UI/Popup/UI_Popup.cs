using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Popup : UI_Base
{
    public virtual void init()
    {
        Manager.UI_Instance.SetCanvas(gameObject, true);
    }

  
}
