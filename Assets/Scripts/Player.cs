using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask platformsLayerMask;
    [SerializeField] private Animator animator;
    [SerializeField] private float jumpVelocity = 9f;
    [SerializeField] private float downForce = 10f;
    [SerializeField] private AudioClip jumpSfx;

    bool jumpPressed = false;
    bool falling = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();

        animator.SetBool("IsJumping", !IsGrounded());

        if (rb.velocity.y < 0 && !IsGrounded())
        {
            falling = true;
        }
        else
        {
            falling = false;
        }
    }

    void FixedUpdate()
    {
        if (jumpPressed)
        {
            rb.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);

            jumpPressed = false;
        } else if (falling)
        {
            rb.AddForce(Vector2.down * downForce);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                AudioManager.Instance.PlaySfx(jumpSfx, 0.6f);
                jumpPressed = true;
            }
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);

        return raycastHit2D.collider != null;
    }
}
