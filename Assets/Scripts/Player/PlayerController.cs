using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask ground;
    [SerializeField] private AudioSource _jumpSound;
    

    private Rigidbody2D _playerRb;
    private Animator _playerAnimator;
    private PlayerHealth _playerHealth;
    private BoxCollider2D _boxCollider;

    private float _speed = 10;
    private float _jumpForce = 15;
    private float _horizontalInput;
    
    

    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
        _playerHealth = GetComponent<PlayerHealth>();
        _boxCollider= GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (_playerHealth.IsAlive)
        {
            CorrectScaleVectorX();

            _horizontalInput = Input.GetAxis("Horizontal");
            _playerRb.velocity = new Vector2(_horizontalInput * _speed, _playerRb.velocity.y);

            if (Input.GetKeyDown(KeyCode.Space) && IsOnGround())
            {
                Jump();
            }


            _playerAnimator.SetBool("isRunning", _horizontalInput != 0);
            _playerAnimator.SetBool("isGrounded", IsOnGround());
            _playerAnimator.SetFloat("verticalSpeed", _playerRb.velocity.y);
        }
        
    }

    private void Jump()
    {
        _jumpSound.Play();
        _playerRb.velocity = new Vector2(_playerRb.velocity.x, _jumpForce);   
    }
   
 
    private bool IsOnGround()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0, Vector2.down, 0.1f, ground);
        return raycastHit.collider != null;
    }
    private void CorrectScaleVectorX()
    {
        if (_horizontalInput > 0.01f)
        {
            transform.localScale = new Vector2(3, 3);
        }
        if (_horizontalInput < -0.01f)
        {
            transform.localScale = new Vector2(-3, 3);
        }
    }
    
}
