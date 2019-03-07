using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpBody : MonoBehaviour {

    public static bool facingRight;
    public Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        facingRight = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float h = Input.GetAxis("Horizontal");

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("Attack", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("Attack", false);
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
