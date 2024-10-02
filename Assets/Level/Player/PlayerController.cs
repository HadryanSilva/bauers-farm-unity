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
    Vector2 movement = Vector2.zero;
    public float moveSpeed = 10.0f;
    public Rigidbody2D rb;

    [Header("Player Animation Hashes")]
    public readonly int ANIMATOR_IDLE_DOWN = Animator.StringToHash("Anim_Player_Idle_Down");
    public readonly int ANIMATOR_IDLE_UP = Animator.StringToHash("Anim_Player_Idle_Up");
    public readonly int ANIMATOR_IDLE_RIGHT = Animator.StringToHash("Anim_Player_Idle_Right");
    public readonly int ANIMATOR_IDLE_LEFT = Animator.StringToHash("Anim_Player_Idle_Left");

    public readonly int ANIMATOR_MOVE_DOWN = Animator.StringToHash("Anim_Player_Move_Down");
    public readonly int ANIMATOR_MOVE_UP = Animator.StringToHash("Anim_Player_Move_Up");
    public readonly int ANIMATOR_MOVE_RIGHT = Animator.StringToHash("Anim_Player_Move_Right");
    public readonly int ANIMATOR_MOVE_LEFT = Animator.StringToHash("Anim_Player_Move_Left");
    
    void Start()
    {
        
    }

    void FixedUpdate() {
        MovePlayer();
        GetPlayerDirection();
        UpdateAnimationAndSprite();
    }

    void MovePlayer()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        rb.velocity = movement * moveSpeed * Time.fixedDeltaTime;
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

    void UpdateAnimationAndSprite() {
        if (movement.magnitude > 0) // if player is moving
        {
            if (currentDirection == Directions.DOWN) {
                animator.CrossFade(ANIMATOR_MOVE_DOWN, 0);
            } else if(currentDirection == Directions.UP) {
                animator.CrossFade(ANIMATOR_MOVE_UP, 0);
            } else if(currentDirection == Directions.RIGHT) {
                animator.CrossFade(ANIMATOR_MOVE_RIGHT, 0);
            } else if(currentDirection == Directions.LEFT) {
                animator.CrossFade(ANIMATOR_MOVE_LEFT, 0);
            }
        } else
        {
            if (currentDirection == Directions.DOWN) {
                animator.CrossFade(ANIMATOR_IDLE_DOWN, 0);
            } else if(currentDirection == Directions.UP) {
                animator.CrossFade(ANIMATOR_IDLE_UP, 0);
            } else if(currentDirection == Directions.RIGHT) {
                animator.CrossFade(ANIMATOR_IDLE_RIGHT, 0);
            } else if(currentDirection == Directions.LEFT) {
                animator.CrossFade(ANIMATOR_IDLE_LEFT, 0);
            }
        }
    }
}
