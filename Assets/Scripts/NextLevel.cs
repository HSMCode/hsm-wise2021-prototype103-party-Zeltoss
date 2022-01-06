using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
   public Button NextLevelButton;

    // Start is called before the first frame update
    void Start()
    {
        NextLevelButton.onClick.AddListener(RestartScene);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            Debug.Log("Reloaded Scene!");
            SceneManager.LoadScene("FeelTheRythm");
            Time.timeScale = 1;
        }
    }
    
    public void RestartScene()
	{
		Debug.Log("Game Restarted!");
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
	}
}
