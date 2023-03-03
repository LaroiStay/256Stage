using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InMouse : MonoBehaviour
{
    [HideInInspector] public static bool IsOn = false;




    private void Update()
    {
        if (IsOn)
        {
            Collider[] colliders = CurrentObject.selectedCurrentObject.GetComponentsInChildren<Collider>();
            if (colliders.Length > 0)
                for (int i = 0; i < colliders.Length; i++)
                    colliders[i].enabled = false;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                CurrentObject.selectedCurrentObject.transform.position = hit.point;
            }
        }
    }


}
