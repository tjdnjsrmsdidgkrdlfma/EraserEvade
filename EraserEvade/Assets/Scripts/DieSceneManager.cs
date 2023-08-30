using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DieSceneManager : MonoBehaviour
{
    [SerializeField] Text best_score;
    [SerializeField] Text last_score;

    void Start()
    {
        best_score.text = "BEST SCORE: " + DataManager.instance.data.max_score.ToString();
        last_score.text = "YOUR SCORE: " + DataManager.instance.last_score.ToString();
    }
}
