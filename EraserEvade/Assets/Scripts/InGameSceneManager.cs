using System.Collections;
using UnityEngine;

public class InGameSceneManager : MonoBehaviour
{
    #region Obstacle

    [SerializeField] int obstacles_spawn_number_at_once;
    [SerializeField] float time_between_obstacles_spawn;
    [SerializeField] GameObject[] obstacles;

    float screen_x_half_size;
    float screen_y_half_size;

    #endregion

    #region Score

    [SerializeField] int score_per_frame;
    [SerializeField] TextMesh score_text;

    int score;

    #endregion

    void Start()
    {
        screen_x_half_size = Camera.main.orthographicSize * Camera.main.aspect;
        screen_y_half_size = Camera.main.orthographicSize;

        score = 0;

        StartCoroutine(SpawnObstacles());
        StartCoroutine(IncreaseScore());
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

    IEnumerator IncreaseScore()
    {
        while (true)
        {
            score += score_per_frame;
            score_text.text = score.ToString();

            yield return null;
        }
    }
}
