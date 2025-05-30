using UnityEngine;

public class RemyController : MonoBehaviour
{
    public float speed = 5f; // Speed of the character movement
    public float jumpForce = 5f; // Force applied when jumping
    public float Raylength = 1.1f; // Cooldown time between jumps

    Rigidbody rb; // Reference to the Rigidbody component
    Animation anim; // Reference to the Animation component (not used in this script but can be useful for animations)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to this GameObject
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        /*�����ړ��̏���*/
        float x = Input.GetAxis("Horizontal"); // Get horizontal input
        float z = Input.GetAxis("Vertical"); // Get vertical input
        Vector3 vec = new Vector3(x, 0, z); // Create a movement vector
        bool isWalking = vec.magnitude > 0.1f; // Check if the character is moving

        /*�n�ʔ���*/
        bool grounded = Physics.Raycast(transform.position, Vector3.down, Raylength); // Check if the character is grounded

        /*�ړ�*/
        Vector3 velocity = rb.linearVelocity;
        velocity.x = vec.x * speed;
        velocity.z = vec.z * speed;
        rb.linearVelocity = velocity;


        /*��]�̏���*/
        if (isWalking)
        {
            Quaternion targetRotation = Quaternion.LookRotation(vec);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.2f);
        }

        /*�W�����v�̏���*/
        bool jump = Input.GetButtonDown("Jump"); // Check if the jump button is pressed
        if (jump && grounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Apply an upward force to the Rigidbody for jumping
        }

        /*�A�j���[�V�����̏���*/
        if (anim != null)
        {
            string currentAnim = anim.isPlaying ? anim.clip.name : "";

            if (!grounded && currentAnim != "Jump")
            {
                anim.Play("Jump"); // Jumping
            }
            else if (isWalking && grounded && currentAnim != "Walk")
            {
                anim.Play("Walk"); // Walking
            }
            else if (!isWalking && grounded && currentAnim != "Idle")
            {
                anim.Play("Idle"); // Idle
            }
        }
    }
}
