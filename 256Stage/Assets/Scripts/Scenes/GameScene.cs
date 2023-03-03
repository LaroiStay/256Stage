using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    private void Awake()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();
<<<<<<< HEAD
=======
        Manager.UI_Instance.ShowSceneUI<BasicWindow>();
        Manager.UI_Instance.ShowSceneUI<HierarchyCanvas>();
>>>>>>> 256_woo
        SceneType = Define.Scene.Game;
    }
    public override void Clear()
    {
       
    }
}
