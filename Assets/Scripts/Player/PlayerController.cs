using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask ground;
    [SerializeField] private AudioSource jumpSound;
    

    private Rigidbody2D playerRb;
    private Animator playerAnimator;
    private PlayerHealth playerHealth;
    private BoxCollider2D boxCollider;

    private readonly float speed = 10;
    private readonly float jumpForce = 15;
    private float horizontalInput;
    
    

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealth>();
        boxCollider= GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (playerHealth.IsAlive)
        {
            CorrectScaleVectorX();

            horizontalInput = Input.GetAxis("Horizontal");
            playerRb.velocity = new Vector2(horizontalInput * speed, playerRb.velocity.y);

            if (Input.GetKeyDown(KeyCode.Space) && IsOnGround())
            {
                Jump();
            }


            playerAnimator.SetBool("isRunning", horizontalInput != 0);
            playerAnimator.SetBool("isGrounded", IsOnGround());
            playerAnimator.SetFloat("verticalSpeed", playerRb.velocity.y);
        }
        
    }

    private void Jump()
    {
        jumpSound.Play();
        playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);   
    }
   
 
    private bool IsOnGround()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, ground);
        return raycastHit.collider != null;
    }
    private void CorrectScaleVectorX()
    {
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector2(3, 3);
        }
        if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector2(-3, 3);
        }
    }
    
}
