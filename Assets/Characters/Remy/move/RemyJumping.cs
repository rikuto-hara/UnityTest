using UnityEngine;

public class RemyJumping : MonoBehaviour
{
    public float jumpForce = 5f; // Force applied when jumping
    public float Raylength = 1.1f; // Cooldown time between jumps
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to this GameObject
    }

    // Update is called once per frame
    void Update()
    {
        bool jump = Input.GetButtonDown("Jump"); // Check if the jump button is pressed
        bool grounded = Physics.Raycast(transform.position, Vector3.down, Raylength); // Check if the character is grounded
        if (jump && grounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Apply an upward force to the Rigidbody for jumping
        }
    }
}
