using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectMode : MonoBehaviour
{
    ClickAnimation CA;
    TriggerAnimation TA;
    bool flag = false;
    List<GameObject> kk = new List<GameObject>();


    void Start()
    {
        Key();
        CA = GetComponent<ClickAnimation>();
        TA = GetComponent<TriggerAnimation>();
        TA.SetK(kk);
        flag = false;
        TA.enabled = false;
        CA.enabled = true;

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && !flag)
        {
            TurnOff();
            flag = true;
            TA.enabled = true;
            CA.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.M) && flag)
        {
            TurnOff();
            flag = false;
            TA.enabled = false;
            CA.enabled = true;
        }
    }

    void Key()
    {
        if (CurrentObject.LightObj.Count == 0)
        {
            return;
        }
        kk = new List<GameObject>(CurrentObject.LightObj.Keys);
    }

    void TurnOff()
    {
        if (kk.Count == 0)
            return;
        for (int i = 0; i < kk.Count; i++)
        {
            Animator ani = kk[i].GetComponent<Animator>();
            if (ani != null)
                ani.enabled = false;
        }
    }

    public void TurnOffLight()
    {
        List<GameObject> goodgood = new List<GameObject>(CurrentObject.LightObj.Keys);
        if (goodgood.Count == 0)
            return;
        for (int i = 0; i < goodgood.Count; i++)
        {
            Animator ani = goodgood[i].GetComponent<Animator>();
            if (ani != null)
                ani.enabled = false;
        }
    }



}
