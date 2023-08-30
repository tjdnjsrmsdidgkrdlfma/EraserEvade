using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float move_speed;

    private bool is_left_button_clicking;
    private bool is_right_button_clicking;
    private Animator animator; // Animator 컴포넌트
    
    float horizontal;


    void Start()
    {
        animator = GetComponent<Animator>(); // Animator 컴포넌트 가져오기
    }

    void Update()
    {
        if (is_left_button_clicking == true && is_right_button_clicking == true)
            horizontal = 0;
        else if (is_left_button_clicking == true)
        {
            horizontal = -1;
            animator.SetBool("L_move", true);
        }
        else if (is_right_button_clicking == true)
        {
            horizontal = 1;
            animator.SetBool("R_move", true);
        }
        else if (is_left_button_clicking == false && is_right_button_clicking == false)
        {
            horizontal = 0;
            animator.SetBool("R_move", false);
            animator.SetBool("L_move", false);
        }
        transform.Translate(move_speed * Vector2.right * horizontal * Time.deltaTime);

        if (transform.position.x > 1.75f || transform.position.x < -1.75f)
        {
            Vector3 temp = transform.position;
            temp.x = Mathf.Clamp(temp.x, -1.75f, 1.75f);
            transform.position = temp;
        }

        horizontal = 0;
    }

    public void OnLeftButtonDown()
    {
        is_left_button_clicking = true;
    }

    public void OnLeftButtonUp()
    {
        is_left_button_clicking = false;
    }

    public void OnRightButtonDown()
    {
        is_right_button_clicking = true;
    }

    public void OnRightButtonUp()
    {
        is_right_button_clicking = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Obstacle obstacle = collision.GetComponent<Obstacle>();

        if (obstacle != null)
        {
            Time.timeScale = 0;
            //죽음 불러오기
            SceneManager.LoadScene("die");
            Debug.Log("Game Over");
        }
    }
}
