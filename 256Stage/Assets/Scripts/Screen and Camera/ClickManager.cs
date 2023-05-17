using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public GameObject prefab; // ������ ������
    private GameObject spawnedPrefab; // ������ �������� ������ ����

    private bool isPrefabSpawned = false; // �������� �����Ǿ����� ���θ� ��Ÿ���� ����

    private void Update()
    {
        Vector3 worldPosition = transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            if (isPrefabSpawned)
            {
                Destroy(spawnedPrefab); // ������ ������ ������ ����
            }
            else
            {
                isPrefabSpawned = true;
            }

            // ���� ��ǥ�� ī�޶� ��ǥ�� ��ȯ�մϴ�.
            Vector3 cameraPosition = Camera.main.WorldToViewportPoint(worldPosition);

            // ī�޶� ��ǥ�� ��ũ�� ��ǥ�� ��ȯ�մϴ�.
            Vector2 screenPosition = new Vector2(
                cameraPosition.x * Screen.width,
                cameraPosition.y * Screen.height
            );

            // ��ȯ�� ��ũ�� ��ǥ�� ����մϴ�.
           // Debug.Log("Screen Position: " + screenPosition);

            //Instantiate(prefab,screenPosition, Quaternion.identity);
            spawnedPrefab = Instantiate(prefab, screenPosition, Quaternion.identity, GameObject.Find("Canvas").transform);
        }
    }
}
