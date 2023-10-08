using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float walkSpeed = 5;
    public float runSpeed = 8;
    public float jumpHeight = 2;
    public float gravity = -9.18f;
    public float mouseSensitivity = 2.0f;

    private CharacterController controller;
    private Animator animator;
    private Vector3 move;
    private Vector3 playerVelocity;
    private bool isGrounded;
    private bool canJump = true; 
    private bool doubleJump = false;

    private float rotationX = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        isGrounded = controller.isGrounded;
        doubleJump = GameManager.Instance.PowerUp;

        if (!animator.applyRootMotion)
        {
            ProcessMovement();
            ProcessGravity();
        }

        UpdateAnimator();

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(Vector3.up * mouseX);
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        if (isGrounded)
        {
            canJump = true; 
        }
    }

    private void ProcessMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        move = new Vector3(horizontalInput, 0, verticalInput).normalized;

        if (move != Vector3.zero)
        {
            Vector3 camForward = Camera.main.transform.forward;
            camForward.y = 0;
            transform.forward = camForward.normalized;
        }
    }

    private void ProcessGravity()
    {
        animator.SetBool("DoubleJump", doubleJump);

        if (isGrounded)
        {
            playerVelocity.y = -1.0f;

            if (Input.GetButtonDown("Jump"))
            {
                if (canJump || (GameManager.Instance.PowerUp && !doubleJump))
                {
                    playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
                    canJump = false;

                    if (GameManager.Instance.PowerUp)
                    {
                        doubleJump = true;
                    }
                }
            }
            else
            {
                canJump = true;
                doubleJump = false;
            }
        }
        else
        {
            playerVelocity.y += gravity * Time.deltaTime;
        }

        controller.Move(move * Time.deltaTime * GetMovementSpeed() + playerVelocity * Time.deltaTime);
    }


    private void UpdateAnimator()
    {
        float speed = move.magnitude;

        if (speed > 0)
        {
            animator.SetFloat("Speed", Mathf.Lerp(0.5f, 1.0f, speed));
        }
        else
        {
            animator.SetFloat("Speed", 0.0f);
        }

        animator.SetBool("isGrounded", isGrounded);
    }

    private float GetMovementSpeed()
    {
        return Input.GetButton("Fire3") ? runSpeed : walkSpeed;
    }
}
