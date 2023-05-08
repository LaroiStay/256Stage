using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using UnityEngine.UI;


public class PlayerSelectPage : UI_ETC
{

    string path = "UI/EE/Stage2";

    enum Panels
    {
        stage,
        CreatePlayerPanel
    }
    enum TMP
    {
        project,
    }
    enum TMPInput
    {

        NewStageNAme
    }

    enum Buttons
    {
        Stage1,
        CreatePlayerButton,
        Blue
    }

    private void Start()
    {
        BindThings();
        DoFirstThing();
        BindFuc();
    }

    void BindThings()
    {
        Bind<Image>(typeof(Panels));
        Bind<TextMeshProUGUI>(typeof(TMP));
        Bind<Button>(typeof(Buttons));
        Bind<TMP_InputField>(typeof(TMPInput));

    }

    void DoFirstThing()
    {
        Get<Image>((int)Panels.CreatePlayerPanel).gameObject.SetActive(false);
        int ix = ES3.Load<int>("TotalCount", 0);
        
        Get<TextMeshProUGUI>((int)TMP.project).text = $"There is {ix} project HERE!";
        if(ix != 0)
        {
            string[] names = ES3.Load<string[]>("SceneNames");
            int [] SceneList = ES3.Load<int[]>("SceneList");
            int[] SceneTypeList = ES3.Load<int[]>("CurrentSceneTypes");
            for (int i = 0; i<ix; i++)
            {
                GameObject go = Manager.Resource_Instance.Instantiate(path);
                go.transform.parent = Get<Image>((int)Panels.stage).gameObject.transform;
                Stage2 S2 = go.GetComponent<Stage2>();
                S2.name = names[i];
                S2.SceneNum = SceneList[i];
                if(SceneTypeList[i] == 1)
                    S2.SceneType = Define.Scene.Kwon;
                else if(SceneTypeList[i] == 2)
                    S2.SceneType = Define.Scene.SceneSample1;
                else if (SceneTypeList[i] == 3)
                    S2.SceneType = Define.Scene.Proscenium;
                else
                    return;
                //if()
                //S2.ObjectKey = ES3.Load<int[]>($"{SceneList[i]}KeyS");
                //S2.ObjectName = ES3.Load<string[]>($"{SceneList[i]}NameS");
                //S2.GameobjectPos = ES3.Load<Vector3[]>($"{SceneList[i]}Pos");
                //S2.GameobjectRotation = ES3.Load<Vector3[]>($"{SceneList[i]}Rotation");
                S2.STA();
            }
        }

    }


    void BindFuc()
    {
        Get<Button>((int)Buttons.Stage1).onClick.AddListener(CreateNew);
        Get<Button>((int)Buttons.CreatePlayerButton).onClick.AddListener(CreateButton);
        Get<Button>((int)Buttons.Blue).onClick.AddListener(CreateNew);

    }





    void CreateNew()
    {
        Get<Image>((int)Panels.CreatePlayerPanel).gameObject.SetActive(true);
    }

    void CreateButton()
    {
        string s = Get<TMP_InputField>((int)TMPInput.NewStageNAme).text;
        if (s == "")
            return;
        ES3.Save("CurrentStageName", s);
        Manager.UI_Instance.CloseETCUI<PlayerSelectPage>();

        Manager.Scene_Instance.LoadScene(Define.Scene.StageSelect);
    }






    //public GameObject createStagePanel;
    //public TMP_Text[] slotText;

    //public TMP_Text newStageName;

    //bool[] savefile = new bool[4];

    //void Start()
    //{
    //    for (int i = 0; i < 4; i++)
    //    {
    //        if (!File.Exists(DataManager.instance.path + $"{i}"))
    //        {
    //            slotText[i].text = "No Player";
    //        }
    //        else
    //        {
    //            savefile[i] = true;
    //            DataManager.instance.nowSlot = i;
    //            DataManager.instance.LoadData();
    //            slotText[i].text = DataManager.instance.nowPlayer.StageName;

    //        }
    //    }
    //    DataManager.instance.DataClear();

    //}
    //public void Slot(int number)
    //{
    //    DataManager.instance.nowSlot = number;
    //    if (savefile[number])
    //    {

    //        DataManager.instance.LoadData();

    //        GotoStageSelect();
    //    }
    //    else
    //    {

    //        CreateSlot();
    //    }
    //}
    //public void DeleteSlot(int number)
    //{
    //    DataManager.instance.nowSlot = number;
    //    if (savefile[number])
    //    {
    //        DataManager.instance.DeleteData();
    //        SceneManager.LoadScene(1);
    //    }
    //    else
    //    {

    //    }
    //}
    //public void CreateSlot()
    //{
    //    NewMethod();

    //}

    //private void NewMethod()
    //{
    //    createStagePanel.gameObject.SetActive(true);
    //}

    //public void GotoStageSelect()
    //{
    //    if (!savefile[DataManager.instance.nowSlot])
    //    {
    //        DataManager.instance.nowPlayer.StageName = newStageName.text;
    //        DataManager.instance.SaveData();
    //    }
    //    //SceneManager.LoadScene(2);
    //}

}
