using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using RTG;

public class Draggable : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    RectTransform rectTransform;
    GameObject LightObject;
    Vector2 offset;
    Vector3 LightOffset;
    string temp_name;
    int temp_key;
    bool isFirst = true;
    bool FirstMakeObject = true;
    bool isLight = false;
    bool flag = true;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }


    private void Start()
    {
        IsLight Li = GetComponent<IsLight>();
        if (Li == null)
            isLight = false;
        else
            isLight = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        offset = eventData.position - (Vector2)rectTransform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (flag)
        {
            flag = false;
        }
        if (isLight == false)
        {
            if (isFirst)
            {
                isFirst = false;
                temp_key = GetComponent<RealSelectButton>().m_key;
                temp_name = GetComponent<RealSelectButton>().m_name;
                GameObject go = Manager.Resource_Instance.Instantiate("UI/ETC/RealSelectButton", this.transform.parent);
                go.transform.SetSiblingIndex(temp_key - 1);
                go.GetComponent<RealSelectButton>().SetImage(temp_name, temp_key);
                this.transform.SetSiblingIndex(20);
            }
            rectTransform.position = eventData.position - offset;
        }
        else
        {
            if (isFirst)
            {
                isFirst = false;
                temp_key = GetComponent<RealSelectButton>().m_key;
                temp_name = GetComponent<RealSelectButton>().m_name;
                GameObject go = Manager.Resource_Instance.Instantiate("UI/ETC/RealSelectButton", this.transform.parent);
                
                go.transform.SetSiblingIndex(temp_key - 1);
                go.GetComponent<RealSelectButton>().SetImage(temp_name, temp_key);
                this.GetComponent<RealSelectButton>().GetComponentInChildren<Button>().gameObject.SetActive(false);



            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10000.0f))
            {


                if (TurssQueue.GameObjects.Count != 0)
                {
                    if (FirstMakeObject)
                    {
                        LightObject = Manager.Resource_Instance.Instantiate($"Stage/{temp_name}/{temp_name}{temp_key}");
                     
                    }
                    GameObject[] tempList = TurssQueue.GameObjects.ToArray();
                    float distance = 1000.0f;

                    for (int i = 0; i < TurssQueue.GameObjects.Count; i++)
                    {
                        if (distance > (hit.point - tempList[i].transform.position).magnitude)
                        {
                            distance = (hit.point - tempList[i].transform.position).magnitude;
                            LightOffset = tempList[i].transform.position;
                        }
                    }


                    LightObject.transform.position = LightOffset;
                    if (FirstMakeObject)
                    {
                        FirstMakeObject = false;
                       

                    }

                }

            }

        }
       
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isLight)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                GameObject go = Manager.Resource_Instance.Instantiate($"Stage/{temp_name}/{temp_name}{temp_key}");
                GameObject go2 = FindObjectOfType<HierarchyCanvas>().PlusPrefabsInHierarchy(temp_name, temp_key, go);
                go.transform.position = hit.point;
                List<GameObject> goList = new List<GameObject>();
                goList.Add(go);
                goList.Add(go2);
                var postObjectSpawnAction = new PostObjectSpawnAction(goList);
                postObjectSpawnAction.Execute();
                postObjectSpawnAction.OnRemovedFromUndoRedoStack();
            }
            Manager.Resource_Instance.Destroy(this.gameObject);
        }
        else
        {
            List<GameObject> goList = new List<GameObject>();
            GameObject go2 = FindObjectOfType<HierarchyCanvas>().PlusPrefabsInHierarchy(temp_name, temp_key, LightObject);
            goList.Add(LightObject);
            goList.Add(go2);
            var postObjectSpawnAction = new PostObjectSpawnAction(goList);
            postObjectSpawnAction.Execute();
            postObjectSpawnAction.OnRemovedFromUndoRedoStack();
            Manager.Resource_Instance.Destroy(this.gameObject);
        }
    }
}