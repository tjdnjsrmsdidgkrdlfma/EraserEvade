using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] Vector2 move_speed_min_max;

    float move_speed;

    void Start()
    {
        move_speed = Random.Range(move_speed_min_max.x, move_speed_min_max.y);
    }

    void Update()
    {
        transform.Translate(Vector2.down * move_speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        ObstacleDestroyer obstacle_destroyer = collision.GetComponent<ObstacleDestroyer>();

        if (obstacle_destroyer != null)
        {
            Destroy(gameObject);
        }
    }
}
