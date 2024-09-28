using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int maxHealth = 30;
    private int currentHealth;
    public bool isEnemyDead = false;
    private void Start()
    {
        currentHealth = maxHealth;
        
    }
    public void DecreaseHealth(int damage)
    {
        currentHealth -= damage;
        if(currentHealth == 0)
        {
            isEnemyDead = true;
        }
    }
}
