using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D ridged;
    private float moveH;
    private float moveV;
    public float speed;
    public float jumpForce;
    public float fallMult;
    public bool grounded;

    void Update()
    {
        moveH = Input.GetAxisRaw("Horizontal");
        moveV = Input.GetAxisRaw("Vertical");
        Vector2 directions = new Vector2(moveH, moveV);

        Walk(directions);

        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            ridged.velocity = Vector2.up * jumpForce;
        }

        if (ridged.velocity.y < 0f)
        {
            ridged.velocity += Vector2.up * Physics2D.gravity.y * (fallMult - 1f) * Time.deltaTime;
        }
        else if (ridged.velocity.y > 0f && !Input.GetButton("Jump"))
        {
            ridged.velocity += Vector2.up * Physics2D.gravity.y * (fallMult - 1f) * Time.deltaTime;
        }
    }

    private void Walk(Vector2 directions)
    {
        ridged.velocity = new Vector2(moveH * speed, ridged.velocity.y);
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Grounded");
            grounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("JUSUS WAS BROWN");
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Not grounded");
            grounded = false;
        }
    }
}
