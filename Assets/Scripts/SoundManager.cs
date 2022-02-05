using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{   
    // setting up the images for the sound on and off icons
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    private bool muted = false;

    // checks the save data at the start of the game
    // if: if there is no save data, it sets the sound button to default: on
    // else: if there is sava data, it loads this data instead
    void Start()
    {
        if(!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }

        else
        {
            Load();
        }
        
        // loads the right sound button that was saved the last time 
        UpdateButtonIcon();
        AudioListener.pause = muted;
    }
    
    // if you click on the sound button and the game isn't muted, it disables all the sounds from the game
    // else: if the game is already muted and you click on the sound button, it will enable all the sounds in the game instead
    public void OnButtonPress()
    {
        if(muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
        
        // starts the save coroutine to save the data and calls the UpdateButtonIcon coroutine to give the player the visible button feedback
        Save();
        UpdateButtonIcon();
    }

    // if: if the music is not muted, the sound on icon is enabled and the off icon is disabled
    // else: if the music is muted, the sound off icon is enabled and the on icon is disabled
    private void UpdateButtonIcon()
    {
        if(muted == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }

        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }

    }

    // retrieves the save data since it is now saved as an it
    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    // converts the bool into int
    // saves the data (on/off sound)
    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }

}
