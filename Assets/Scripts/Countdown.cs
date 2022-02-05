using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    float currentTime = 0f;         
    float startingTime = 3f;
    float CountdownBegin = 0f;  
    float pause = 3.6f;

    // gets the texfield to show the countdown ingame
    [SerializeField] Text countdownText;

    // starts the countdown at the start of level
    void Start()
    {
        currentTime = startingTime;
        gameObject.SetActive(false);
        Invoke("Active", CountdownBegin);
    }

    // edits the texfield at the gameobject to show a visible countdown to the player
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString ("0");

        if(currentTime <= 0)
        {
            currentTime = 0;
        }
    }

    // activates the countdown and calls the deactive function after the pause timer is done
    void Active()
    {
        gameObject.SetActive(true);
        Invoke("Deactive", pause);
    }

    // deactivates the countdown
    void Deactive()
    {
        gameObject.SetActive(false);
    }
}
