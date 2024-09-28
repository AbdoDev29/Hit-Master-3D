using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    PlayerLookAtEnemies playerLookAtEnemies;
    UIController uiController;
    Animator anim;
    //public Transform player;

    private void Awake()
    {
        playerLookAtEnemies=FindObjectOfType<PlayerLookAtEnemies>();
        uiController = GetComponent<UIController>();
        anim = FindObjectOfType<Animator>();
    }

    private void Update()
    {
       
             EnemyAttack();
       
    }
    public void EnemyAttack()
    {
       
            float distance = Vector3.Distance(playerLookAtEnemies.currentTarget.position, transform.position);
           
            if(distance < 7f)
            {
                Debug.Log("The enemy is clothest to player");
                anim.SetInteger("Walk", 0);
                anim.SetBool("Attack", true);
                uiController.Failed();
            }

        
    }

}
