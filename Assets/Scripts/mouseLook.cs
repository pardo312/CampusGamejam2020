using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    //---------Variables--------------

        //----------Variables Serializadas----------
            //Sensitividad del mouse
            [SerializeField,Range(1f, 200f)]private float sensibilidadMouse = 100f;
            //Transform del jugador.
            [SerializeField]private Transform playerBody;

        //----------Variables Privadas--------------
            //Cantidad de rotacion que va a tener el modelo/personaje horizontalmente
            private float xRotation = 0f;

        //----------Variables Publicas--------------
            //TODO

    //---------- Se ejecuta al inicio del juego---------------
    void Awake()
    {
        //Hace que el cursor no aparezca y se quede dentro del juego.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    //---------- Update is called once per frame---------------
    void Update()
    {
        //Obtiene el input del jugador y lo multiplica por la sensitividad
        float mouseX = Input.GetAxisRaw("Mouse X") * sensibilidadMouse * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensibilidadMouse * Time.deltaTime;

        //Invirte la vista en Y.
        xRotation -= mouseY;
        //Normaliza la rotacion entre los 90 y -90 grados
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Rota el jugador
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}