using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class KnockbackArea : MonoBehaviour
{

    [SerializeField] private InputActionReference knockback;

    private AgentMover agentMover;
    private Player player;
    private Knockback Knockback;
    public Animator animator;

    public Vector2 MovementInput{ get; set;}
    public bool IsAttacking{get; private set;}

    public Transform circleOrigin;
    public float radius;

    private void Awake(){

        Knockback = GetComponentInParent<Knockback>();
        agentMover = GetComponentInParent<AgentMover>();
        player = GetComponentInParent<Player>();

    }

    public void ResetAttack(){

        IsAttacking = false;

    }    

    public void Attack(){

        if (player.attackBlocked)
            return;

        agentMover.PlayAttackAnimation();

    }

    private void OnDrawGizmosSelected(){

        Gizmos.color = Color.blue;
        Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;
        Gizmos.DrawWireSphere(position, radius);

    }

    public void DetectColliders(){

        foreach (Collider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position, radius)){

            DetectHit hit;
            
            if (hit = collider.GetComponent<DetectHit>())
                hit.GetHit(transform.parent.gameObject);

        }

    }

}