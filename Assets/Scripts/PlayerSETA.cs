using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSETA : MonoBehaviour
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
        
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            move_y = 1;
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            move_y = -1;
        }
        
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            move_x = -1;
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            move_x = 1;
        }

        if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            move_y = 0;
        }

        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
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


