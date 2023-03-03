using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;


public class PlayerSelectScene : MonoBehaviour
{

    public GameObject createStagePanel;
    public TMP_Text[] slotText;

    public TMP_Text newStageName;

    bool[] savefile = new bool[4];

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            if (File.Exists(DataManager.instance.path + $"{i}"))
            {
                savefile[i] = true;
                DataManager.instance.nowSlot = i;
                DataManager.instance.LoadData();
                slotText[i].text = DataManager.instance.nowPlayer.StageName;

            }
            else
            {
                slotText[i].text = "No Player";
            }
        }
        DataManager.instance.DataClear();

    }
    public void Slot(int number)
    {
        DataManager.instance.nowSlot = number;
        if (savefile[number])
        {

            DataManager.instance.LoadData();

            GotoStageSelect();
        }
        else
        {

            CreateSlot();
        }
    }
    public void DeleteSlot(int number)
    {
        DataManager.instance.nowSlot = number;
        if (savefile[number])
        {
            DataManager.instance.DeleteData();
            //SceneManager.LoadScene(0);
        }
        else
        {

        }
    }
    public void CreateSlot()
    {
        createStagePanel.gameObject.SetActive(true);

    }
    public void GotoStageSelect()
    {
        if (!savefile[DataManager.instance.nowSlot])
        {
            DataManager.instance.nowPlayer.StageName = newStageName.text;
            DataManager.instance.SaveData();
        }
        SceneManager.LoadScene(2);
    }

}
