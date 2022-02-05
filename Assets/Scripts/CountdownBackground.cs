using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownBackground : MonoBehaviour
{
    float Background = 0f;
    // sets the timer for the visibilty of the background
    float pause = 3.6f;
      
      // enables the countdown Background at the level start
      void Start()
      {
          gameObject.SetActive(false);
          Invoke("Active", Background);
      }

      // function to activate the coutdown
      void Active()
      {
          gameObject.SetActive(true);
          Invoke("Deactive", pause);
      }

      // function to deactivate the countdown
      void Deactive()
      {
          gameObject.SetActive(false);
      }
}
