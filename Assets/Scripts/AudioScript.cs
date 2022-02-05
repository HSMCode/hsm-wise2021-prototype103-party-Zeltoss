using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    AudioSource myAudio;

    // One second cooldown for every music in each level
    void Start()
    {
       myAudio = GetComponent<AudioSource>();
       myAudio.PlayDelayed(1f);
    }
}