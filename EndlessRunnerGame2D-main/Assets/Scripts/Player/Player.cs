using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float _jumpSpeed;
    private Rigidbody2D rb;

    public Transform GroundCheck;    //   check our
    public float CheckRadius;        // player on the
    public LayerMask _whatIsGround;  //   ground or
    public bool _isGrounded;         //      not

    // Double jump
    public int _maxJumpValue;
    int _maxJump;

    void Start()
    {
        _maxJump = _maxJumpValue;
        rb = GetComponent<Rigidbody2D>();        
    }

    void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, _whatIsGround);

        if (Input.GetMouseButtonDown(0) && _maxJump > 0)
        {
            _maxJump--;
            Jump();
        }
        else if (Input.GetMouseButtonDown(0) && _maxJump == 0 && _isGrounded)
        {
            Jump();
        }

        if (_isGrounded)
        {
            _maxJump = _maxJumpValue;
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("Land");
        }
    }

    void Jump()
    {
        FindObjectOfType<AudioManager>().Play("Jump");
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(0f, _jumpSpeed));
    }

}
