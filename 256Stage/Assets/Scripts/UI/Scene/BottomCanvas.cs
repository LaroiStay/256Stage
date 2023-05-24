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

    int intflag = 0;

    public cshControlSky controlSky;
    HierarchyCanvas HC;
    CamOptions CO;
    enum Buttons
    {
        StageTooltip,
        ProsceniumStageTooltip,
        RoundStageTooltip,
        Aarea,
        Barea,
        Carea,
        Darea,
        Earea,
        RAarea,
        RBarea,
        RCarea,
        RDarea,
        REarea,
        RFarea,
        PAarea,
        PBarea,
        PCarea,
        PDarea,
        PEarea,
        PFarea,
        DayButton,
        NightButton,
        UniverseButton,
        AnimationButton,
    }

    enum Tooltips
    {
        tooltip,
        Ptooltip,
        Rtooltip
    }

    private void Start()
    {

        if (whatthe)
        {
            BingThings();
            DoFirstThing();
            setFunc();
            whatthe = false;
            controlSky = GameObject.Find("SkyBox").GetComponent<cshControlSky>();
        }
    }


    void BingThings()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Image>(typeof(Tooltips));
    }

    void DoFirstThing()
    {
        intflag = ES3.Load<int>("CurrentSceneType");
        MainCam = GameObject.Find("Main Camera");
        MainCamMove = GameObject.Find("CameraMove");
        RTG = GameObject.Find("RTGApp");
        HC = GameObject.Find("HierarchyCanvas").GetComponent<HierarchyCanvas>();

        if(intflag == 1)
        {
            Get<Button>((int)Buttons.RoundStageTooltip).gameObject.SetActive(false);
            Get<Button>((int)Buttons.ProsceniumStageTooltip).gameObject.SetActive(false);
            Get<Button>((int)Buttons.StageTooltip).gameObject.SetActive(true);
        }
        else if(intflag == 2)
        {
            Get<Button>((int)Buttons.RoundStageTooltip).gameObject.SetActive(false);
            Get<Button>((int)Buttons.ProsceniumStageTooltip).gameObject.SetActive(true);
            Get<Button>((int)Buttons.StageTooltip).gameObject.SetActive(false);
        }
        else if(intflag == 3)
        {
            Get<Button>((int)Buttons.RoundStageTooltip).gameObject.SetActive(true);
            Get<Button>((int)Buttons.ProsceniumStageTooltip).gameObject.SetActive(false);
            Get<Button>((int)Buttons.StageTooltip).gameObject.SetActive(false);
        } 
        
        

        Get<Image>((int)Tooltips.tooltip).gameObject.SetActive(false);
        Get<Image>((int)Tooltips.Rtooltip).gameObject.SetActive(false);
        Get<Image>((int)Tooltips.Ptooltip).gameObject.SetActive(false);
    }

    void setFunc()
    {
        Get<Button>((int)Buttons.RoundStageTooltip).onClick.AddListener(RSetToolTip);
        Get<Button>((int)Buttons.ProsceniumStageTooltip).onClick.AddListener(PSetToolTip);
        Get<Button>((int)Buttons.StageTooltip).onClick.AddListener(SetToolTip);


        Get<Button>((int)Buttons.Aarea).onClick.AddListener(() =>{Fuc("A");});
        Get<Button>((int)Buttons.Barea).onClick.AddListener(() =>{Fuc("B");});
        Get<Button>((int)Buttons.Carea).onClick.AddListener(() =>{Fuc("C");});
        Get<Button>((int)Buttons.Darea).onClick.AddListener(() =>{Fuc("D");});
        Get<Button>((int)Buttons.Earea).onClick.AddListener(() => { Fuc("E"); });


        Get<Button>((int)Buttons.RAarea).onClick.AddListener(() => { Fuc("A"); });
        Get<Button>((int)Buttons.RBarea).onClick.AddListener(() => { Fuc("B"); });
        Get<Button>((int)Buttons.RCarea).onClick.AddListener(() => { Fuc("C"); });
        Get<Button>((int)Buttons.RDarea).onClick.AddListener(() => { Fuc("D"); });
        Get<Button>((int)Buttons.REarea).onClick.AddListener(() => { Fuc("E"); });
        Get<Button>((int)Buttons.RFarea).onClick.AddListener(() => { Fuc("F"); });


        Get<Button>((int)Buttons.PAarea).onClick.AddListener(() => { Fuc("A"); });
        Get<Button>((int)Buttons.PBarea).onClick.AddListener(() => { Fuc("B"); });
        Get<Button>((int)Buttons.PCarea).onClick.AddListener(() => { Fuc("C"); });
        Get<Button>((int)Buttons.PDarea).onClick.AddListener(() => { Fuc("D"); });
        Get<Button>((int)Buttons.PEarea).onClick.AddListener(() => { Fuc("E"); });
        Get<Button>((int)Buttons.PFarea).onClick.AddListener(() => { Fuc("F"); });



        Get<Button>((int)Buttons.DayButton).onClick.AddListener(Dayday);
        Get<Button>((int)Buttons.NightButton).onClick.AddListener(Nightnight);
        Get<Button>((int)Buttons.UniverseButton).onClick.AddListener(Spacespace);
        Get<Button>((int)Buttons.AnimationButton).onClick.AddListener(Aniani);
    }

    void RSetToolTip()
    {
        if (flag)
        {
            flag = false;
            Get<Image>((int)Tooltips.Rtooltip).gameObject.SetActive(true);
        }
        else
        {
            flag = true;
            Get<Image>((int)Tooltips.Rtooltip).gameObject.SetActive(false);
        }
    }

    void PSetToolTip()
    {
        if (flag)
        {
            flag = false;
            Get<Image>((int)Tooltips.Ptooltip).gameObject.SetActive(true);
        }
        else
        {
            flag = true;
            Get<Image>((int)Tooltips.Ptooltip).gameObject.SetActive(false);
        }
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



    void Fuc(string s)
    {
        MainCam.SetActive(false);
        RTG.SetActive(false);
        Manager.Resource_Instance.Instantiate(PlayerPath).transform.position = GameObject.Find(s).transform.position;
        HC.ObjectSave();
        TurnCOOff();
        MainCamMove.SetActive(false);
        Manager.UI_Instance.ClearETCUI();
        Manager.UI_Instance.ShowUI<Mode1Text>();
        Manager.UI_Instance.ShowUI<JText>();
    }


    //void AA()
    //{
    //    MainCam.SetActive(false);
    //    RTG.SetActive(false);
    //    Manager.Resource_Instance.Instantiate(PlayerPath).transform.position = GameObject.Find("A").transform.position;
    //    HC.ObjectSave();
    //    TurnCOOff();
    //    MainCamMove.SetActive(false);
    //    Manager.UI_Instance.ClearETCUI();
    //    Manager.UI_Instance.ShowUI<Mode1Text>();
    //    Manager.UI_Instance.ShowUI<JText>();
    //}
    //void BB()
    //{
    //    MainCam.SetActive(false);
    //    TurnCOOff();
    //    RTG.SetActive(false);
    //    Manager.Resource_Instance.Instantiate(PlayerPath).transform.position = GameObject.Find("B").transform.position;
    //    MainCamMove.SetActive(false);
    //    HC.ObjectSave();
    //    Manager.UI_Instance.ClearETCUI();
    //    Manager.UI_Instance.ShowUI<Mode1Text>();
    //    Manager.UI_Instance.ShowUI<JText>();
    //}
    //void CC()
    //{
    //    MainCam.SetActive(false);
    //    TurnCOOff();
    //    RTG.SetActive(false);
    //    Manager.Resource_Instance.Instantiate(PlayerPath).transform.position = GameObject.Find("C").transform.position;
    //    MainCamMove.SetActive(false);
    //    HC.ObjectSave();
    //    Manager.UI_Instance.ClearETCUI();
    //    Manager.UI_Instance.ShowUI<Mode1Text>();
    //    Manager.UI_Instance.ShowUI<JText>();
    //}
    //void DD()
    //{
    //    MainCam.SetActive(false);
    //    TurnCOOff();
    //    RTG.SetActive(false);
    //    Manager.Resource_Instance.Instantiate(PlayerPath).transform.position = GameObject.Find("D").transform.position;
    //    MainCamMove.SetActive(false);
    //    HC.ObjectSave();

    //    Manager.UI_Instance.ClearETCUI();
    //    Manager.UI_Instance.ShowUI<Mode1Text>();
    //    Manager.UI_Instance.ShowUI<JText>();
    //}
    //void EE()
    //{
    //    MainCam.SetActive(false);
    //    TurnCOOff();
    //    RTG.SetActive(false);
    //    Manager.Resource_Instance.Instantiate(PlayerPath).transform.position = GameObject.Find("E").transform.position;
    //    MainCamMove.SetActive(false);
    //    HC.ObjectSave();
    //    Manager.UI_Instance.ClearETCUI();
    //    Manager.UI_Instance.ShowUI<Mode1Text>();
    //    Manager.UI_Instance.ShowUI<JText>();
    //}
    void TurnCOOff()
    {
        if (CO == null)
            CO = GameObject.Find("CamOptions").GetComponent<CamOptions>();
        CO.OFFCamOption();
    }

    void Dayday()
    {
        controlSky.weatherNum = 0;

    }
    void Nightnight()
    {


        controlSky.weatherNum = 1;

    }
    void Spacespace()
    {

        controlSky.weatherNum = 2;


    }
    void Aniani()
    {

        controlSky.weatherNum = 3;


    }
    void SaveHi()
    {
        GameObject.Find("HierarchyCanvas").GetComponent<HierarchyCanvas>().ObjectSave();
    }


}
