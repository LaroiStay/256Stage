using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ETC : UI_Base
{
    public virtual void init()
    {
        Manager.UI_Instance.SetCanvasUIETC(gameObject);
    }
}
