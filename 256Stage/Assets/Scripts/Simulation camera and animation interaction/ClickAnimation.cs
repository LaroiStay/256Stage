using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnimation : MonoBehaviour
{
    private float interactionDistance = 500f; // ��ȣ�ۿ� ������ �Ÿ�
    [SerializeField] private LayerMask interactableLayer; // ��ȣ�ۿ� ������ ���̾�
    [SerializeField] private Camera playerCamera; // �÷��̾� ī�޶�
    private RaycastHit hit; // ����ĳ��Ʈ�� ���� �浹�� ������Ʈ ����
    private Animator anim; // �ִϸ����� ������Ʈ

    private void Start()
    {
        anim = GetComponent<Animator>(); // �ִϸ����� ������Ʈ ����
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ�� ��
        {
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionDistance, interactableLayer))
            {
                Animator animator = hit.collider.gameObject.GetComponent<Animator>();
                if (animator != null)
                {
                    // Animator�� ���¸� �����մϴ�.
                    animator.enabled = !animator.enabled;
                }
            }
        }
    }

    
}

