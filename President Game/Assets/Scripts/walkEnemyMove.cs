using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkEnemyMove : MonoBehaviour
{
    public float speed;
    public bool movingRight = true;
    public Transform groundDetection;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (movingRight == true)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (movingRight == false)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
    }

    void Update()
    {
        
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        // Check if it reaches the edge
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        if (groundInfo.collider == false)
        {
            Debug.Log("GROUND");
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
        if (player.transform.position.x < transform.position.x)
        {

        }
        
        
    }
    // Check if it hits enemy
    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Ground")
        {
            Debug.Log("SIDE");
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
