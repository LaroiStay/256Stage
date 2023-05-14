using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public GameObject screen;   // Screen 오브젝트를 Inspector에서 연결할 public 변수
    public GameObject cameraPrefab;  // Camera 프리팹을 Inspector에서 연결할 public 변수

    private int numberOfCameras;  // 생성된 Camera 프리팹의 개수를 저장할 변수
    private Camera[] cameras;  // 생성된 Camera 프리팹의 정보를 저장할 배열 변수

    void Start()
    {
        // Camera 프리팹의 개수에 따라 버튼 생성
        numberOfCameras = 5; // 예시로 Camera 프리팹이 5개라 가정
        for (int i = 0; i < numberOfCameras; i++)
        {
            GameObject button = Instantiate(Resources.Load<GameObject>("Button")); // Resources 폴더에서 Button 프리팹을 로드하여 버튼 생성
            button.transform.SetParent(screen.transform, false); // Screen 오브젝트의 자식으로 버튼을 추가
            button.GetComponent<ButtonController>().SetCameraIndex(i); // 버튼에 해당되는 Camera 프리팹의 인덱스를 전달
        }

        // 생성된 Camera 프리팹의 정보를 배열에 저장
        cameras = new Camera[numberOfCameras];
        for (int i = 0; i < numberOfCameras; i++)
        {
            GameObject cameraObject = Instantiate(cameraPrefab); // Camera 프리팹을 인스턴스화하여 Scene에 생성
            cameras[i] = cameraObject.GetComponent<Camera>(); // Camera 프리팹의 정보를 배열에 저장
            cameraObject.tag = "CameraPrefab"; // Camera 프리팹에 "CameraPrefab" 태그 추가
        }
    }

    public void ChangeScreenTexture(int index)
    {
        // 버튼을 클릭하면 해당되는 Camera가 찍은 화면을 Screen 오브젝트의 텍스처로 적용
        screen.GetComponent<MeshRenderer>().material.mainTexture = cameras[index].targetTexture;
    }
}

public class ButtonController : MonoBehaviour
{
    private int cameraIndex;  // 버튼에 해당되는 Camera 프리팹의 인덱스를 저장할 변수

    public void SetCameraIndex(int index)
    {
        cameraIndex = index;
    }

    public void OnClick()
    {
        CameraController cameraController = FindObjectOfType<CameraController>(); // CameraController 오브젝트를 가져옴
        cameraController.ChangeScreenTexture(cameraIndex); // 버튼에 해당되는 Camera가 찍은 화면을 Screen 오브젝트의 텍스처로 적용
    }
}