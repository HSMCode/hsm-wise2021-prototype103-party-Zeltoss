using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STOP : MonoBehaviour
{
    float time = 19f;
    float time2 = 30f;
    float time3 = 42.4f;
    float time4 = 56.7f;
    float time5 = 61.8f;
    float time6 = 71.8f;
    float pause = 2f;
      
      void Start()
      {
          gameObject.SetActive(false);
          Invoke("Active", time);
          Invoke("Active", time2);
          Invoke("Active", time3);
          Invoke("Active", time4);
          Invoke("Active", time5);
          Invoke("Active", time6);
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
