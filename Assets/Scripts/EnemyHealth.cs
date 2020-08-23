using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    
    [SerializeField]private Transform player;
    [SerializeField]private Transform enemyLifeCanvas;
    [SerializeField]private Image lifeBar;
    [SerializeField]private GameObject enemyRock;
    [SerializeField]private GameObject lifeBarObject;
    private float enemyLife = 1;
    public bool dead = false;
    [SerializeField] private Image playerLifeBar;
    public AudioManager audioManageGame;

    void Update()
    {
        if(!dead){
            enemyLifeCanvas.transform.LookAt(player);
            lifeBar.fillAmount = enemyLife;
            if(enemyLife<0.2)
            {
                ApplicationModel.playerLife = 1;
                playerLifeBar.fillAmount = ApplicationModel.playerLife;
                GetComponent<NavMeshAgent>().isStopped = true;
                GetComponent<EnemyHealth>().enabled = false;
                GetComponent<EnemyMovement>().enabled = false;
                GetComponent<EnemyFieldOfView>().enabled = false;
                audioManageGame.StopPlaying(ApplicationModel.attackMusic);
                audioManageGame.StopPlaying(ApplicationModel.stealthMusic);
                Destroy(enemyRock); 
                Destroy(lifeBarObject);
                dead= true;
                ApplicationModel.currentCampsDestroyed += 1;
                gameObject.SetActive(false);
            }
        }
        
    }

    private void OnCollisionEnter(Collision other) {
        if(!dead){
            if(other.gameObject.tag == "PlayerRock"){
                enemyLife-= 0.2f;
                transform.LookAt(player.position);
            }
        }
    }
}
