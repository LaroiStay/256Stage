using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class cshControlSky : MonoBehaviour
{
    public Material dayMat;
    public Material nightMat;
    public Material spaceMat;
    public Material animationMat;

    public GameObject dayLight;
    public GameObject nightLight;

    public Color dayFog;
    public Color nightFog;

    public int weatherNum = 0;
    private int previousWeatherNum = -1;
    private float Firstfloat;


    private void Start()
    {
        Firstfloat = dayLight.GetComponent<Light>().intensity;
    }

    public void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 0.5f);
        if (weatherNum != previousWeatherNum)
        {
            previousWeatherNum = weatherNum;

            switch (weatherNum)
            {
                case 0:
                    dayday();
                    break;
                case 1:
                    nightnight();
                    break;
                case 2:
                    spacespace();
                    break;
                case 3:
                    aniani();
                    break;
            }
        }
    }

    /*void OnGUI()
    {
        if (GUI.Button(new Rect(1800, 240, 100, 30), "Day"))
        {
            RenderSettings.skybox = dayMat;
            RenderSettings.fogColor = dayFog;
            dayLight.SetActive(true);
            nightLight.SetActive(false);
        }

        if (GUI.Button(new Rect(1800, 440, 100, 30), "Night"))
        {
            RenderSettings.skybox = nightMat;
            RenderSettings.fogColor = nightFog;
            dayLight.SetActive(false);
            nightLight.SetActive(true);
        }
    }*/
    public void dayday()
    {
        RenderSettings.skybox = dayMat;
        RenderSettings.fog = true;
        RenderSettings.fogMode = FogMode.Linear;
        RenderSettings.fogStartDistance = 0f; // ���� �Ÿ�
        RenderSettings.fogEndDistance = 50f; // �� �Ÿ�
        RenderSettings.fogColor = dayFog;
        dayLight.SetActive(true);
        dayLight.GetComponent<Light>().intensity = Firstfloat;
        nightLight.SetActive(false);
    }
    public void nightnight()
    {
        /*RenderSettings.skybox = nightMat;
        RenderSettings.fogColor = nightFog;
        dayLight.SetActive(false);
       */
        RenderSettings.fog = true;
        RenderSettings.fogMode = FogMode.Linear;
        RenderSettings.fogStartDistance = 10f; // ���� �Ÿ�
        RenderSettings.fogEndDistance = 50f; // �� �Ÿ�
        RenderSettings.skybox = nightMat;
        RenderSettings.fogColor = nightFog;
        nightLight.SetActive(true);
        dayLight.SetActive(false);
    }
    public void spacespace()
    {
        RenderSettings.skybox = spaceMat;
        dayLight.SetActive(true);
        dayLight.GetComponent<Light>().intensity = 1f;
        nightLight.SetActive(true);
    }
    public void aniani()
    {

        RenderSettings.skybox = animationMat;
        RenderSettings.fogColor = dayFog;
        dayLight.GetComponent<Light>().intensity = 1f;
        nightLight.SetActive(true);
    }
}
