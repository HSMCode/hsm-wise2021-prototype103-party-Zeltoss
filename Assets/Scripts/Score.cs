using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public Text scoreText;
    public static int score;
    public Text stopText;
    public GameObject redFloor;
    public AudioSource audioSource;
    public AudioClip[] audioClipArray;
    
    
    // create an array of floats to save all time codes for the music
    [SerializeField] float[] times = { 17f, 28f, 40.4f, 54.7f, 59.8f, 69.8f };
    [SerializeField] float pause = 2f;
    
    // this is the variable to block input unless the timer as reset every half second
    [SerializeField] float beatRhythm = 0.5f;
    [SerializeField] bool canScoreInBeat;
    [SerializeField] bool beatStopped;
    

    void Start()
    {
        // starts beat timer coroutine, to reset the variable to allow scoring, when input happens "on" beat
        StartCoroutine(BeatTimerReset());

        score = 0;
        scoreText.text = "Beats: " + score;
        
        // deactivates the "Stop!" text and red circle around the stage at the start of the game
        stopText.gameObject.SetActive(false);
        redFloor.gameObject.SetActive(false);

        // this loops through each array of the times and invokes the methods as before,
        // but without calling them individually
        // you can uncomment the debug log to check the loop
        foreach (float time in times)
        {
            Invoke("Active", time);
            // Debug.Log("actived: " + time);
        }
    }

    public virtual void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // positive scoring is only possible, when the beat has not stopped and canScoreInBeat is true
            // scoring is then disabled, the variable is set to true at the end of each coroutine run in BeatTimerReset
            if (!beatStopped && canScoreInBeat)
            {
                AddScore(1, false);
                canScoreInBeat = false;
                Debug.Log("beat is still playing, scoring now");
                // Debug.Log(Time.time);
            }
            
            // when the beat has stopped, each press is adding negative score
            if (beatStopped)
            {
                AddScore(-2, true);
                Debug.Log("beat stopped, getting minus points now");
                // play one random fail sound clip from the array
                audioSource.PlayOneShot(RandomClip());
            }
        }
    }
    
    public void AddScore(int addedValue, bool minus)
    {
        // we can use this method for both add and substract, as +- results in subtraction
        // the additional bool helps to identify and changes UI color
        // in theory you could as well check if the int is positive or negative, but this is more readable
        
        score += addedValue;
        scoreText.text = "Beats: " + score;

        if (minus)
        {
            scoreText.color = Color.red;
        }
        else
        {
            scoreText.color = Color.white;
        }
    }

        // technically this could be replaced by one coroutine, but it works, so... 
    
    void Active()
    {
        // activates the "Stop!", red circle and point punishment when the music stops
        stopText.gameObject.SetActive(true);
        redFloor.gameObject.SetActive(true);
        beatStopped = true;
        Invoke("Inactive", pause);
    }

    void Inactive()
    {
        // deactivates the "Stop!", red circle and point punishment when the music keeps going
        stopText.gameObject.SetActive(false);
        redFloor.gameObject.SetActive(false);
        beatStopped = false;
    }
    
    // this is the coroutine to reset the timer allowing scoring when input "on" beat
    private IEnumerator BeatTimerReset()
    {
        while (true)
        {
            canScoreInBeat = true;
            
            yield return new WaitForSeconds(beatRhythm);
                canScoreInBeat = true;
                Debug.Log("Reset Beat Timer...");
        }
    }

    // Audioclip array for the fail sound - Selects the sound randomly and draws an integer
    AudioClip RandomClip()
    {
    return audioClipArray[Random.Range(0, audioClipArray.Length)];
    }
}