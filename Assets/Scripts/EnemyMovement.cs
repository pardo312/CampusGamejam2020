using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    private Vector3 initPosition;
    public Transform navDestination;
    private Vector3 destPosition;

    private NavMeshAgent navMeshAgent;
    private EnemyFieldOfView fieldOfView;

    private Transform playerLastSeen;
    private Vector3 playerLastSeen2;
    private bool isFollowingPlayer;

    public GameObject enemyRock;
    public GameObject rocasGameObject;
    private bool startTimerUntilShoot = false;
    private float timeUntilShoot =10f;
    
    public EnemyHealth enemyHealth;

    public AudioManager audioManageGame;

    // Start is called before the first frame update
    void Start()
    {
        playerLastSeen = null;
        playerLastSeen2 = Vector3.positiveInfinity;
        navMeshAgent = GetComponent<NavMeshAgent>();
        fieldOfView = GetComponent<EnemyFieldOfView>();
        initPosition = transform.position;
        destPosition = initPosition;
        StartCoroutine(SetRoute());

    }

    void GetDestPosition()
    {
        destPosition = destPosition == initPosition ? navDestination.position : initPosition;
    }

    IEnumerator SetRoute()
    {
        while (true)
        {
            if(!enemyHealth.dead)
            {
                if(startTimerUntilShoot)
                {
                    timeUntilShoot++;
                }
                foreach (Transform playerPosition in fieldOfView.visibleTargets)
                {
                    playerLastSeen = playerPosition;
                }

                if (playerLastSeen)
                {
                    
                    if (!isFollowingPlayer)
                    {
                        navMeshAgent.destination = (playerLastSeen.position + transform.position) / 2;  
                        isFollowingPlayer = true;
                        startTimerUntilShoot=false;
                        //Incia la musica
                        switch (ApplicationModel.currentCampsDestroyed)
                        {
                            case 1:
                                ApplicationModel.attackMusic = "Attack1";
                                break;
                            case 2:
                                ApplicationModel.attackMusic = "Attack2";
                                break;
                            case 3:
                                ApplicationModel.attackMusic = "Attack3";
                                break;
                            default:
                                ApplicationModel.attackMusic = "Attack";
                                break;
                        }
                        audioManageGame.Play(ApplicationModel.attackMusic);
                        audioManageGame.StopPlaying(ApplicationModel.stealthMusic);
                        
                    }
                    else if(!(Vector3.Distance(playerLastSeen.position, transform.position) < 10))
                    {
                        navMeshAgent.destination = (playerLastSeen.position + transform.position)/2f;
                        startTimerUntilShoot=false;
                    }
                    else
                    {  
                        //Attack
                        startTimerUntilShoot = true;
                        if(timeUntilShoot>10)
                        {
                            enemyRock.GetComponent<Rigidbody>().isKinematic = false;
                            enemyRock.GetComponent<Rigidbody>().AddRelativeForce((new Vector3 ( -0.2f,-0.5f,2f) ) *1000);
                            enemyRock.transform.SetParent(rocasGameObject.transform);
                            timeUntilShoot=0;
                        }
                    }
                    isFollowingPlayer = true;

                    if (!(playerLastSeen2 == playerLastSeen.position))
                    {
                        //Se para la musica
                        audioManageGame.StopPlaying(ApplicationModel.stealthMusic);
                        transform.LookAt(playerLastSeen.position);
                    }
                    playerLastSeen2 = playerLastSeen.position;
                    playerLastSeen = null;

                }
                else if(!playerLastSeen && (!playerLastSeen2.Equals(Vector3.positiveInfinity)))
                {
                    navMeshAgent.destination = playerLastSeen2;
                    playerLastSeen2 = Vector3.positiveInfinity;

                }
                else if (navMeshAgent.remainingDistance == 0)
                {
                    isFollowingPlayer = false;
                    yield return StartCoroutine(LookAround(1f));
                    GetDestPosition();
                    navMeshAgent.destination = destPosition;
                }
                else
                {
                    isFollowingPlayer = false;
                }
                
            
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator LookAround(float duration)
    {
        float startRotation = transform.eulerAngles.y;
        float endRotation = startRotation + 45.0f;
        float t = 0.0f;
        while (t < duration)
        {
            foreach (Transform playerPosition in fieldOfView.visibleTargets)
            {
                playerLastSeen = playerPosition;
            }

            if (playerLastSeen)
            {
                yield break;
            }

            t += Time.deltaTime;
            float yRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 360.0f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
            yield return null;
        }

        float startRotation2 = transform.eulerAngles.y;
        endRotation = startRotation - 45.0f;
        t = 0.0f;
        while (t < duration*2)
        {
            foreach (Transform playerPosition in fieldOfView.visibleTargets)
            {
                playerLastSeen = playerPosition;
            }

            if (playerLastSeen)
            {
                yield break;;
            }

            t += Time.deltaTime;
            float yRotation = Mathf.Lerp(startRotation2, endRotation, t / (duration*2)) % 360.0f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
            yield return null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(destPosition, .3f);
    }
}
