using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshCameraMouse : MonoBehaviour
{

    [SerializeField] float m_zoomSpeed = 0f;
    [SerializeField] float m_zoomMax = 0f;
    [SerializeField] float m_zoomMin = 0f;

    private float xRotate, yRotate, xRotateMove, yRotateMove;
    public float rotateSpeed = 500.0f;

    void CameraZoom()
    {
        float t_zoomDirection = Input.GetAxis("Mouse ScrollWheel");

        if (transform.position.y <= m_zoomMax && t_zoomDirection > 0)
            return;

        if (transform.position.y >= m_zoomMin && t_zoomDirection < 0)
            return;

        transform.position += transform.forward * t_zoomDirection * m_zoomSpeed;
    }

    void CameraRotate()
    {
        if (Input.GetMouseButton(2)) // 클릭한 경우
        {
            xRotateMove = -Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;
            yRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;

            yRotate = transform.eulerAngles.y + yRotateMove;
            xRotate = transform.eulerAngles.x + xRotateMove;
            xRotate = xRotate + xRotateMove;

            xRotate = Mathf.Clamp(xRotate, -90, 90); // 위, 아래 고정

            transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CameraZoom();
        CameraRotate();
    }
}