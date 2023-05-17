using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController1 : MonoBehaviour
{
    public Camera targetCamera; // 화면을 찍을 Camera 오브젝트
    public GameObject screenObject; // 화면을 표시할 Screen 오브젝트

    private void Start()
    {
        // Camera 오브젝트의 Render Texture 컴포넌트를 가져옴
        RenderTexture cameraTexture = targetCamera.GetComponent<Camera>().targetTexture;

        // Screen 오브젝트의 Material을 가져옴
        Material screenMaterial = screenObject.GetComponent<Renderer>().material;

        // Screen 오브젝트의 Material의 Main Texture에 Camera 오브젝트의 Render Texture를 할당
        screenMaterial.mainTexture = cameraTexture;
    }
}
