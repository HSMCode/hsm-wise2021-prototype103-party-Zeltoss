using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
 
    public static int score;
    int myNumber = 0;

    // private bool _canStart = true;
    // public int countdown = 3;

 
    void Start()
    {
        score = 0;
        scoreText.text = "Beats: " + score;
    }
 
    public virtual void Update()
    {
 
        if (Input.GetKeyDown(KeyCode.Space)) // && _canStart)
        {
        myNumber += 1;
        if (myNumber < 30)
            AddScore(1);
            // StartCoroutine(Cooldown());
        
        else // if (Input.GetKeyDown(KeyCode.Space) &&!_canStart)
            LooseScore(2);
        }

        // IEnumerator Cooldown()
        {   
            // _canStart = false;
            // yield return new WaitForSeconds(countdown);
            // _canStart = true;
        }
    }
 
    public void AddScore(int addedValue)
    {
        score += addedValue;
        scoreText.text = "Beats: " + score;
    }

    public void LooseScore(int looseValue)
    {
        score -= looseValue;
        scoreText.text = "Beats: " + score;
    }
}
