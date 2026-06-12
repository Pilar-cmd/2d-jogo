using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pontuacao : MonoBehaviour
{
    float point = 0;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText = "0";
    }
    public void AddPoints()
    {
        points++;
        scoreText = points.ToString();
    }
}
