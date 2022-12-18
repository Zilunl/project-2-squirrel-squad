using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonedCloudMove : MonoBehaviour
{
    
    public Rigidbody2D rb;
    [SerializeField] public Transform pos_left, pos_right;
    public float speed;
    public bool moveLeft = true;
    public float leftx, rightx;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        leftx = pos_left.position.x+1f;
        rightx = pos_right.position.x-1f;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void move()
    {
        if (moveLeft) {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            if (transform.position.x < leftx)
            {
                moveLeft = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (transform.position.x > rightx)
            {
                moveLeft = true;
            }
        }
    }
}
