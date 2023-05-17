using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public GameObject prefab; // 생성할 프리팹
    private GameObject spawnedPrefab; // 생성된 프리팹을 저장할 변수

    private bool isPrefabSpawned = false; // 프리팹이 생성되었는지 여부를 나타내는 변수

    private void Update()
    {
        Vector3 worldPosition = transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            if (isPrefabSpawned)
            {
                Destroy(spawnedPrefab); // 이전에 생성된 프리팹 삭제
            }
            else
            {
                isPrefabSpawned = true;
            }

            // 월드 좌표를 카메라 좌표로 변환합니다.
            Vector3 cameraPosition = Camera.main.WorldToViewportPoint(worldPosition);

            // 카메라 좌표를 스크린 좌표로 변환합니다.
            Vector2 screenPosition = new Vector2(
                cameraPosition.x * Screen.width,
                cameraPosition.y * Screen.height
            );

            // 변환된 스크린 좌표를 사용합니다.
           // Debug.Log("Screen Position: " + screenPosition);

            //Instantiate(prefab,screenPosition, Quaternion.identity);
            spawnedPrefab = Instantiate(prefab, screenPosition, Quaternion.identity, GameObject.Find("Canvas").transform);
        }
    }
}
