using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_move : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도
    public float lerpSpeed = 10f; // 부드러운 이동을 위한 보간 속도

    private Vector3 targetPosition; // 목표 위치

    void Update()
    {
        float moveDirection = Input.GetAxis("Horizontal"); // 수평 방향 입력값 (-1: 왼쪽, 1: 오른쪽)

        if (moveDirection < 0)
        {
            // 왼쪽 버튼이 눌렸을 때
            targetPosition = transform.position + Vector3.left;
        }
        else if (moveDirection > 0)
        {
            // 오른쪽 버튼이 눌렸을 때
            targetPosition = transform.position + Vector3.right;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed * Time.deltaTime);
    }
}
