using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
 
    public static int score;
 
    void Start()
    {
        score = 0;
        scoreText.text = "Beats: " + score;
    }
 
    public virtual void Update()
    {
 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddScore(1);
        }
    }
 
    public void AddScore(int addedValue)
    {
        score += addedValue;
        scoreText.text = "Beats: " + score;
    }
}
