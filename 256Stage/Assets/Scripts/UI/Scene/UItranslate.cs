using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshDrag : MonoBehaviour
{
    public RectTransform rectTransform;


    void Start()
    {
        rectTransform = this.GetComponent<RectTransform>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            rectTransform.anchoredPosition = Input.mousePosition;
        }
    }
}