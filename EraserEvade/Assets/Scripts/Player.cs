using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float move_speed;

    bool is_left_button_clicking;
    bool is_right_button_clicking;

    float horizontal;

    void Update()
    {
        if (is_left_button_clicking == true && is_right_button_clicking == true)
            horizontal = 0;
        else if (is_left_button_clicking == true)
            horizontal = -1;
        else if (is_right_button_clicking == true)
            horizontal = 1;
        else if (is_left_button_clicking == false && is_right_button_clicking == false)
            horizontal = 0;

        transform.Translate(move_speed * Vector2.right * horizontal * Time.deltaTime);

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
}
