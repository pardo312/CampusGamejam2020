using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getHitByEnemy : MonoBehaviour
{
    [SerializeField]private Image lifeBar;
    [SerializeField]private GameObject deathScreen;

    void Update()
    {
        if(!ApplicationModel.IsDead){
            lifeBar.fillAmount = ApplicationModel.playerLife;
            if(ApplicationModel.playerLife<0.2)
            {
                //Dead
                Time.timeScale = 0f;
                deathScreen.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                ApplicationModel.IsDead = true;
            }
        }
        
    }
    private void OnTriggerEnter(Collider other) {
        if(!ApplicationModel.IsDead){
            if(other.gameObject.tag == "Player"){
                ApplicationModel.playerLife -= 0.2f;
            }
            
        }
    }
    private void OnCollisionEnter(Collision other) {
        if(!ApplicationModel.IsDead){
            if(other.gameObject.tag == "PlayerRock"){
                ApplicationModel.playerLife -= 0.2f;
            }
        }
    }
}   
