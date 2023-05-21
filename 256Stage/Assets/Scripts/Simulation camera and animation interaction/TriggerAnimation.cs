using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{

    Animator animator;
    public List<GameObject> k = new List<GameObject>();
    float Distance = 15f;

    private void Update()
    {
        if (k.Count == 0)
            return;
        for (int i = 0; i < k.Count; i++)
        {
            if (Vector3.Distance(transform.position, k[i].transform.position) < Distance)
            {
                Animator ani = k[i].GetComponent<Animator>();
                if (ani != null)
                    ani.enabled = true;
            }
            else
            {
                Animator ani = k[i].GetComponent<Animator>();
                if (ani != null)
                    ani.enabled = false;
            }
        }
    }
    public void SetK(List<GameObject> good)
    {
        k = good;
    }







}
