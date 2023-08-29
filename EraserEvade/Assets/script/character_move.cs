using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_move : MonoBehaviour
{
    public float moveSpeed = 5f; // �̵� �ӵ�
    public float lerpSpeed = 10f; // �ε巯�� �̵��� ���� ���� �ӵ�

    private Vector3 targetPosition; // ��ǥ ��ġ

    void Update()
    {
        float moveDirection = Input.GetAxis("Horizontal"); // ���� ���� �Է°� (-1: ����, 1: ������)

        if (moveDirection < 0)
        {
            // ���� ��ư�� ������ ��
            targetPosition = transform.position + Vector3.left;
        }
        else if (moveDirection > 0)
        {
            // ������ ��ư�� ������ ��
            targetPosition = transform.position + Vector3.right;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed * Time.deltaTime);
    }
}
