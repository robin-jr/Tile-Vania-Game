using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float jumpSpeed = 50f;
    [SerializeField] float climbSpeed = 10f;
    Rigidbody2D myRigidBody;
    CapsuleCollider2D myCapsuleCollider;
    BoxCollider2D myBoxCollider;
    Animator myAnimator;
    bool isAlive = true;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        myAnimator = GetComponent<Animator>();
        myBoxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return; }
        Run();
        Jump();
        Climb();
        Die();
    }

    private void Die()
    {
        if (myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            isAlive = false;
            myRigidBody.velocity = new Vector2(0f, 20f);
            myAnimator.SetTrigger("isDead");
            FindObjectOfType<GameSession>().HandleDeath();
        }
    }
    private void Run()
    {
        float horizontalChange = Input.GetAxis("Horizontal");
        if (horizontalChange == 0)
        {
            myAnimator.SetBool("isRunning", false);
            return;
        }
        Vector2 velocityChange = new Vector2(horizontalChange * moveSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = velocityChange;
        if (horizontalChange < 0)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
        else
        {
            transform.localScale = new Vector2(1f, 1f);
        }
        myAnimator.SetBool("isRunning", true);
    }
    private void Jump()
    {
        if (!myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            // myAnimator.SetBool("isJumping", false);
            return;
        }
        if (Input.GetButtonDown("Jump"))
        {
            Vector2 velocityChange = new Vector2(myRigidBody.velocity.x, jumpSpeed);
            myRigidBody.velocity = velocityChange;
            // myAnimator.SetBool("isJumping", true);
        }
    }
    private void Climb()
    {
        if (myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            myAnimator.SetBool("isClimbing", true);
            myRigidBody.gravityScale = 0;
            float verticalChange = Input.GetAxis("Vertical");
            Vector2 velocityChange = new Vector2(myRigidBody.velocity.x, verticalChange * climbSpeed);
            myRigidBody.velocity = velocityChange;
        }
        else
        {
            myAnimator.SetBool("isClimbing", false);
            myRigidBody.gravityScale = 1;
        }
    }
}
