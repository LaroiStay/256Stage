using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshControlSky : MonoBehaviour
{
    public Material dayMat;
    public Material nightMat;
    public GameObject dayLight;
    public GameObject nightLight;

    public Color dayFog;
    public Color nightFog;

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 0.5f);
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(1800, 400, 100, 30), "Day View"))
        {
            RenderSettings.skybox = dayMat;
            RenderSettings.fogColor = dayFog;
            dayLight.SetActive(true);
            nightLight.SetActive(false);
        }

        if (GUI.Button(new Rect(1800, 440, 100, 30), "Night View"))
        {
            RenderSettings.skybox = nightMat;
            RenderSettings.fogColor = nightFog;
            dayLight.SetActive(false);
            nightLight.SetActive(true);
        }
    }
}
