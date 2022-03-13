using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject Dot;

    [SerializeField] private bool isPaused;

    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume = 1.0f;


    public string toMainMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            ActivateMenu();
        }
        else
        {
            DeactivateMenu();
        }
    }

    void ActivateMenu()
    {
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Dot.SetActive(false);
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Dot.SetActive(true);
    }

    public void ActivateMain()
    {
        DeactivateMenu();
        pauseMenuUI.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        NewGameDialogYes();
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }
    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(toMainMenu);
    }
}
