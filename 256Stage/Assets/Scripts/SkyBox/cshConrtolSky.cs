using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class cshControlSky : MonoBehaviour
{
    public Material dayMat;
    public Material nightMat;
    public GameObject dayLight;
    public GameObject nightLight;

    public Color dayFog;
    public Color nightFog;

    public Button dayButton;
    public Button nightButton;

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 0.5f);
    }

    void OnGUI()
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
    }
    public void dayday()
    {
        RenderSettings.skybox = dayMat;
        RenderSettings.fogColor = dayFog;
        dayLight.SetActive(true);
        nightLight.SetActive(false);
    }
    public void nightnight()
    {
        RenderSettings.skybox = nightMat;
        RenderSettings.fogColor = nightFog;
        dayLight.SetActive(false);
        nightLight.SetActive(true);

    }
}
