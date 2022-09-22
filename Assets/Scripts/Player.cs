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
    [SerializeField] private float animationDelay = 0.3f;

    public string memoryLastState;
    public string currentState;

    public bool animationBlock = false;

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

        knockbackArea.Attack();

    }

    private void Update(){

        movementInput = movement.action.ReadValue<Vector2>();

        agentMover.MovementInput = movementInput;
        
        StartCoroutine(AnimationDelay());

        movementInput = Vector2.zero;

    }

    private IEnumerator AnimationDelay (){
        
        yield return new WaitForSeconds(animationDelay);
        animationBlock = false;

    }

}



   

