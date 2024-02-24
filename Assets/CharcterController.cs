using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcterController : MonoBehaviour
{
  
    public float speed;
    public Rigidbody2D theRB;
    public float jumpForce;
    public float runSpeed;
    private float activeSpeed;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool canDoubleJump;
    public Animator anim;
    public float knockbackSpeed, knockbackLength;
    private float knockbackCounter;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Time.timeScale > 0f)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
            if (knockbackCounter <= 0)
            {
                activeSpeed = speed;
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    activeSpeed = runSpeed;
                }
                theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * activeSpeed, theRB.velocity.y);


                if (Input.GetButtonDown("Jump"))
                {
                    if (isGrounded == true)
                    {
                      
                        Jump();
                        canDoubleJump = true;
                    }
                    else
                    {
                        if (canDoubleJump == true)
                        {
                          
                            Jump();
                            canDoubleJump = false;
                        }
                    }
                }

                if (theRB.velocity.x > 0)
                {
                    transform.localScale = Vector3.one;
                }
                if (theRB.velocity.x < 0)
                {
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                }
            }
            else
            {
                knockbackCounter -= Time.deltaTime;
                theRB.velocity = new Vector2(knockbackSpeed * -transform.localScale.x, theRB.velocity.y);
            }
            anim.SetFloat("speed", Mathf.Abs(theRB.velocity.x));
            anim.SetBool("isTouchingGround", isGrounded);
        }
 }


    public void Jump()
    {
        theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
    }
    public void KnockBack()
    {
        theRB.velocity = new Vector2(0f, jumpForce * 0.5f);
        anim.SetTrigger("isKnockBack");
        knockbackCounter = knockbackLength;
    }
}
