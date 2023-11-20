using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    #region Input Variables
    private float _XInput;
    private bool _isJumpPressed = false;
    public float MoveSpeed = 10f;
    public float JumpSpeed = 50f;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _sprite;
    private bool _isGrounded = false;

    private float coyoteTime = 0.1f;
    private float coyoteTimeCounter;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;
    #endregion

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Keyboard A/D or Left/Right arrow
        _XInput = Input.GetAxisRaw("Horizontal");

        if (_XInput == 0)
        {
            _animator.SetBool("isWalking", false);
        }
        else
        {
            _animator.SetBool("isWalking", true);
            if (_XInput > 0)
            {
                _sprite.flipX = true;
            }
            else
            {
                _sprite.flipX = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isJumpPressed = true;
        }

        if (_isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
        if (_isJumpPressed)
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        //_rigidbody.AddForce(new Vector2(_XInput, 0f), ForceMode2D.Impulse);
        _rigidbody.velocity = new Vector2(_XInput * MoveSpeed * Time.fixedDeltaTime, _rigidbody.velocity.y);
        _XInput *= MoveSpeed * Time.deltaTime;

        if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f)
        {
            //_rigidbody.AddForce(Vector2.up * JumpSpeed, ForceMode2D.Impulse);
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, JumpSpeed);
            jumpBufferCounter = 0f;
        }

        if (_isJumpPressed && _rigidbody.velocity.y > 0f)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;
        }

        _isJumpPressed = false;


    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            Vector2 collisionPoint = collision.contacts[0].point;
            Vector2 collisionDirection = collisionPoint - (Vector2)transform.position;
            collisionDirection.Normalize();
            float angle = Vector2.Angle(collisionDirection, Vector2.down);

            if (angle < 45f)
            {
                _isGrounded = true;
            }
            else
            {
                _isGrounded = false;
            }

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            _isGrounded = false;
        }

    }
}