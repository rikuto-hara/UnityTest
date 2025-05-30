using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RemyController : MonoBehaviour
{
    public float speed = 5f; // Speed of the character movement
    public float jumpForce = 5f; // Force applied when jumping
    public float Raylength = 1.1f; // Cooldown time between jumps

    bool isGrounded;
    bool wasGrounded;

    Rigidbody rb; // Reference to the Rigidbody component
    Animator anim; // Reference to the Animation component (not used in this script but can be useful for animations)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to this GameObject
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*ï‡Ç≠à⁄ìÆÇÃèàóù*/
        float x = Input.GetAxis("Horizontal"); // Get horizontal input
        float z = Input.GetAxis("Vertical"); // Get vertical input
        Vector3 vec = new Vector3(x, 0, z); // Create a movement vector
        bool isWalking = vec.magnitude > 0.1f; // Check if the character is moving

        /*ínñ îªíË*/
        wasGrounded = isGrounded;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, Raylength); // Check if the character is grounded

        /*à⁄ìÆ*/
        Vector3 velocity = rb.linearVelocity;
        velocity.x = vec.x * speed;
        velocity.z = vec.z * speed;
        rb.linearVelocity = velocity;
        if(Mathf.Abs(velocity.x) > 0 || Mathf.Abs(velocity.z) >0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }


        /*âÒì]ÇÃèàóù*/
        if (isWalking)
        {
            Quaternion targetRotation = Quaternion.LookRotation(vec);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.2f);
        }

        /*ÉWÉÉÉìÉvÇÃèàóù*/
        bool jump = Input.GetButtonDown("Jump"); // Check if the jump button is pressed
        if (jump && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Apply an upward force to the Rigidbody for jumping
            anim.SetBool("isJumping", true);
        }
        if (!wasGrounded && isGrounded)
        {
            anim.SetBool("isJumping", false);
        }
    }
}
