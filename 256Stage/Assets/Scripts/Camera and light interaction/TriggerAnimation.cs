using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false; // �ִϸ��̼� ��Ȱ��ȭ
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �浹ü�� ����
        {
            animator.enabled = true; // �ִϸ��̼� Ȱ��ȭ
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // ī�޶�� �浹ü ����
        {
            animator.enabled = false; // �ִϸ��̼� ��Ȱ��ȭ
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
