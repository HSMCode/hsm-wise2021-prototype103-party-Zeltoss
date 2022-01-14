using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownBackground : MonoBehaviour
{
    float Background = 0f;
    float pause = 3f;
      
      void Start()
      {
          gameObject.SetActive(false);
          Invoke("Active", Background);
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
