using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockPicked : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(gameObject.tag == "Rock")
        {
            if(ApplicationModel.currentRocks<10)
            {
                if(other.gameObject.tag == "Player"){
                    
                    gameObject.tag = "PlayerRock";
                    ApplicationModel.currentRocks++;
                    gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    gameObject.transform.parent = ApplicationModel.playerCamera;

                    if(!ApplicationModel.hasRockActual){
                        ApplicationModel.hasRockActual = true;
                        gameObject.GetComponent<playerShoot>().currentRock = true;
                        gameObject.transform.localPosition = ApplicationModel.postionRocaActual;
                        gameObject.transform.localRotation = ApplicationModel.rotacionRocaActual;
                    }
                    else{      
                        ApplicationModel.rocasPlayer.Enqueue(this.gameObject);
                        gameObject.transform.position = ApplicationModel.playerCamera.position - ApplicationModel.playerCamera.forward*3;
                    }   
                }
            }
        }
        
        
    }
    private void OnCollisionEnter(Collision other) {
        if(!(other.gameObject.tag == "EnemyRock")){
            StartCoroutine(changeTag());
        }
    }
    IEnumerator changeTag()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.tag = "Rock";
    }
}
