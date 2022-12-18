using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornsMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    
    public float topy, boty;

    private bool moveBot = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.isPasued)
        {
            return;
        }
        move();
    }

    private void move()
    {
        if (moveBot)
        {
            rb.velocity = new Vector2(rb.velocity.x, -speed);
            if (transform.position.y < boty)
            {
                moveBot = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x,speed);
            if (transform.position.y > topy)
            {
                
                moveBot = true;
            }
        }
    }
}
