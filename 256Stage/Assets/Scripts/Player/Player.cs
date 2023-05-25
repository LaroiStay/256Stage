using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{

    string DancingPath = "Player/DancingGirl";
    string MusicPath = "Music/";
    Mode1Text Mode;

    public Transform DancingPoint;

    private bool isModeImage;

    // Update is called once per frame
    public void Start()
    {
            
        DancingPoint = transform.Find("DancingPoint");
        Mode = GameObject.Find("Mode1Text").GetComponent<Mode1Text>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            TurnOffLight();
            if (CurrentMusicAudioS.audioSourceDic.Count != 0)
                foreach (var key in CurrentMusicAudioS.audioSourceDic.Keys)
                    key.Stop();

            BottomCanvas.MainCam.SetActive(true);
            BottomCanvas.MainCamMove.SetActive(true);
            BottomCanvas.RTG.SetActive(true);
            Cursor.lockState = CursorLockMode.None; // 마우스 잠금 해제
            Cursor.visible = true; // 마우스 보이게 설정
            Manager.UI_Instance.CloseETCUI<JText>();
            Manager.UI_Instance.CloseETCUI<Mode1Text>();
            Manager.UI_Instance.ShowUI<BasicWindow>();
            Manager.UI_Instance.ShowUI<HierarchyCanvas>();
            Manager.UI_Instance.ShowUI<TranslateOption>();
            Manager.UI_Instance.ShowUI<TopBackgroundCanvas>();
            Manager.UI_Instance.ShowUI<BottomCanvas>();
            GameObject.Find("HierarchyCanvas").GetComponent<HierarchyCanvas>().ObjectsLoad();
            Destroy(this.gameObject);
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            if (isModeImage)
            {
                Mode.ChangeMode();

            }
            else
            {
                Mode.ChangeMode();
            }

            isModeImage = !isModeImage;
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            Manager.Resource_Instance.Instantiate(DancingPath).transform.position = DancingPoint.transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
            MusicOn(1);
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            MusicOn(2);
        else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
            MusicOn(3);
        else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
            MusicOn(4);
        else if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
            MusicOn(5);
        else if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
            MusicOn(6);
        else if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
            MusicOn(7);
        else if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8))
            MusicOn(8);
        else if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9))
            MusicOn(9);
        else if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
            MusicOff();



    }
    
    void DeleteUI()
    {
        Manager.UI_Instance.CloseETCUI<ModeInformation>();
    }

    void MusicOn(int i)
    {
        AudioClip audioClip = Manager.Resource_Instance.Load<AudioClip>($"{MusicPath}{i}");
        if (CurrentMusicAudioS.audioSourceDic.Count != 0)
            foreach (var key in CurrentMusicAudioS.audioSourceDic.Keys)
            {
                key.Stop();
                key.clip = audioClip;
                key.Play();
            }
    }
    void MusicOff()
    {
        if (CurrentMusicAudioS.audioSourceDic.Count != 0)
            foreach (var key in CurrentMusicAudioS.audioSourceDic.Keys)
                key.Stop();
    }



    private void CloseMode1Text()
    {
        Manager.UI_Instance.CloseETCUI<Mode1Text>();
    }

    private void CloseMode2Text()
    {
        Manager.UI_Instance.CloseETCUI<Mode2Text>();
    }
    void TurnOffLight()
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
