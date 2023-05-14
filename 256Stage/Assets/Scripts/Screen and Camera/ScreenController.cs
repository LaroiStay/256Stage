using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    public Camera cameraObject; // ī�޶� ������Ʈ
    public GameObject screenObject; // screen ������Ʈ

    private RenderTexture renderTexture;

    void Start()
    {
        // ī�޶� ȭ���� �������� RenderTexture ����
        renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraObject.targetTexture = renderTexture;

        // screen ������Ʈ�� Material�� ī�޶� �������� ȭ������ ����
        Material material = screenObject.GetComponent<MeshRenderer>().material;
        material.mainTexture = renderTexture;
    }
}
