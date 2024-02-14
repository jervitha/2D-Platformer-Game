using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public Animator animator;
    public Animator playerAnimator;
    public BoxCollider2D boxCol;
    public Vector2 boxColInitSize;
    public Vector2 boxColInitOffset;
    public float speed;
    public float jumpSpeed = 8f;
    private Rigidbody2D player;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private int score = 0;
    public GameOverController gameOverController;
 //   public ScoreController scoreController;
    public Text scoretext;

  //public static  void PickUpKey()
    //{
      //  throw new NotImplementedException();
        //Debug.Log("player picked up the key");
    //    ScoreContro
//    }

    private bool isTouchingGround;
    private Vector3 respawnPoint;
    public GameObject fallDetector;
    // Start is called before the first frame update
    public void Awake()
    {
        Debug.Log("player controller awake");
    }

    public void KillPlayer()
    {
        Debug.Log("player killed by enemy");
        //Destroy(gameObject);
        gameOverController.PlayerDied();
    }
    public void Start()
    {
        player = GetComponent<Rigidbody2D>();
        boxColInitSize = boxCol.size;
        boxColInitOffset = boxCol.offset;
        respawnPoint = transform.position;
        scoretext.text ="score: " +score;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision: " + collision.gameObject.name);
    }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float VerticalInput = Input.GetAxisRaw("Jump");
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,groundLayer);
        MoveCharacter(horizontal);
        if (Input.GetButtonDown("Jump")&& isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }
        PlayJumpAnimation(VerticalInput);
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Crouch(true);
        }
        else
        {
            Crouch(false);
        }

        PlayMovementAnimation(horizontal);
        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="FallDetector")
        {
            transform.position = respawnPoint;
        }
        else if(collision.tag=="crystal")
        {
            score += 1;
            scoretext.text = "score: " + score;
            collision.gameObject.SetActive(false);
        }
        else if(collision.tag=="Nextlevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            respawnPoint = transform.position;
        }
        else if (collision.tag == "Previouslevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            respawnPoint = transform.position;
        }
        else if (collision.tag == "FinalLevel")
        {
            SceneManager.LoadScene(6);
        }
    }
    public void MoveCharacter(float horizontal)
    {
        //horizontal movement
        Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;
        //vertical movement
       // player.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Force);
    }
    private void PlayMovementAnimation(float horizontal)
    {
        animator.SetFloat("speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {

            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
       // float vertical = Input.GetAxisRaw("Jump");

    }

    public void Crouch(bool crouch)
    {
        if (crouch == true)
        {

            float offX = 0.01626f;     //Offset X
            float offY = 0.55226f;      //Offset Y

            float sizeX = 0.66986f;     //Size X
            float sizeY = 1.2247f;     //Size Y

            boxCol.size = new Vector2(sizeX, sizeY);   //Setting the size of collider
            boxCol.offset = new Vector2(offX, offY);
        }
        else

        {
            
                //Reset collider to initial values
                boxCol.size = boxColInitSize;
                boxCol.offset = boxColInitOffset;
            
        }
        playerAnimator.SetBool("iscrouch", crouch);
    }

    public void PlayJumpAnimation(float vertical)
    {
        if (vertical > 0)
        {
            animator.SetBool("Jump",true);
          //  playerAnimator.SetTrigger("Jump");
            Input.GetKeyDown(KeyCode.Space);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

}
