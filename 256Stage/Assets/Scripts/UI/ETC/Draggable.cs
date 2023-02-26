using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    RectTransform rectTransform;
    Vector2 offset;
    string temp_name;
    int temp_key;
    bool isFirst = true;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {

      
        offset = eventData.position - (Vector2)rectTransform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isFirst)
        {
            isFirst = false;   
            temp_key = GetComponent<RealSelectButton>().m_key;
            temp_name = GetComponent<RealSelectButton>().m_name;
            GameObject go = Manager.Resource_Instance.Instantiate("UI/ETC/RealSelectButton", this.transform.parent);
            go.transform.SetSiblingIndex(temp_key - 1);
            go.GetComponent<RealSelectButton>().SetImage(temp_name, temp_key);
        }
        rectTransform.position = eventData.position - offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 1000.0f)){
            GameObject go = Manager.Resource_Instance.Instantiate($"Stage/{temp_name}/{temp_name}{temp_key}");
            go.transform.position = hit.point;
            FindObjectOfType<HierarchyCanvas>().PlusPrefabsInHierarchy(temp_name, temp_key);
        }

        Manager.Resource_Instance.Destroy(this.gameObject);
    }
}