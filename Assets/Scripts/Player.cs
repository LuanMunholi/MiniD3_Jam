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

    public string memoryLastState;
    public string currentState;

    public bool animationBlock = false;
    public bool attackBlocked = false;

    private void Awake(){

        animator = GetComponent<Animator>();
        knockbackArea = GetComponentInChildren<KnockbackArea>();
        agentMover = GetComponent<AgentMover>();

        animator.Play("PlayerIdleDown");
        memoryLastState = "PlayerIdleDown";
        currentState = "PlayerIdleDown";

    }

    private void OnEnable(){

        knockback.action.performed += PerformKnockback;

    }

    private void OnDisable(){

        knockback.action.performed -= PerformKnockback;

    }

    private void PerformKnockback(InputAction.CallbackContext obj){

        movementInput = movement.action.ReadValue<Vector2>();

        knockbackArea.MovementInput = movementInput;
        knockbackArea.Attack();

        movementInput = Vector2.zero;

    }

    private void Update(){

        movementInput = movement.action.ReadValue<Vector2>();

        agentMover.MovementInput = movementInput;
        agentMover.PlayAnimation();

        movementInput = Vector2.zero;

    }

}