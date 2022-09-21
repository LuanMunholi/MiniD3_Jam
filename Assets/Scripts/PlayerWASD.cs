using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWASD : MonoBehaviour
{
    [Header("Variaveis de movimentação")]
    float moveSpeed = 5f;
    public Rigidbody2D rb;
    float move_x;
    float move_y;

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
        
        if(Input.GetKeyDown(KeyCode.W))
        {
            move_y = 1;
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            move_y = -1;
        }
        
        if(Input.GetKeyDown(KeyCode.A))
        {
            move_x = -1;
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            move_x = 1;
        }

        if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            move_y = 0;
        }

        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            move_x = 0;
        }

        movement = new Vector2(move_x, move_y);
    }   

    void Move()
    {
        rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
    }

}



   