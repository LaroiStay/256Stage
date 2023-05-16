using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public GameObject optionButtonPrefab;

    private Camera mainCamera;
    private GameObject optionButtonInstance; 

    private void Start()
    {
        
        mainCamera = Camera.main;
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            
            Vector3 mousePosition = Input.mousePosition;

           
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

          

            if (optionButtonInstance == null)
            {
                
                optionButtonInstance = Instantiate(optionButtonPrefab, mousePosition, Quaternion.identity);
            }
        }
    }
}