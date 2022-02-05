using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    
    [SerializeField] float LVLCompleteSeconds = 0f;
      
      // deactivates the "Level Complete" screen at the beginning of the level and sets the
      // time to default 1 to make sure the level keeps running in real time
      void Start()
      {
          gameObject.SetActive(false);
          Invoke("Active", LVLCompleteSeconds);
          Time.timeScale = 1;
      }
      
      // activates the "Level Complete" screen at the end of the level and sets the time to 0, to make sure,
      // the level is stopped/freezed to prevent the player from getting more score in the end screen
      void Active()
      {
          gameObject.SetActive(true);
          Time.timeScale = 0;
      }
      
      // deactive function for the start
      void Deactive()
      {
          gameObject.SetActive(false);
      }
}
