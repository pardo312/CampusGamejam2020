using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    [SerializeField] private CharacterController characterController;

    [SerializeField,Range(1f, 10f)]private float walkSpeed;
    [SerializeField,Range(-5f, -15f)]private float gravity;
    [SerializeField,Range(1f, 10f)]private float jumpHeight;

    private Vector3 fallVelocity = Vector3.zero;

    void Update()
    {
        Gravity();
        Jump();
        Walk();
    }
    void Jump()
    {
        if (Input.GetButton("Jump") && characterController.isGrounded)
        {
            fallVelocity.y = Mathf.Sqrt(jumpHeight * gravity * -2f);
        }
    }

    void Gravity()
    {
        characterController.Move(fallVelocity * Time.deltaTime);
        if (!characterController.isGrounded)
        {
            fallVelocity.y += gravity * Time.deltaTime;
        }

    }

    void Walk()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float zAxis = Input.GetAxisRaw("Vertical");

        Vector3 movement = transform.right * xAxis + transform.forward * zAxis;

        characterController.Move(movement * walkSpeed * Time.deltaTime);
    }

}
