using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float walkingSpeed;
    public float runningSpeed;
    public float jumpForce;

    public LayerMask platform;
    public Animator anim;
    private BoxCollider2D box2d;

    bool facingRight = true;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        box2d = transform.GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        Vector3 playerPos = this.transform.position;

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift) == true)
        {
            playerPos.x = playerPos.x + walkingSpeed;
            this.transform.position = playerPos;

            anim.SetTrigger("isWalking");

            if (facingRight == false)
            {
                Flip();
            }
        }

        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift) == true)
        {
            playerPos.x = playerPos.x - walkingSpeed;
            this.transform.position = playerPos;

            anim.SetTrigger("isWalking");

            if (facingRight == true)
            {
                Flip();
            }
        }

        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift) == false)
        {
            playerPos.x = playerPos.x + runningSpeed;
            this.transform.position = playerPos;

            anim.SetTrigger("isRunning");

            if (facingRight == false)
            {
                Flip();
            }
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift) == false)
        {
            playerPos.x = playerPos.x - runningSpeed;
            this.transform.position = playerPos;

            anim.SetTrigger("isRunning");

            if (facingRight == true)
            {
                Flip();
            }
        }
        else if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            Jump();
        }
        else
        {
            anim.SetTrigger("isIdle");
        }
    }

    void Flip()
    {
        //set the facingRight variable to the opposite of what it was
        facingRight = !facingRight;

        //store the scale of the player in a variable
        Vector3 playerScale = this.transform.localScale;

        //reverse the direction of the player
        playerScale.x = playerScale.x * -1;

        //set the player's scale to the new value
        this.transform.localScale = playerScale;
    }

    void Jump() //not working properly + animation is not correct
    {
        anim.SetTrigger("isJumping");
        //rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        rb.AddRelativeForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        //rb.AddRelativeForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    bool isGrounded()
    {
        float h = 0.2f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(box2d.bounds.center, box2d.bounds.size, 0f, Vector2.down, box2d.bounds.extents.y + h, platform);
        return raycastHit.collider != null;
    }
}
