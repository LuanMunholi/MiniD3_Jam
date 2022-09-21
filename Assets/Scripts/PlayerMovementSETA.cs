using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSETA : MonoBehaviour
{
    [Header("Variaveis de movimentação")]
    float moveSpeed = 5f;
    public Rigidbody2D rb;

    private Vector2 movement;

    void Update()
    {
        ProcessInputs();  
    }

    void FixedUpdate()
    {
        Move();
    }


    void ProcessInputs()
    {
        float move_x = Input.GetAxisRaw("Horizontal2");
        float move_y = Input.GetAxisRaw("Vertical2");

        movement = new Vector2(move_x, move_y);
    }   

    void Move()
    {
        rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
    }

}



   

