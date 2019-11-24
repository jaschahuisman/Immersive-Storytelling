using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // Components
    public Animator anim;
    public CharacterController controller;
    public Transform playerBody;

    // Physics/Gravity
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 5.0f;
    public float gravity = -6.0f;
    Vector3 velocity;

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>(); 
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        
        // Physics/Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
