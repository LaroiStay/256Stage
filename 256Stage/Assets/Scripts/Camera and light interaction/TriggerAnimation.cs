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
        animator.enabled = false; // 애니메이션 비활성화
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 충돌체와 감지
        {
            animator.enabled = true; // 애니메이션 활성화
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // 카메라와 충돌체 감지
        {
            animator.enabled = false; // 애니메이션 비활성화
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
