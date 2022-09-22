using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectHit : MonoBehaviour
{
    [SerializeField] private bool isDead = false;
    
    public UnityEvent<GameObject> OnHitWithReference;

    public void GetHit(GameObject sender){

        if (isDead) return;
        if (sender.layer == gameObject.layer) return;

        OnHitWithReference?.Invoke(sender);

    }

}
