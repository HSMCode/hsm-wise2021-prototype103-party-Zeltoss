using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public Text scoreText;
    public static int score;
    public Text stopText;
    
    // create an array of floats to save all time codes for the music
    [SerializeField] float[] times = { 17f, 28f, 40.4f, 54.7f, 59.8f, 69.8f };
    float pause = 2f;
    
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
        
        stopText.gameObject.SetActive(false);

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

    // mainly copied the methods from STOP here, but added a variable to check if 
    // it is in pause mode or not. 
    // technically this could be replaced by one coroutine, but it works, so... 
    
    void Active()
    {
        stopText.gameObject.SetActive(true);
        beatStopped = true;
        Invoke("Inactive", pause);
    }

    void Inactive()
    {
        stopText.gameObject.SetActive(false);
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
}




// you can delete this part. It is basically a similar solution to the above, but with making use of the STOP 
// and SCORE scripts (by accessing the stop script). this works as well, but gets a bit messy as you need the
// information for when "Stopping" is happening and how long the pause is. Above makes it a bit cleaner and
// reuse the same variables. You as well would not need the coroutine, as you already have the timed invokations. 

// public class Score : MonoBehaviour
// {
//     public Text scoreText;
//     public static int score;
//     
//     private bool _canActivateCooldown = true;
//     public float countdown = 3f; 
//
//
//     private STOP _STOPscript; 
//  
//     void Start()
//     {
//         score = 0;
//         scoreText.text = "Beats: " + score;
//
//         _STOPscript = GameObject.Find("STOP").GetComponent<STOP>();
//     }
//  
//     public virtual void Update()
//     {
//  
//         if (Input.GetKeyDown(KeyCode.Space)) // && _canStart)
//         {
//
//             if (!_STOPscript.beatStopped)
//             {
//                 AddScore(1);
//                 Debug.Log("beat is still playing");
//             }
//             else if (_STOPscript.beatStopped && _canActivateCooldown)
//             {
//                 StartCoroutine(Cooldown());
//                 AddScore(-2);
//                 Debug.Log("beat stopped, starting coroutine");
//             }
//             else if (_STOPscript.beatStopped)
//             {
//                 AddScore(-2);
//                 Debug.Log("beat stopped getting minus points now");
//             }
//         }
//     }
//  
//     public void AddScore(int addedValue)
//     {
//         score += addedValue;
//         scoreText.text = "Beats: " + score;
//     }
//
//     // public void LooseScore(int looseValue)
//     // {
//     //     score -= looseValue;
//     //     scoreText.text = "Beats: " + score;
//     // }
//     
//     IEnumerator Cooldown()
//     {   
//         _canActivateCooldown = false;
//         Debug.Log("in coroutine...");
//         
//         yield return new WaitForSeconds(countdown);
//         Debug.Log("ended coroutine...");
//         
//         //_STOPscript.beatStopped = false;
//         _canActivateCooldown = true;
//     }
// }
