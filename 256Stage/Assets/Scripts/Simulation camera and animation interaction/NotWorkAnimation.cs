using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotWorkAnimation : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false; // �ִϸ��̼� ��Ȱ��ȭ
    }
}
