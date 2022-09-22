using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class AgentMover : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public Animator animator;
    [SerializeField] private float maxSpeed = 2, acceleration = 50, deacceleration = 100;
    [SerializeField] private float currentSpeed = 0, animationDelay, attackDelay;

    private Vector2 oldMovementInput;

    public Vector2 MovementInput{ get; set;}

    public Player player;
    
    public const string idleUp = "PlayerIdleUp";
    public const string idleDown = "PlayerIdleDown";
    public const string idleLeft = "PlayerIdleLeft";
    public const string idleRight = "PlayerIdleRight";

    public const string PlayerWalkingUp = "PlayerWalkingUp";
    public const string PlayerWalkingDown = "PlayerWalkingDown";
    public const string PlayerWalkingLeft = "PlayerWalkingLeft";
    public const string PlayerWalkingRight = "PlayerWalkingRight";

    public const string PlayerHitUp = "PlayerHitUp";
    public const string PlayerHitDown = "PlayerHitDown";
    public const string PlayerHitLeft = "PlayerHitLeft";
    public const string PlayerHitRight = "PlayerHitRight";

    public const string PlayerAttackUp = "PlayerAttackUp";
    public const string PlayerAttackDown = "PlayerAttackDown";
    public const string PlayerAttackLeft = "PlayerAttackLeft";
    public const string PlayerAttackRight = "PlayerAttackRight";

    public void PlayAttackAnimation(){

        if (player.attackBlocked == true) return;

        player.attackBlocked = true;

        if (player.memoryLastState == idleUp && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = PlayerAttackUp;
            
        }

        if (player.memoryLastState == PlayerWalkingUp && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = PlayerAttackUp;
            
        }

        if (player.memoryLastState == PlayerAttackUp && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = PlayerAttackUp;
            
        }

        if (player.memoryLastState == PlayerHitDown && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = PlayerAttackUp;
            
        }

        if (player.memoryLastState == idleDown && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = PlayerAttackDown;
            
        } 

        if (player.memoryLastState == PlayerWalkingDown && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = PlayerAttackDown;
            
        }

        if (player.memoryLastState == PlayerAttackDown && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = PlayerAttackDown;
            
        }

        if (player.memoryLastState == PlayerHitUp && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = PlayerAttackDown;
            
        }

        if (player.memoryLastState == idleLeft && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = PlayerAttackLeft;
            
        }
        
        if (player.memoryLastState == PlayerWalkingLeft  && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = PlayerAttackLeft;
            
        }
        
        if (player.memoryLastState == PlayerAttackLeft  && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = PlayerAttackLeft;
            
        }
        
        if (player.memoryLastState == PlayerHitRight && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = PlayerAttackLeft;
            
        }

        if (player.memoryLastState == idleRight && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = PlayerAttackRight;
            
        }
        
        if (player.memoryLastState == PlayerWalkingRight && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = PlayerAttackRight;
            
        }
        
        if (player.memoryLastState == PlayerAttackRight && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = PlayerAttackRight;
            
        }
        
        if (player.memoryLastState == PlayerHitLeft && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = PlayerAttackRight;
            
        }

        if (MovementInput.y > 0 && MovementInput.x < MovementInput.y){

            player.currentState = PlayerAttackUp;
            Debug.Log(player.animationBlock);
            Debug.Log(player.memoryLastState);
            Debug.Log(player.currentState);

        }

        if (MovementInput.x > 0 &&MovementInput.y < MovementInput.x){
        
            player.currentState = PlayerAttackRight;
            Debug.Log(player.animationBlock);
            Debug.Log(player.memoryLastState);
            Debug.Log(player.currentState);

        }

        if (MovementInput.y < 0 && MovementInput.x >MovementInput.y){
            
            player.currentState = PlayerAttackDown;
            Debug.Log(player.animationBlock);
            Debug.Log(player.memoryLastState);
            Debug.Log(player.currentState);

        }

        if (MovementInput.x < 0 &&MovementInput.y > MovementInput.x){
            
            player.currentState = PlayerAttackLeft;
            Debug.Log(player.animationBlock);
            Debug.Log(player.memoryLastState);
            Debug.Log(player.currentState);

        }

        attackDelay = animator.GetCurrentAnimatorStateInfo(0).length;
        Invoke("AttackComplete", animationDelay);
        player.memoryLastState = player.currentState;
        ChangeAnimationState(player.currentState);

    }

    public void PlayAnimation(){

        if (player.animationBlock == true) return;

        player.animationBlock = true;

        if (player.memoryLastState == idleUp && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = idleUp;
            
        }

        if (player.memoryLastState == PlayerWalkingUp && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = idleUp;
            
        }

        if (player.memoryLastState == PlayerAttackUp && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = idleUp;
            
        }

        if (player.memoryLastState == PlayerHitDown && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = idleUp;
            
        }

        if (player.memoryLastState == idleDown && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = idleDown;
            
        } 

        if (player.memoryLastState == PlayerWalkingDown && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = idleDown;
            
        }

        if (player.memoryLastState == PlayerAttackDown && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = idleDown;
            
        }

        if (player.memoryLastState == PlayerHitUp && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = idleDown;
            
        }

        if (player.memoryLastState == idleLeft && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = idleLeft;
            
        }
        
        if (player.memoryLastState == PlayerWalkingLeft  && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = idleLeft;
            
        }
        
        if (player.memoryLastState == PlayerAttackLeft  && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = idleLeft;
            
        }
        
        if (player.memoryLastState == PlayerHitRight && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = idleLeft;
            
        }

        if (player.memoryLastState == idleRight && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = idleRight;
            
        }
        
        if (player.memoryLastState == PlayerWalkingRight && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = idleRight;
            
        }
        
        if (player.memoryLastState == PlayerAttackRight && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = idleRight;
            
        }
        
        if (player.memoryLastState == PlayerHitLeft && MovementInput.x == 0 &&MovementInput.y == 0){

            player.currentState = idleRight;
            
        }

        if (MovementInput.y > 0 && MovementInput.x < MovementInput.y){

            player.currentState = PlayerWalkingUp;
            Debug.Log(player.animationBlock);
            Debug.Log(player.memoryLastState);
            Debug.Log(player.currentState);

        }

        if (MovementInput.x > 0 &&MovementInput.y < MovementInput.x){
        
            player.currentState = PlayerWalkingRight;
            Debug.Log(player.animationBlock);
            Debug.Log(player.memoryLastState);
            Debug.Log(player.currentState);

        }

        if (MovementInput.y < 0 && MovementInput.x >MovementInput.y){
            
            player.currentState = PlayerWalkingDown;
            Debug.Log(player.animationBlock);
            Debug.Log(player.memoryLastState);
            Debug.Log(player.currentState);

        }

        if (MovementInput.x < 0 &&MovementInput.y > MovementInput.x){
            
            player.currentState = PlayerWalkingLeft;
            Debug.Log(player.animationBlock);
            Debug.Log(player.memoryLastState);
            Debug.Log(player.currentState);

        }

        animationDelay = animator.GetCurrentAnimatorStateInfo(0).length;
        Invoke("AnimationComplete", animationDelay);
        player.memoryLastState = player.currentState;
        ChangeAnimationState(player.currentState);

    }

    void AnimationComplete(){

        player.animationBlock = false;

    }

    void AttackComplete(){

        player.attackBlocked = false;

    }

    void ChangeAnimationState (string newState){

        Debug.Log(newState);
        animator.Play(newState);
        player.animationBlock = true;

    }

    private void FixedUpdate() {

        if(MovementInput.magnitude > 0 && currentSpeed >= 0){

            oldMovementInput = MovementInput;
            currentSpeed += acceleration * maxSpeed * Time.deltaTime;

        } else currentSpeed -= deacceleration * maxSpeed * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        rb2d.velocity = oldMovementInput * currentSpeed;
        
    }

    private void Awake() {

        rb2d = GetComponent<Rigidbody2D>();    
        animator = GetComponent<Animator>();

    }

}
