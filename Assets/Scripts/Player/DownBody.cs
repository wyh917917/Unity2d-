using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownBody : MonoBehaviour {
    public bool facingRight = true;
    bool grounded = false;
    bool doubleJump = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public Rigidbody2D downBody;
    public Transform DB_transform;
    public Animator anim;

    private float minVelocity;
    private float maxVelocity;
    private float x;
    public float Speed ;
    public float JumpForce ;

    public LayerMask whatIsGround;

    // Use this for initialization
    void Start () {
        downBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        DB_transform = GetComponent<Transform>();

        facingRight = true;

        minVelocity = -1f;
        maxVelocity = 1f;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);


        //移动
        float h = Input.GetAxis("Horizontal");
        downBody.AddForce(new Vector2(h * Speed, 0));
        x = Mathf.Clamp(downBody.velocity.x, minVelocity, maxVelocity);
        downBody.velocity = new Vector2(x, downBody.velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(h));

        

        //转向
        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        
    }

    void Update()
    {
        if ( grounded && Input.GetKeyDown(KeyCode.Space))
        {
            doubleJump = false;
            anim.SetBool("Ground", false);
            downBody.AddForce(new Vector2(0, JumpForce));
        }

        if (!doubleJump && !grounded && Input.GetKeyDown(KeyCode.Space))
        {
            doubleJump = true;
            downBody.AddForce(new Vector2(0, JumpForce));
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


}
