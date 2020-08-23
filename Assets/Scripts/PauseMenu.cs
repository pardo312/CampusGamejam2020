using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]private GameObject pauseMenuUI;
    [SerializeField]private GameObject deathScreen;

    // Update is called once per frame
    void Update()
    {
        if(!ApplicationModel.IsDead && !ApplicationModel.IsEnd)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (ApplicationModel.IsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
        
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        StartCoroutine(unPause());
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    IEnumerator unPause()
    {
        yield return new WaitForSeconds(0.5f);
        ApplicationModel.IsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        ApplicationModel.IsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void restart()
    { 
        pauseMenuUI.SetActive(false);
        deathScreen.SetActive(false);
        Time.timeScale = 1f;
        ApplicationModel.resetVariables();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene (SceneManager.GetActiveScene ().name, LoadSceneMode.Single);
    }
    public void goToMainMenu()
    {
        pauseMenuUI.SetActive(false);
        deathScreen.SetActive(false);
        Time.timeScale = 1f;
        ApplicationModel.resetVariables();
        SceneManager.LoadScene("TitleScreen");
    }
    
}
