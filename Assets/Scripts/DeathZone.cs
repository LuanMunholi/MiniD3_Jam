using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    private Player player;

    private void Awake(){

        player = GetComponentInChildren<Player>();

    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("GroundCheck"))
        {
            player.isDead = true;
        }
        
    }
}