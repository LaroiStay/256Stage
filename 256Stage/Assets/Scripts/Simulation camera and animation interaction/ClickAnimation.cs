using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnimation : MonoBehaviour
{
    private float interactionDistance = 500f; // 상호작용 가능한 거리
    [SerializeField] private LayerMask interactableLayer; // 상호작용 가능한 레이어
    [SerializeField] private Camera playerCamera; // 플레이어 카메라
    private RaycastHit hit; // 레이캐스트를 통해 충돌한 오브젝트 정보
    private Animator anim; // 애니메이터 컴포넌트

    private void Start()
    {
        anim = GetComponent<Animator>(); // 애니메이터 컴포넌트 참조
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭 시
        {
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionDistance, interactableLayer))
            {
                Animator animator = hit.collider.gameObject.GetComponent<Animator>();
                if (animator != null)
                {
                    // Animator의 상태를 반전합니다.
                    animator.enabled = !animator.enabled;
                }
            }
        }
    }

    
}

