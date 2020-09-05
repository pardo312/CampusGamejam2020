using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationModel : ScriptableObject
{

    static public float playerLife = 1;
    static public Queue<GameObject> rocasPlayer = new Queue<GameObject>();
    static public Vector3 postionRocaActual;
    static public Quaternion rotacionRocaActual;
    static public bool hasRockActual = true;
    static public Transform playerCamera;
    static public bool startTimerUntilShoot = false;
    static public int timerUntilShoot = 0;
    static public int currentRocks = 1;
    static public int currentCampsDestroyed = 0;
    public static bool IsPaused = false;
    public static bool IsDead = false;
    public static bool IsEnd = false;

    static public string attackMusic = "Attack";
    static public string stealthMusic = "Stealth";
    static public void resetVariables()
    {
        playerLife = 1;
        rocasPlayer = new Queue<GameObject>();
        hasRockActual = true;
        startTimerUntilShoot = false;
        timerUntilShoot = 0;
        currentRocks = 1;
        IsPaused = false;
        IsDead = false;
        currentCampsDestroyed = 0;
    }

}
