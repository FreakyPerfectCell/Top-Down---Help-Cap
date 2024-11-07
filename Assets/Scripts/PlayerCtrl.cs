using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float movSpeed;
    float speedX, speedY;
    Rigidbody2D rb;
    bool facingRight = true; // Track the current facing direction

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movSpeed;
        rb.velocity = new Vector2(speedX, speedY);

        // Flip the sprite based on horizontal input
        if (speedX < 0 && facingRight)
        {
            Flip();
        }
        else if (speedX > 0 && !facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        // Invert the x scale to flip the sprite
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}