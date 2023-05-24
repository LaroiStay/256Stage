using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mode1Text : UI_ETC
{


    private string mode1Path = "Image/Icon/mode1";
    private string mode2Path = "Image/Icon/mode2";

    Sprite mode1;
    Sprite mode2;

    enum Images
    {
        Mode1
    }

    void BindThings()
    {
        Bind<Image>(typeof(Images));
    }

    void DoFirstThing()
    {
        Get<Image>((int)Images.Mode1).gameObject.SetActive(false);
        mode1 = Manager.Resource_Instance.Load<Sprite>(mode1Path);
        mode2 = Manager.Resource_Instance.Load<Sprite>(mode2Path);
        ChangeMode();
    }

    private void Start()
    {
        BindThings();
        DoFirstThing();
    }

    public void ChangeMode()
    {
        StopAllCoroutines();
        StartCoroutine(ChangeMM());
    }

    IEnumerator ChangeMM()
    {
        Get<Image>((int)Images.Mode1).gameObject.SetActive(true);
       if(Get<Image>((int)Images.Mode1).sprite == mode1)
            Get<Image>((int)Images.Mode1).sprite = mode2;
       else
            Get<Image>((int)Images.Mode1).sprite = mode1;
        yield return new WaitForSeconds(2f);
        Get<Image>((int)Images.Mode1).gameObject.SetActive(false);

    }


}

