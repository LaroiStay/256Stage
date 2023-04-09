using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Reflection;

public class UI_Manager : MonoBehaviour
{
    int m_order = 10;
    Stack<UI_Popup> m_popupStack = new Stack<UI_Popup>();
    Dictionary<Type, int> m_UI_ETC = new Dictionary<Type, int>();

    UI_Scene m_sceneUI = null;
    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("@UI_Root");
            if (root == null)
                root = new GameObject() { name = "@UI_Root" };
            return root;
        }
       
    }

    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;

        if (sort)
            canvas.sortingOrder = (m_order++);
        else
            canvas.sortingOrder = 0;
    }
    public void SetCanvasUIETC(GameObject go)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;
        canvas.sortingOrder = 5;
    }


    public T ShowUI<T>(string name = null) where T : UI_ETC
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;
        GameObject go = Manager.Resource_Instance.Instantiate($"UI/ETC/{name}");
        T ETCUI = Util.GetOrAddComponent<T>(go);
        m_UI_ETC.Add(typeof(T), 1);
        return ETCUI;
    }

    //public T ShowSceneUI<T>(Transform parent = null, string name = null) where T : UI_Scene
    //{

    //    if (string.IsNullOrEmpty(name))
    //        name = typeof(T).Name;
    //    GameObject go = Manager.Resource_Instance.Instantiate($"UI/Scene/{name}");
    //    T sceneUI = Util.GetOrAddComponent<T>(go);
    //    m_sceneUI = sceneUI;


    //    go.transform.SetParent(Root.transform);
    //    return sceneUI;

    //}
    // public T ShowSceneUI<T>(Transform parent = null, string name = null) where T : UI_Scene
    //{
    //    GameObject go = Manager.Resource_Instance.Instantiate($"UI/Scene/{name}", parent);
    //    T sceneUI = Util.GetOrAddComponent<T>(go);
    //    m_sceneUI = sceneUI;
    //    if (parent == null)
    //        go.transform.SetParent(Root.transform);
    //    return sceneUI;
    //}


    public T ShowSceneUI<T>(Transform parent = null, string name = null) where T : UI_Scene
    {
        
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;
        GameObject go = Manager.Resource_Instance.Instantiate($"UI/Scene/{name}", parent);
        T sceneUI = Util.GetOrAddComponent<T>(go);
        m_sceneUI = sceneUI;
        if (parent == null)
            go.transform.SetParent(Root.transform);
        return sceneUI;
    }


    public void CloseETCUI<T>() where T : UI_ETC
    {
        if (m_UI_ETC.Count == 0)
            return;

        int value = 0;

       

        if (m_UI_ETC.TryGetValue(typeof(T), out value))
        {
            GameObject go = FindObjectOfType<T>().gameObject;
            m_UI_ETC.Remove(typeof(T));
            Manager.Resource_Instance.Destroy(go);
        }
    }


    public T ShowPopupUI<T>(string name = null) where T : UI_Popup
    {

        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;
        GameObject go = Manager.Resource_Instance.Instantiate($"UI/Popup/{name}");
        T popup = Util.GetOrAddComponent<T>(go);
        m_popupStack.Push(popup);

       
        go.transform.SetParent(Root.transform);
        return popup;

    }

    public void ClosePeekUI(UI_Popup popup)
    {
        if (m_popupStack.Count == 0)
            return;

        if (m_popupStack.Peek() != popup)
        {
            Debug.Log("Colse Popup FAILED");
            return;
        }
        ClosePopupUI();
    }

    public void ClosePopupUI()
    {
        if (m_popupStack.Count == 0)
            return;

        UI_Popup popup = m_popupStack.Pop();
        Manager.Resource_Instance.Destroy(popup.gameObject);
        popup = null;
        m_order--;
    }

    public void ClosePoppupAll()
    {
        while (m_popupStack.Count > 0)
            ClosePopupUI();
    }


    public void ClearETCUI()
    {
        Type[] keys = new Type[m_UI_ETC.Count];
        m_UI_ETC.Keys.CopyTo(keys, 0);
        
        int j = keys.Length;
        for(int i=0; i < j; i++)
        {
            Type tempKey = keys[i];
            MethodInfo closeETCUIMethod = typeof(UI_Manager).GetMethod("CloseETCUI").MakeGenericMethod(tempKey);
            closeETCUIMethod.Invoke(this, null);
        }
        

    }



}
