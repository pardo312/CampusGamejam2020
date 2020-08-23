using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGame : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject endCamera;
    public GameObject endScreen;

    public AudioManager audioManageGame;
    private bool audioFinal = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(ApplicationModel.currentCampsDestroyed==4)
        {
            ApplicationModel.IsEnd = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            playerCamera.SetActive(false);  
            endCamera.SetActive(true);
            endScreen.SetActive(true);
            endCamera.transform.LookAt(transform);
            endCamera.transform.Translate(Vector3.right*0.1f );
            //Start Audio Juanda
            
        }
    }
}
