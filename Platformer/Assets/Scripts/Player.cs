using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D playerCharacter;
    Animator playerAnimator;

    [Tooltip("Change this value to change the run speed")]
    [SerializeField] float runSpeed = 5.0f;

    [Tooltip("Change this value to change the jump height")]
    [SerializeField] float jumpHeight = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

        playerCharacter = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        Run();
        FlipSprite();
        

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

        Vector2 jumpVelocity = new Vector2(jump * runSpeed, playerCharacter.velocity.y);

        playerCharacter.velocity = jumpVelocity;

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

}