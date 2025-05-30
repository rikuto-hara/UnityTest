using UnityEngine;

public class RemyWalking : MonoBehaviour
{
    public float speed = 5f; // Speed of the character movement
    Rigidbody rb; // Reference to the Rigidbody component
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to this GameObject
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal"); // Get horizontal input
        float z = Input.GetAxis("Vertical"); // Get vertical input
        Vector3 vec = new Vector3(x, 0, z); // Create a movement vector
        rb.linearVelocity = vec * speed; // Set the Rigidbody's velocity based on input and speed
    }
}
