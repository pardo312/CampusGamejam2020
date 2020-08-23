using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetEnemyRockAfterThrow : MonoBehaviour
{
    private Vector3 postionRocaActual;
    private Quaternion rotacionRocaActual;
    [SerializeField]private Transform enemy;
    // Start is called before the first frame update
    void Start()
    {
        postionRocaActual = transform.localPosition;
        rotacionRocaActual = transform.localRotation;
    }
    private void OnCollisionEnter(Collision other) {
        if(!(other.gameObject.tag == "Enemy"))
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.transform.SetParent(enemy);
            transform.localPosition = postionRocaActual;
            transform.localRotation = rotacionRocaActual;
        }
    }
}
