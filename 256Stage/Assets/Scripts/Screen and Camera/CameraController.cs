using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public GameObject screen;   // Screen ������Ʈ�� Inspector���� ������ public ����
    public GameObject cameraPrefab;  // Camera �������� Inspector���� ������ public ����

    private int numberOfCameras;  // ������ Camera �������� ������ ������ ����
    private Camera[] cameras;  // ������ Camera �������� ������ ������ �迭 ����

    void Start()
    {
        // Camera �������� ������ ���� ��ư ����
        numberOfCameras = 5; // ���÷� Camera �������� 5���� ����
        for (int i = 0; i < numberOfCameras; i++)
        {
            GameObject button = Instantiate(Resources.Load<GameObject>("Button")); // Resources �������� Button �������� �ε��Ͽ� ��ư ����
            button.transform.SetParent(screen.transform, false); // Screen ������Ʈ�� �ڽ����� ��ư�� �߰�
            button.GetComponent<ButtonController>().SetCameraIndex(i); // ��ư�� �ش�Ǵ� Camera �������� �ε����� ����
        }

        // ������ Camera �������� ������ �迭�� ����
        cameras = new Camera[numberOfCameras];
        for (int i = 0; i < numberOfCameras; i++)
        {
            GameObject cameraObject = Instantiate(cameraPrefab); // Camera �������� �ν��Ͻ�ȭ�Ͽ� Scene�� ����
            cameras[i] = cameraObject.GetComponent<Camera>(); // Camera �������� ������ �迭�� ����
            cameraObject.tag = "CameraPrefab"; // Camera �����տ� "CameraPrefab" �±� �߰�
        }
    }

    public void ChangeScreenTexture(int index)
    {
        // ��ư�� Ŭ���ϸ� �ش�Ǵ� Camera�� ���� ȭ���� Screen ������Ʈ�� �ؽ�ó�� ����
        screen.GetComponent<MeshRenderer>().material.mainTexture = cameras[index].targetTexture;
    }
}

public class ButtonController : MonoBehaviour
{
    private int cameraIndex;  // ��ư�� �ش�Ǵ� Camera �������� �ε����� ������ ����

    public void SetCameraIndex(int index)
    {
        cameraIndex = index;
    }

    public void OnClick()
    {
        CameraController cameraController = FindObjectOfType<CameraController>(); // CameraController ������Ʈ�� ������
        cameraController.ChangeScreenTexture(cameraIndex); // ��ư�� �ش�Ǵ� Camera�� ���� ȭ���� Screen ������Ʈ�� �ؽ�ó�� ����
    }
}