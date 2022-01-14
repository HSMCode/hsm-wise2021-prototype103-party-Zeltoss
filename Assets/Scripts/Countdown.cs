using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 3f;
    float CountdownBegin = 0f;
    float pause = 4f;

    [SerializeField] Text countdownText;

    void Start()
    {
        currentTime = startingTime;
        gameObject.SetActive(false);
        Invoke("Active", CountdownBegin);
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString ("0");

        if(currentTime <= 0)
        {
            currentTime = 0;
        }
    }

    void Active()
    {
        gameObject.SetActive(true);
        Invoke("Deactive", pause);
    }

    void Deactive()
    {
        gameObject.SetActive(false);
    }
}
