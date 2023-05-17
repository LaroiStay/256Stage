using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController1 : MonoBehaviour
{
    public Camera targetCamera; // ȭ���� ���� Camera ������Ʈ
    public GameObject screenObject; // ȭ���� ǥ���� Screen ������Ʈ

    private void Start()
    {
        // Camera ������Ʈ�� Render Texture ������Ʈ�� ������
        RenderTexture cameraTexture = targetCamera.GetComponent<Camera>().targetTexture;

        // Screen ������Ʈ�� Material�� ������
        Material screenMaterial = screenObject.GetComponent<Renderer>().material;

        // Screen ������Ʈ�� Material�� Main Texture�� Camera ������Ʈ�� Render Texture�� �Ҵ�
        screenMaterial.mainTexture = cameraTexture;
    }
}
