using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class AgentMover : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public Animator animator;
    [SerializeField] private float maxSpeed = 2, acceleration = 50, deacceleration = 100;
    [SerializeField] private float currentSpeed = 0;

    private Vector2 oldMovementInput;

    public Vector2 MovementInput{ get; set;}

    public Player player;
    
    public string idleUp = "PlayerIdleUp";
    public string idleDown = "PlayerIdleDown";
    public string idleLeft = "PlayerIdleLeft";
    public string idleRight = "PlayeridleRight";

    public string PlayerWalkingUp = "PlayerWalkingUp";
    public string PlayerWalkingDown = "PlayerWalkingDown";
    public string PlayerWalkingLeft = "PlayerWalkingLeft";
    public string PlayerWalkingRight = "PlayerWalkingRight";

    public string PlayerHitUp = "PlayerHitUp";
    public string PlayerHitDown = "PlayerHitDown";
    public string PlayerHitLeft = "PlayerHitLeft";
    public string PlayerHitRight = "PlayerHitRight";

    public string PlayerAttackUp = "PlayerAttackUp";
    public string PlayerAttackDown = "PlayerAttackDown";
    public string PlayerAttackLeft = "PlayerAttackLeft";
    public string PlayerAttackRight = "PlayerAttackRight";


    void Start (){

        animator = GetComponent<Animator>();

    }

    void ChangeAnimationState (string newState){

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

        if (player.animationBlock == true) return;

        if (player.memoryLastState == idleUp && rb2d.velocity.x == 0 && rb2d.velocity.y == 0){

            player.currentState = idleUp;
            
        }

        if (player.memoryLastState == PlayerWalkingUp && rb2d.velocity.x == 0 && rb2d.velocity.y == 0){

            player.currentState = idleUp;
            
        }

        if (player.memoryLastState == PlayerAttackUp && rb2d.velocity.x == 0 && rb2d.velocity.y == 0){

            player.currentState = idleUp;
            
        }

        if (player.memoryLastState == PlayerHitDown && rb2d.velocity.x == 0 && rb2d.velocity.y == 0){

            player.currentState = idleUp;
            
        }

        if (player.memoryLastState == idleDown && rb2d.velocity.x == 0 && rb2d.velocity.y == 0){

            player.currentState = idleDown;
            
        } 

        if (player.memoryLastState == PlayerWalkingDown && rb2d.velocity.x == 0 && rb2d.velocity.y == 0){

            player.currentState = idleDown;
            
        }

        if (player.memoryLastState == PlayerAttackDown && rb2d.velocity.x == 0 && rb2d.velocity.y == 0){

            player.currentState = idleDown;
            
        }

        if (player.memoryLastState == PlayerHitUp && rb2d.velocity.x == 0 && rb2d.velocity.y == 0){

            player.currentState = idleDown;
            
        }

        if (player.memoryLastState == idleLeft && rb2d.velocity.x == 0 && rb2d.velocity.y == 0){

            player.currentState = idleLeft;
            
        }
        
        if (player.memoryLastState == PlayerWalkingLeft  && rb2d.velocity.x == 0 && rb2d.velocity.y == 0){

            player.currentState = idleLeft;
            
        }
        
        if (player.memoryLastState == PlayerAttackLeft  && rb2d.velocity.x == 0 && rb2d.velocity.y == 0){

            player.currentState = idleLeft;
            
        }
        
        if (player.memoryLastState == PlayerHitRight && rb2d.velocity.x == 0 && rb2d.velocity.y == 0){

            player.currentState = idleLeft;
            
        }

        if (player.memoryLastState == idleRight && rb2d.velocity.x == 0 && rb2d.velocity.y == 0){

            player.currentState = idleRight;
            
        }
        
        if (player.memoryLastState == PlayerWalkingRight && rb2d.velocity.x == 0 && rb2d.velocity.y == 0){

            player.currentState = idleRight;
            
        }
        
        if (player.memoryLastState == PlayerAttackRight && rb2d.velocity.x == 0 && rb2d.velocity.y == 0){

            player.currentState = idleRight;
            
        }
        
        if (player.memoryLastState == PlayerHitLeft && rb2d.velocity.x == 0 && rb2d.velocity.y == 0){

            player.currentState = idleRight;
            
        }

        if (rb2d.velocity.y > 0 && rb2d.velocity.x < rb2d.velocity.y){

            player.currentState = PlayerWalkingUp;
            Debug.Log(rb2d.velocity.x);
            Debug.Log(rb2d.velocity.y);
            Debug.Log(player.animationBlock);
            Debug.Log(player.memoryLastState);
            Debug.Log(player.currentState);

        }

        if (rb2d.velocity.x > 0 && rb2d.velocity.y < rb2d.velocity.x){
        
            player.currentState = PlayerWalkingRight;
            Debug.Log(rb2d.velocity.x);
            Debug.Log(rb2d.velocity.y);
            Debug.Log(player.animationBlock);
            Debug.Log(player.memoryLastState);
            Debug.Log(player.currentState);

        }

        if (rb2d.velocity.y < 0 && rb2d.velocity.x > rb2d.velocity.y){
            
            player.currentState = PlayerWalkingDown;
            Debug.Log(rb2d.velocity.x);
            Debug.Log(rb2d.velocity.y);
            Debug.Log(player.animationBlock);
            Debug.Log(player.memoryLastState);
            Debug.Log(player.currentState);

        }

        if (rb2d.velocity.x < 0 && rb2d.velocity.y > rb2d.velocity.x){
            
            player.currentState = PlayerWalkingLeft;
            Debug.Log(rb2d.velocity.x);
            Debug.Log(rb2d.velocity.y);
            Debug.Log(player.animationBlock);
            Debug.Log(player.memoryLastState);
            Debug.Log(player.currentState);

        }

        player.memoryLastState = player.currentState;
        ChangeAnimationState(player.currentState);
        
    }

    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();    
    }
}
