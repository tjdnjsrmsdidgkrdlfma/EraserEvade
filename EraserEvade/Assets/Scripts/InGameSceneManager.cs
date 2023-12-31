using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

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

    public int score;

    [SerializeField] int score_per_frame;
    [SerializeField] Text score_text;

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
                Vector2 random_obstacle_spawn_position = new Vector2(Random.Range(-screen_x_half_size, screen_x_half_size), screen_y_half_size *1.2f);
                Instantiate(obstacles[random_index], random_obstacle_spawn_position, Quaternion.identity);
            }
        }
    }

    IEnumerator IncreaseScore()
    {
        while (true)
        {
            score += 1;//�̰� ���� 

            StringBuilder sb = new StringBuilder();
            sb.Append("SCORE: ");
            sb.Append(score.ToString());
            score_text.text = sb.ToString();

            yield return null;
        }
    }
}
