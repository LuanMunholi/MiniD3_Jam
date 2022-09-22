using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class KnockbackArea : MonoBehaviour
{

    [SerializeField] private InputActionReference knockback;
    [SerializeField] private float delayAttack = 0.3f;
    private Knockback Knockback;
    
    public bool IsAttacking{get; private set;}

    public Transform circleOrigin;
    public float radius;

    private void Awake(){

        Knockback = GetComponent<Knockback>();

    }

    public void ResetAttack(){

        IsAttacking = false;

    }    

    private bool attackBlocked;
    public Animator animator;

    public void Attack(){

        if (attackBlocked)
            return;

        animator.SetTrigger("AttackDown");
        attackBlocked = true;
        StartCoroutine(DelayAttack());
    }
    
    private IEnumerator DelayAttack (){
        
        yield return new WaitForSeconds(delayAttack);
        attackBlocked = false;

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