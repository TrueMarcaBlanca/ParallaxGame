using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private AudioMute audioMute;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeSelf == false)
		{
            Cursor.visible = true;
            audioMute.changeMute = true;
			Pause();
		}
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Cursor.visible = false;
        
        audioMute.changeMute = true;

        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void Restart()
    {
        Cursor.visible = false;

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
