using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static RTG.Object2ObjectSnap;


public class BottomCanvas : UI_ETC
{
    bool flag = true;
    string PlayerPath = "Player/FirstPersonController";
    bool whatthe = true;


    public static GameObject MainCam;
    public static GameObject MainCamMove;
    public static GameObject RTG;


    public cshControlSky controlSky;
    HierarchyCanvas HC;
    CamOptions CO;
    enum Buttons
    {
        StageTooltip,
        Aarea,
        Barea,
        Carea,
        Darea,
        Earea,
        DayButton,
        NightButton
    }

    enum Tooltips
    {
        tooltip
    }


    private void Start()
    {
        
        if (whatthe)
        {
            BingThings();
            DoFirstThing();
            setFunc();
            whatthe = false;
            //controlSky =GameObject.Find("SkyBox").GetComponent<cshControlSky>();

        }
       
        //DoFirstThing();
    }


    void BingThings()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Image>(typeof(Tooltips));
    }

    void DoFirstThing()
    {
        MainCam = GameObject.Find("Main Camera");
        MainCamMove = GameObject.Find("CameraMove");
        RTG = GameObject.Find("RTGApp");
        HC = GameObject.Find("HierarchyCanvas").GetComponent<HierarchyCanvas>();
    }

    void setFunc()
    {
        Get<Button>((int)Buttons.StageTooltip).onClick.AddListener(SetToolTip);
        Get<Button>((int)Buttons.Aarea).onClick.AddListener(AA);
        Get<Button>((int)Buttons.Barea).onClick.AddListener(BB);
        Get<Button>((int)Buttons.Carea).onClick.AddListener(CC);
        Get<Button>((int)Buttons.Darea).onClick.AddListener(DD);
        Get<Button>((int)Buttons.Earea).onClick.AddListener(EE);
        //Get<Button>((int)Buttons.DayButton).onClick.AddListener(Dayday);
       // Get<Button>((int)Buttons.NightButton).onClick.AddListener(Nightnight);
        Get<Image>((int)Tooltips.tooltip).gameObject.SetActive(false);
    }


    void SetToolTip()
    {
        if (flag)
        {
            flag = false;
            Get<Image>((int)Tooltips.tooltip).gameObject.SetActive(true);
        }
        else
        {
            flag = true;
            Get<Image>((int)Tooltips.tooltip).gameObject.SetActive(false);
        }
    }



    void AA()
    {


        MainCam.SetActive(false);
        RTG.SetActive(false);
        Manager.Resource_Instance.Instantiate(PlayerPath).transform.position = GameObject.Find("A").transform.position;
        HC.ObjectSave();
        TurnCOOff();
        MainCamMove.SetActive(false);
        Manager.UI_Instance.ClearETCUI();
        Manager.UI_Instance.ShowUI<JText>();
    }
    void BB()
    {
        MainCam.SetActive(false);
        TurnCOOff();
        RTG.SetActive(false);
        Manager.Resource_Instance.Instantiate(PlayerPath).transform.position = GameObject.Find("B").transform.position;
        MainCamMove.SetActive(false);
        HC.ObjectSave();




        Manager.UI_Instance.ClearETCUI();
        Manager.UI_Instance.ShowUI<JText>();
    }
    void CC()
    {
        MainCam.SetActive(false);
        TurnCOOff();
        RTG.SetActive(false);
        Manager.Resource_Instance.Instantiate(PlayerPath).transform.position = GameObject.Find("C").transform.position;
        MainCamMove.SetActive(false);
        HC.ObjectSave();


        //Manager.UI_Instance.CloseETCUI<TopBackgroundCanvas>();
        //Manager.UI_Instance.CloseETCUI<BasicWindow>();
        //Manager.UI_Instance.CloseETCUI<HierarchyCanvas>();
        //Manager.UI_Instance.CloseETCUI<TranslateOption>();
        //Debug.Log("1");
        //Manager.UI_Instance.CloseETCUI<BottomCanvas>();
        //Debug.Log("2");
        Manager.UI_Instance.ClearETCUI();
        Manager.UI_Instance.ShowUI<JText>();
    }
    void DD()
    {
        MainCam.SetActive(false);
        TurnCOOff();
        RTG.SetActive(false);
        Manager.Resource_Instance.Instantiate(PlayerPath).transform.position = GameObject.Find("D").transform.position;
        MainCamMove.SetActive(false);
        HC.ObjectSave();

        Manager.UI_Instance.ClearETCUI();
        Manager.UI_Instance.ShowUI<JText>();
    }
    void EE()
    {
        MainCam.SetActive(false);
        TurnCOOff();
        RTG.SetActive(false);
        Manager.Resource_Instance.Instantiate(PlayerPath).transform.position = GameObject.Find("E").transform.position;
        MainCamMove.SetActive(false);
        HC.ObjectSave();

        Manager.UI_Instance.ClearETCUI();
        Manager.UI_Instance.ShowUI<JText>();
    }
    void TurnCOOff()
    {
        if (CO == null)
            CO = GameObject.Find("CamOptions").GetComponent<CamOptions>();
        CO.OFFCamOption();
    }

    void Dayday()
    {
        controlSky.daynight = true;
    }
    void Nightnight()
    {

        controlSky.daynight = false;
    }

    void SaveHi()
    {
        GameObject.Find("HierarchyCanvas").GetComponent<HierarchyCanvas>().ObjectSave();
    }


}
