using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCheck : MonoBehaviour
{
    private Player player;
    
    void Awake(){
        
        player = GetComponentInChildren<Player>();

    }

    void Update()
    {
        if (player.isDead == true){
            SceneManager.LoadScene("Menu");
        }
        player.isDead = false;
    }
}
