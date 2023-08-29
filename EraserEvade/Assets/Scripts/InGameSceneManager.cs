using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSceneManager : MonoBehaviour
{
    [SerializeField] int obstacles_spawn_number_at_once;
    [SerializeField] float time_between_obstacles_spawn;
    [SerializeField] GameObject[] obstacles;

    float screen_x_half_size;
    float screen_y_half_size;

    void Start()
    {
        screen_x_half_size = Camera.main.orthographicSize * Camera.main.aspect;
        screen_y_half_size = Camera.main.orthographicSize;
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        WaitForSeconds delay_between_obstacle_spawn = new WaitForSeconds(time_between_obstacles_spawn);

        while (true)
        {
            yield return delay_between_obstacle_spawn;

            for (int i = 0; i < obstacles_spawn_number_at_once; i++)
            {
                int random_index = Random.Range(0, obstacles.Length);
                Vector2 random_obstacle_spawn_position = new Vector2(Random.Range(-screen_x_half_size, screen_x_half_size), screen_y_half_size * 3);
                Instantiate(obstacles[random_index], random_obstacle_spawn_position, Quaternion.identity);
            }
        }
    }
}
