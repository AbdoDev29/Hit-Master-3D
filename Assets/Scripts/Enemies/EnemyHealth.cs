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
        Debug.Log("Health: " + currentHealth);
    }
    public void DecreaseHealth(int damage)
    {
        Debug.Log("Health: " + currentHealth);
        currentHealth -= damage;
        if(currentHealth == 0)
        {
            isEnemyDead = true;
        }
    }
}
