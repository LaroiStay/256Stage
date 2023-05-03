using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{

    Animator animator;

    void Start()
    {
       
        //animator.enabled = false; // 애니메이션 비활성화
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Light")) // 카메라와 충돌체 감지
        {
            animator = other.GetComponent<Animator>();
            animator.enabled = true; // 애니메이션 활성화
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Light")) // 카메라와 충돌체 감지
        {
            animator = other.GetComponent<Animator>();
            animator.enabled = false; // 애니메이션 비활성화
        }
    }


   
}
