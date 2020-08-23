using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playStealthMusic : MonoBehaviour
{
    public AudioManager audioManageGame;
    private void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.tag == "Player")
        {
             switch (ApplicationModel.currentCampsDestroyed)
            {
                case 1:
                    ApplicationModel.stealthMusic = "Stealth1";
                    break;
                case 2:
                    ApplicationModel.stealthMusic = "Stealth2";
                    break;
                case 3:
                    ApplicationModel.stealthMusic = "Stealth3";
                    break;
            }
            audioManageGame.Play(ApplicationModel.stealthMusic);
        }
    }

    private void OnTriggerExit(Collider other) {
        
        if(other.gameObject.tag == "Player")
        {
            audioManageGame.StopPlaying("Fight");  
            audioManageGame.StopPlaying("Stealth");
        }
    }
}
