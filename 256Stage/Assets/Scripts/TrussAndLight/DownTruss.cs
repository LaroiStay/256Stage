using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownTruss : MonoBehaviour
{
    GameObject Par = null;
    private void Start()
    {
        Par = this.transform.parent.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Par.transform.position = other.transform.position;
        }
    }
}
