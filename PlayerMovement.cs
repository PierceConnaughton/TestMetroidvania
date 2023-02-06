using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    //necssary for animations and physics
    private Rigidbody2D rb2D;
    private Animator myAnimator;

    private bool facingRight = true;



    //variables to play with
    public float speed = 2.0f;
    public float horizMovement; // =1 or -1 or 0

    // Start is called before the first frame update
    private void Start()
    {
        //define the gameobjects found on the player
        rb2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    //Handles input for physics
    private void Update()
    {
        //check direction given by player   
        horizMovement = Input.GetAxisRaw("Horizontal");
    }

    //handles running the physics
    private void FixedUpdate()
    {
        //move the character left or right
        rb2D.velocity = new Vector2(horizMovement * speed, rb2D.velocity.y);
        Flip(horizMovement);

        //check speed of player and set it to speed so animation of running plays
        myAnimator.SetFloat("speed", Mathf.Abs(horizMovement));
    }

    //flipping function
    private void Flip(float horizon)
    {
        //check what direction we are currently facing and if we are moving left or right
        //if we are moving leftt and facing right or moving right and facing left change direction
        if ((horizon < 0 && facingRight) || (horizon > 0 && !facingRight))
        {
            //change direction to the opposite of what we are currently on
            facingRight = !facingRight;

            //get the current players scale
            Vector3 theScale = transform.localScale;

            //change the x axis of the current player scale and multiply it by -1 to get it in the correct direction
            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }
}
