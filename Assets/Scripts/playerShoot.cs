using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{
    [SerializeField,Range(1f, 20)] private float throwForce;
    public GameObject rocasGameObject;
    public bool currentRock = false;
    public bool endInitLaunch = false;
    public Animator animatorSlingshot;
    void Start()
    {
        if(currentRock)
        {
            ApplicationModel.postionRocaActual = transform.localPosition;
            ApplicationModel.rotacionRocaActual = transform.localRotation;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(ApplicationModel.startTimerUntilShoot){
            ApplicationModel.timerUntilShoot++;
        }
        if(currentRock)
        {
            gameObject.transform.localPosition = ApplicationModel.postionRocaActual;
            gameObject.transform.localRotation = ApplicationModel.rotacionRocaActual;
        }
        Shoot();
        setNextRockToCurrent();
    }
    void Shoot()
    {
        if(!ApplicationModel.IsPaused){
            if(currentRock)
            {
                
                    if (Input.GetButton("Fire1"))
                    {
                        animatorSlingshot.SetBool("Shoot",true);
                        LeanTween.moveLocal( gameObject, gameObject.transform.localPosition + new Vector3(0.2f,0,-1f), 0.1f).setEase(LeanTweenType.linear).setOnComplete(onCompleteLeanTween);
                       
                    }
                    if (Input.GetButtonUp("Fire1"))
                    {
                        if(endInitLaunch)
                        {
                            animatorSlingshot.SetBool("Shoot",false);
                            ApplicationModel.currentRocks--;
                            currentRock=false;
                            GetComponent<Rigidbody>().isKinematic = false;
                            GetComponent<Rigidbody>().AddRelativeForce((new Vector3 ( 0.6f,0.2f,1) ) * throwForce * 100);
                            ApplicationModel.startTimerUntilShoot = true;
                            StartCoroutine(changeParent());  
                        }
                                                 
                    }
            }
        }
    }
    void onCompleteLeanTween()
    {
        endInitLaunch=true;
    }
    IEnumerator changeParent()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.transform.SetParent(rocasGameObject.transform) ;
        endInitLaunch=false;
    }
    void setNextRockToCurrent(){
        if(ApplicationModel.timerUntilShoot>700)
        {
            if(ApplicationModel.rocasPlayer.Count > 0)
            {
                GameObject rocaSiguiente = ApplicationModel.rocasPlayer.Dequeue();
                rocaSiguiente.GetComponent<playerShoot>().currentRock = true;
            }
            else{
                ApplicationModel.hasRockActual = false;
            }
            ApplicationModel.timerUntilShoot=0;
            ApplicationModel.startTimerUntilShoot=false;
        }
        
    }
    
}
