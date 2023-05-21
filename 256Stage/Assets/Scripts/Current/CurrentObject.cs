using System.Collections;
using System.Collections.Generic;
using RTG;
using UnityEngine;

public class CurrentObject : MonoBehaviour
{
    public static GameObject objectMake = GameObject.Find("MakeObject");
    public static GameObject selectedCurrentObject;
    public static Dictionary<GameObject, GameObject> HierarchyButtons = new Dictionary<GameObject, GameObject>();
    public static Dictionary<GameObject, int> LightObj = new Dictionary<GameObject, int>();
    public static int i = 0;
}
