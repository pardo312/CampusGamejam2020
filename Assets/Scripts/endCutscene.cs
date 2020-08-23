using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class endCutscene : MonoBehaviour
{
    [SerializeField]private VideoPlayer videoPlayer;

    // Update is called once per frame
    void Update()
    {
        if(videoPlayer.frame == (long)videoPlayer.frameCount-2)
        {
            SceneManager.LoadScene("World");
        }
    }
}
