using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    // float to manage the jump height
    public float jumpHeight = 2.0f;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(Vector3.up * jumpHeight);
            // manages the time that needs for the player to fall down after a jump
            Physics.gravity = new Vector3(0, -40.0F, 0);
        }
    }
}
