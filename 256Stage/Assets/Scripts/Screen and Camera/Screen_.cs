using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen_ : MonoBehaviour
{
    int childIndex = 0;
    GameObject QuadObj;
    private void Start()
    {
        Transform childTransform = transform.GetChild(childIndex);
        if (childTransform != null)
        {
            QuadObj = childTransform.gameObject;
            QuadObj.SetActive(false);
        }
    }
}
