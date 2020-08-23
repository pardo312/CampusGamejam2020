using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{   
    [SerializeField] private Animator animationFadeIn;
    private float transitionTime =2f;
    public void exitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void playGame()
    {
        StartCoroutine(playGameTransition());
    }
    IEnumerator playGameTransition(){
        animationFadeIn.SetTrigger("FadeIn");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("CutsceneInicio");
    }
}
