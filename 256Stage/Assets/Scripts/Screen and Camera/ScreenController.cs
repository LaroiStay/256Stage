using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    public Camera cameraObject; // 카메라 오브젝트
    public GameObject screenObject; // screen 오브젝트

    private RenderTexture renderTexture;

    void Start()
    {
        // 카메라가 화면을 렌더링할 RenderTexture 생성
        renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraObject.targetTexture = renderTexture;

        // screen 오브젝트의 Material을 카메라가 렌더링한 화면으로 설정
        Material material = screenObject.GetComponent<MeshRenderer>().material;
        material.mainTexture = renderTexture;
    }
}
