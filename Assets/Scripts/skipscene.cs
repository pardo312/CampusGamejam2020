using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class skipscene : MonoBehaviour
{

    [SerializeField]private GameObject videoTexture;
    [SerializeField]private GameObject cargandoAndPauseText;
    [SerializeField]private GameObject skipButton;
    public void saltarScene()
    {
        cargandoAndPauseText.SetActive(true);
        Destroy(videoTexture);
        skipButton.SetActive(false);
        SceneManager.LoadSceneAsync("World");
    }
}
