using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private AgentMover agentMover;
    public Animator animator;
    private Vector2 movementInput;
    private KnockbackArea knockbackArea;

    [SerializeField] private InputActionReference movement, knockback;

    private void Awake(){

        knockbackArea = GetComponentInChildren<KnockbackArea>();
        agentMover = GetComponent<AgentMover>();

    }

    private void OnEnable(){

        knockback.action.performed += PerformKnockback;

    }

    private void OnDisable(){

        knockback.action.performed -= PerformKnockback;

    }

    private void PerformKnockback(InputAction.CallbackContext obj){

        knockbackArea.Attack();

    }

    private void Update(){

        movementInput = movement.action.ReadValue<Vector2>();

        agentMover.MovementInput = movementInput;
        
        if (movementInput.x > 0 && movementInput.y < movementInput.x) animator.SetTrigger("WalkRight");
        if (movementInput.y > 0 && movementInput.x < movementInput.y) animator.SetTrigger("WalkUp");
        if (movementInput.x < 0 && movementInput.y > movementInput.x) animator.SetTrigger("WalkLeft");
        if (movementInput.y < 0 && movementInput.x > movementInput.y) animator.SetTrigger("WalkDown");

        movementInput = Vector2.zero;

    }


}



   

