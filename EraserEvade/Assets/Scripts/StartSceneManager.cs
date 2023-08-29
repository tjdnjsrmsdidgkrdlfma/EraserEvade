using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButton(0) == true)
        {
            SceneManager.LoadScene("InGame");
        }
    }
}
