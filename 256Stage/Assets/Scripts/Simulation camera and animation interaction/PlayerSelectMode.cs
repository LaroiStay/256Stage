using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectMode : MonoBehaviour
{
    ClickAnimation CA;
    TriggerAnimation TA;
    bool flag = false;

  
    void Start()
    {
        CA = GetComponent<ClickAnimation>();
        TA = GetComponent<TriggerAnimation>();
        flag = false;
        TA.enabled = false;
        CA.enabled = true;

    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && !flag)
        {
            flag = true;
            TA.enabled = true;
            CA.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.M) && flag)
        {
            flag = false;
            TA.enabled = false;
            CA.enabled = true;
        }
    }
}
