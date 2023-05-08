using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectScene : BaseScene
{
    private void Awake()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();
        Manager.UI_Instance.ShowUI<StageSelect>();
        SceneType = Define.Scene.StageSelect;
    }

    public override void Clear()
    {

    }
}
