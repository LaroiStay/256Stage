using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{

    Animator animator;

    void Start()
    {
       
        //animator.enabled = false; // �ִϸ��̼� ��Ȱ��ȭ
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Light")) // ī�޶�� �浹ü ����
        {
            animator = other.GetComponent<Animator>();
            animator.enabled = true; // �ִϸ��̼� Ȱ��ȭ
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Light")) // ī�޶�� �浹ü ����
        {
            animator = other.GetComponent<Animator>();
            animator.enabled = false; // �ִϸ��̼� ��Ȱ��ȭ
        }
    }


   
}
