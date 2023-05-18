using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KwonScene : BaseScene
{
    private void Awake()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();
        Manager.UI_Instance.ShowUI<BasicWindow>();
        Manager.UI_Instance.ShowUI<HierarchyCanvas>();
        Manager.UI_Instance.ShowUI<TranslateOption>();
        Manager.UI_Instance.ShowUI<TopBackgroundCanvas>();
        Manager.UI_Instance.ShowUI<BottomCanvas>();
        Manager.UI_Instance.ShowUI<CamOptions>();
        SceneType = Define.Scene.Kwon;
    
    }

    public override void Clear()
    {
       
    }
}
