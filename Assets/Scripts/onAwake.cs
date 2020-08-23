using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onAwake : MonoBehaviour
{
    [SerializeField]private GameObject playerCameraObject ;
    void Awake(){
        ApplicationModel.playerCamera = playerCameraObject.transform;
    }
}
