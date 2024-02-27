using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcterController : MonoBehaviour
{
  
 [SerializeField]private float speed;
 [SerializeField] private Rigidbody2D theRB;
 [SerializeField] private float jumpForce;
 [SerializeField] private float runSpeed;
 private float activeSpeed;
 private bool isGrounded;
 [SerializeField]private Transform groundCheckPoint;
 [SerializeField] private float groundCheckRadius;
 [SerializeField] private LayerMask whatIsGround;
 private bool canDoubleJump;
 public Animator anim;
 [SerializeField] private float knockbackSpeed, knockbackLength;
 private float knockbackCounter;
 private const string JUMP = "Jump";
 private const string SPEED = "speed";
 private const string ISTOUCHINGGROUND = "isTouchingGround";
 private const string ISKNOCKBACK = "isKnockBack";
    public Rigidbody2D TheRB
    {
        get { return theRB; }
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
            anim.SetFloat(SPEED, Mathf.Abs(theRB.velocity.x));
            anim.SetBool(ISTOUCHINGGROUND, isGrounded);
        }
 }


    public void Jump()
    {
        theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
    }
    public void KnockBack()
    {
        theRB.velocity = new Vector2(0f, jumpForce * 0.5f);
        anim.SetTrigger(ISKNOCKBACK);
        knockbackCounter = knockbackLength;
    }
}
