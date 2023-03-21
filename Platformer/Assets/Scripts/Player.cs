using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D playerCharacter;
    Animator playerAnimator;
    CapsuleCollider2D playerBodyCollider;
    BoxCollider2D playerFeetCollider;

    [Tooltip("Change this value to change the run speed")]
    [SerializeField] float runSpeed = 5.0f;

    [Tooltip("Change this value to change the jump height")]
    [SerializeField] float jumpSpeed = 5.0f;

    [Tooltip("Change this value to change the climb speed")]
    [SerializeField] float climbSpeed = 5.0f;

    private float gravityScaleAtStart;

    private bool isAlive = true;

    [SerializeField] Vector2 deathSeq = new Vector2(1f, 5f);

    

    // Start is called before the first frame update
    void Start()
    {

        playerCharacter = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerBodyCollider = GetComponent<CapsuleCollider2D>();
        playerFeetCollider = GetComponent<BoxCollider2D>();

        //Store Gravity Scale on start
        gravityScaleAtStart = playerCharacter.gravityScale;

    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
        {

            return;

        }

        Run();
        FlipSprite();
        Jump();
        Climb();
        Die();

    }

    private void Run()
    {

        //gets the value between -1 and 1

        float hMovement = Input.GetAxis("Horizontal");

        Vector2 runVelocity = new Vector2(hMovement * runSpeed, playerCharacter.velocity.y);

        playerCharacter.velocity = runVelocity;

        //checks to see if the speed is higher than zero (if then statement in one line)
        bool hSpeed = Mathf.Abs(playerCharacter.velocity.x) > Mathf.Epsilon;
        playerAnimator.SetBool("run", hSpeed);

    }

    private void Jump()
    {

        //also gets a value between -1 and 1

        float jump = Input.GetAxis("Jump");

        if (!playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground", "Frozen Water", "Ice")))
        {

            return;

        }

        if (Input.GetButtonDown("Jump"))
        {

            Vector2 jumpVelocity = new Vector2(0.0f, jumpSpeed);

            playerCharacter.velocity += jumpVelocity;

        }

    }

    private void FlipSprite()
    {

        // if the player is moving horizontally in one direction

        bool hMovement = Mathf.Abs(playerCharacter.velocity.x) > Mathf.Epsilon;
        
        if(hMovement)
        {

            //reverse current scaling of the x axis
            transform.localScale = new Vector2(Mathf.Sign(playerCharacter.velocity.x), 1f);


        }

    }

    private void Climb()
    {

        if (!playerBodyCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {

            playerAnimator.SetBool("climb", false);

            playerCharacter.gravityScale = gravityScaleAtStart;

            runSpeed = 5.0f;

            return;

        }

        float vMovement = Input.GetAxis("Vertical");

        //x remains the same we need to change y

        Vector2 climbVelocity = new Vector2(playerCharacter.velocity.x, vMovement * climbSpeed);

        playerCharacter.velocity = climbVelocity;

        playerCharacter.gravityScale = 0.0f;

        runSpeed = 2.5f;

        bool vSpeed = Mathf.Abs(playerCharacter.velocity.y) > Mathf.Epsilon;
        
        playerAnimator.SetBool("climb", vSpeed);

    }

    private void Die()
    {

        if (playerBodyCollider.IsTouchingLayers(LayerMask.GetMask("Water", "Enemy")))
        {

            isAlive = false;

            playerAnimator.SetTrigger("die");

            playerCharacter.velocity = deathSeq;

            FindObjectOfType<GameSession>().ProcessPlayerDeath();

        }

    }

}
