using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    enum Directions {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }
    [Header("Player Animation settings")]
    Directions currentDirection = Directions.DOWN;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    [Header("Player Movement Settings")]
    Vector2 movement;
    public float moveSpeed = 10.0f;
    public Rigidbody2D rb;
    
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        MovePlayer();
        GetPlayerDirection();
    }

    void MovePlayer()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void GetPlayerDirection()
    {
        if (movement.x > 0)
        {
            currentDirection = Directions.RIGHT;
        }
        else if (movement.x < 0)
        {
            currentDirection = Directions.LEFT;
        }
        else if (movement.y > 0)
        {
            currentDirection = Directions.UP;
        }
        else if (movement.y < 0)
        {
            currentDirection = Directions.DOWN;
        }
    }
}
