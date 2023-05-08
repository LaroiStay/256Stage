using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{

    string DancingPath = "Player/DancingGirl";

    public Transform DancingPoint;

    // Update is called once per frame
    public void Start()
    {
        DancingPoint = transform.Find("DancingPoint");
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            BottomCanvas.MainCam.SetActive(true);
            BottomCanvas.MainCamMove.SetActive(true);
            BottomCanvas.RTG.SetActive(true);
            Cursor.lockState = CursorLockMode.None; // 마우스 잠금 해제
            Cursor.visible = true; // 마우스 보이게 설정
            Manager.UI_Instance.ShowUI<BasicWindow>();
            Manager.UI_Instance.ShowUI<HierarchyCanvas>();
            Manager.UI_Instance.ShowUI<TranslateOption>();
            Manager.UI_Instance.ShowUI<TopBackgroundCanvas>();
            Manager.UI_Instance.ShowUI<BottomCanvas>();
            Destroy(this.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Mode");

            Manager.UI_Instance.ShowUI<ModeInformation>();

            Invoke("DeleteUI", 2f);
        }
        if(Input.GetKeyDown(KeyCode.P))
        {

            Manager.Resource_Instance.Instantiate(DancingPath).transform.position = DancingPoint.transform.position;

        }
    }
    void DeleteUI()
    {
        Manager.UI_Instance.CloseETCUI<ModeInformation>();
    }
}
