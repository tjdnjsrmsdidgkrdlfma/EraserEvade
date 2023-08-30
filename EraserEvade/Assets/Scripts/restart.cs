using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class restart : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButton(0) == true)
        {
            SceneManager.LoadScene("InGame");
        }

    }
}
