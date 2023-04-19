using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshCameraMouse : MonoBehaviour
{

    [SerializeField] float m_zoomSpeed = 0f;
    [SerializeField] float m_zoomMax = 0f;
    [SerializeField] float m_zoomMin = 0f;

    public Texture2D cursorTextureB;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;


    float xRotate, yRotate, xRotateMove, yRotateMove;
    public float rotateSpeed = 500.0f;
    float lastClickTime;

    public static bool isAlt= false;
    public static bool isTranslate = false;
    Vector2 clickPoint;
    float dragSpeed = 15.0f;

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

    void CameraDrag()
    {
        if (Input.GetMouseButtonDown(0)) clickPoint = Input.mousePosition;

        if (Input.GetMouseButton(0))
        {
            if (isAlt)
            {

                Cursor.SetCursor(cursorTextureB, hotSpot, cursorMode);
                Vector3 position
                    = Camera.main.ScreenToViewportPoint((Vector2)Input.mousePosition - clickPoint);

                position.z = position.y;
                position.y = .0f;

                Vector3 move = position * (Time.deltaTime * dragSpeed);

                float y = transform.position.y;

                transform.Translate(move);
                transform.transform.position
                    = new Vector3(transform.position.x, y, transform.position.z);
            }
        }
    }

   
    void DoubleClick()
     {

         if (isTranslate)
         {
             if (Input.GetMouseButtonDown(0))
             {
                //if (Time.time - lastClickTime < 0.3f)
                //{
                DoSomethingOnDoubleClick();
                
                //}
                //lastClickTime = Time.time;
            }
            if (Input.GetMouseButton(1))
            {
                isTranslate = false;
            }
         }

     }


     void DoSomethingOnDoubleClick()
     {
         if (CurrentObject.selectedCurrentObject != null)
         {
             Collider[] colliders = CurrentObject.selectedCurrentObject.GetComponentsInChildren<Collider>();
             if (colliders.Length > 0)
                 for (int i = 0; i < colliders.Length; i++)
                     colliders[i].enabled = true;
             InMouse.IsOn = false;
             CurrentObject.selectedCurrentObject = null;
         }
         else
         {
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             RaycastHit hit;
             GameObject go;
             if (Physics.Raycast(ray, out hit, 1000.0f))
             {
                 go = hit.collider.gameObject;
                 if (CurrentObject.selectedCurrentObject == null)
                 {
                     Debug.Log(CurrentObject.selectedCurrentObject);
                     InMouse.IsOn = true;
                     CurrentObject.selectedCurrentObject = go;
                 }
             }
         }

     }


    // Update is called once per frame
    void Update()
    {
        CameraZoom();
        CameraRotate();
        CameraDrag();
        DoubleClick();


    }
}