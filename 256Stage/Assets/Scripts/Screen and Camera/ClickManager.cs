using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public GameObject prefab;
    private GameObject spawnedPrefab;

    private bool isPrefabSpawned = false;

    private void Update()
    {
        Vector3 worldPosition = transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            if (isPrefabSpawned)
            {
                Destroy(spawnedPrefab);
            }
            else
            {
                isPrefabSpawned = true;
            }

            Vector3 cameraPosition = Camera.main.WorldToViewportPoint(worldPosition);
            Vector2 screenPosition = new Vector2(
                cameraPosition.x * Screen.width,
                cameraPosition.y * Screen.height
            );
            spawnedPrefab = Instantiate(prefab, screenPosition, Quaternion.identity, GameObject.Find("Canvas").transform);
        }
    }
}
