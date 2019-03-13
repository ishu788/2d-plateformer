using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
    public float speed;
    public float jumpForce;
    private float moveInput;

    public Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGounded;
    public Transform groundCheck;
    public float Checkradius;
    public LayerMask whatisGround;

    public int extraJumps;
    public int extraJumpsValue;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        extraJumps = extraJumpsValue;
    }


    void FixedUpdate() {
        isGounded = Physics2D.OverlapCircle(groundCheck.position, Checkradius, whatisGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }
    void Update()
    {
        if (isGounded == true)
        {
            extraJumps = extraJumpsValue;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }


}
