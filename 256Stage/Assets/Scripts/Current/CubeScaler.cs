using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CubeScaler : MonoBehaviour
{
    string xScaleInputField, zScaleInputField;
    int num1, num2;
    // Start is called before the first frame update
    private void Awake()
    {
        if (!File.Exists(DataManager.instance.nowPlayer.StageX) && File.Exists(DataManager.instance.nowPlayer.StageY))
        {
            print("NO NUM");
        }
        else
        {
            xScaleInputField = DataManager.instance.nowPlayer.StageX;
            zScaleInputField = DataManager.instance.nowPlayer.StageY;
        }
    }
    void Start()
    {
        //xScaleInputField.onEndEdit.AddListener(delegate { OnXScaleChanged(); });
        //zScaleInputField.onEndEdit.AddListener(delegate { OnZScaleChanged(); });
        
        OnXScaleChanged();
        OnZScaleChanged();
    }


    public void OnXScaleChanged()
    {
        if (int.TryParse(xScaleInputField, out num1))
        {
            transform.localScale = new Vector3(num1, transform.localScale.y, transform.localScale.z);

        }
        else
        {

            print("변환실패");
            // 변환 실패
        }
        //int newScaleX = int.Parse(xScaleInputField);
        //transform.localScale = new Vector3(newScaleX, transform.localScale.y, transform.localScale.z);
    }

    public void OnZScaleChanged()
    {
        if (int.TryParse(zScaleInputField, out num2))
        {
            transform.localScale = new Vector3(num2, transform.localScale.y, transform.localScale.z);

        }
        else
        {
            // 변환 실패
            print("변환실패");
        }
        //int newScaleZ = int.Parse(zScaleInputField);
        //transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, newScaleZ);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
