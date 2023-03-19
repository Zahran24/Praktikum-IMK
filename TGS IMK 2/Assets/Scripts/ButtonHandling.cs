using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandling : MonoBehaviour
{
    public GameObject panel;

    void Start()
    {
        // if(panel != null)
        // {
        //     panel.SetActive(false);
        // }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        panel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
