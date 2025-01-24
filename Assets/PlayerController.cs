using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;  // How high the player will jump
    private int tapCount = 0;
    private bool canJump = false;

    public GameObject arrow; // Reference to the arrow for animations

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tapCount++;

            // Arrow animation based on tap count
            UpdateArrowAnimation(tapCount);

            if (tapCount == 4)
            {
                Jump();
                tapCount = 0;  // Reset tap count after the jump
            }
        }
    }

    void UpdateArrowAnimation(int count)
    {
        // Use the arrow animator and set the 'tapCount' parameter
        Animator arrowAnimator = arrow.GetComponent<Animator>();

        arrowAnimator.SetInteger("tapCount", count);
    }

    void Jump()
    {
        // Make the player jump, based on how high the arrow indicates
        if (canJump)
        {
            rb.velocity = new Vector2(0, jumpForce); // Jump upwards
            canJump = false; // Prevent multiple jumps without a new tap cycle
        }
    }
}
