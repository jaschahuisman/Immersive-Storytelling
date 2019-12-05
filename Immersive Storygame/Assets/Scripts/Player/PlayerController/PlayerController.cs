using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float inputX;
    public float inputZ;
    public float walkingSpeed;
    public Vector3 targetDirection;
    public bool blockRotationPlayer;
    public float desiredRotationSpeed;
    public Animator anim;
    public float speed;
    public float allowPlayerRotation;
    public GameObject cameraBase;
    public CharacterController controller;
    public bool isGrounded;
    public float verticalVel;
    public float gravity = 9.81f;
    public Vector3 moveVector;

    public void Start()
    {
        anim.GetComponent<Animator>();
    }

    public void Update()
    {
        InputMagnitude();
        isGrounded = controller.isGrounded;

        if (isGrounded == true)
        {
            verticalVel -= 0;
        }
        else if (isGrounded == false)
        {
            verticalVel -= gravity * Time.deltaTime;
        }

        Vector3 camForward = cameraBase.transform.forward;
        Vector3 camRight = cameraBase.transform.right;

        camForward.y = 0f;
        camRight.y = 0f;

        moveVector = inputZ * camForward + inputX * camRight;
        moveVector.y = verticalVel;
       
        controller.Move(moveVector * Time.deltaTime * walkingSpeed);

    }

    public void PlayerMoveAndRotation()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        // Rotate player direction
        Vector3 targetDirection = new Vector3(inputX, 0f, inputZ);
        targetDirection = Camera.main.transform.TransformDirection(targetDirection);
        targetDirection.y = 0.0f;


        if (blockRotationPlayer == false)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDirection), desiredRotationSpeed);
        }
    }

    public void InputMagnitude()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        anim.SetBool("IsGrounded", isGrounded);
        anim.SetFloat("InputZ", inputZ, 0.0f, Time.deltaTime * 2f); 
        anim.SetFloat("InputX", inputX, 0.0f, Time.deltaTime * 2f); 

        speed = new Vector2(inputX, inputZ).sqrMagnitude;
        if (speed > allowPlayerRotation)
        {
            // anim.SetFloat("InputMagnitude", Speed, 0.0f, Time.deltaTime);
            PlayerMoveAndRotation();
        }
        else if (speed < allowPlayerRotation)
        {
            // anim.SetFloat("InputMagnitude", Speed, 0.0f, Time.deltaTime);
        }
    }




















    // public GameObject player;
    // public CharacterController controller;
    // public Animator anim;

    // public float gravity = -9.81f;
    // Vector3 velocity;

    // public float walkingSpeed = 5f;

    // // Start is called before the first frame update
    // void Start()
    // {
    //     anim.GetComponent<Animator>();
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     float xInput = Input.GetAxis("Horizontal");
    //     float zInput = Input.GetAxis("Vertical");

    //     // Gravity
    //     velocity.y += gravity * Time.deltaTime;
    //     controller.Move(velocity * Time.deltaTime);
    // }
}
