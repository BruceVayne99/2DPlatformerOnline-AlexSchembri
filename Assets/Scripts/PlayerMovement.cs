using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float JumpSpeed = 500f;

    private Rigidbody2D _rigidbody;

    private bool _isGrounded = false;

    #region Input Variables
    private float _XInput;
    private bool _isJumpPressed = false;
    #endregion

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Keyboard A/D or Left/Right arrow
        _XInput = Input.GetAxisRaw("Horizontal");
        _XInput *= MoveSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isJumpPressed = true;
        }
    }
    private void FixedUpdate()
    {
        //_rigidbody.AddForce(new Vector2(_XInput, 0f), ForceMode2D.Impulse);
        _rigidbody.velocity = new Vector2(_XInput * MoveSpeed * Time.fixedDeltaTime, _rigidbody.velocity.y);

        if (_isJumpPressed && _isGrounded)
        {
            _rigidbody.AddForce(Vector2.up * JumpSpeed, ForceMode2D.Impulse);
        }
        _isJumpPressed = false;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.tag == "Ground")
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "Ground")
        {
            _isGrounded = false;
        }
    }
}