using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class Knockback : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private float strength = 6, delay = 0.15f;

    public UnityEvent OnBegin, OnDone;

    public void PlayFeedback (GameObject sender){
        
        StopAllCoroutines();
        
        OnBegin?.Invoke();
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        body.AddForce(direction * strength, ForceMode2D.Impulse);

        StartCoroutine(Reset());

    }

    private IEnumerator Reset (){
        
        yield return new WaitForSeconds(delay);
        
        body.velocity = Vector3.zero;
        OnDone?.Invoke();

    }


}
