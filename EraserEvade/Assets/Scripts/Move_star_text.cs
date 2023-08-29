using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_star_text: MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f; // 이동 속도
    [SerializeField] float amplitude = 0.5f; // 움직임의 진폭

    private Vector3 startPosition; // 초기 위치

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
