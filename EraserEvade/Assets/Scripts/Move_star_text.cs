using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_star_text: MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f; // �̵� �ӵ�
    [SerializeField] float amplitude = 0.5f; // �������� ����

    private Vector3 startPosition; // �ʱ� ��ġ

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float verticalOffset = Mathf.Sin(Time.time * moveSpeed) * amplitude;
        transform.position = startPosition + new Vector3(0f, verticalOffset, 0f);
    }
}
