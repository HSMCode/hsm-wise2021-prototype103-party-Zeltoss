using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    float LevelComp = 90f;
      
      void Start()
      {
          gameObject.SetActive(false);
          Invoke("Active", LevelComp);
      }
 
      void Active()
      {
          gameObject.SetActive(true);
      }

      void Deactive()
      {
          gameObject.SetActive(false);
      }
}
