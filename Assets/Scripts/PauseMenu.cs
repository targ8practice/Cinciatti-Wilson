using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Pause_Menu;
    [SerializeField] Scene selectedScene;

    public void ResumeGame()
    {
        Time.timeScale = 1;
        Pause_Menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }

    public void ExitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        SceneManager.UnloadSceneAsync("SampleScene");
    }
}
