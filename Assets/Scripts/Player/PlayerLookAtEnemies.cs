using UnityEngine;
using System.Collections.Generic;

public class PlayerLookAtEnemies : MonoBehaviour
{
    public List<Transform> enemies;
    public float rotationSpeed = 5f; 
    private Transform currentTarget;
    public float closestDistance;
    void Update()
    {
        if (enemies.Count > 0)
        {
            currentTarget = GetClosestEnemy();
          
            if (currentTarget != null)
            {
                // Player turns to look at nearest enemy
                Vector3 direction = (currentTarget.position - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
            }
        }
    }

               



    // Find the nearest enemy
    Transform GetClosestEnemy()
    {
        Transform closestEnemy = null;
        closestDistance = Mathf.Infinity;

        
        foreach (Transform enemy in enemies)
        {
            if (enemy != null)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.position);
                if (distanceToEnemy < closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    closestEnemy = enemy;
                    
                }
            }
        }

        return closestEnemy;
    }

    private void MoveToAnotherEnemy()
    {
        
    }

    // استدعاء هذه الدالة عند موت العدو لإزالته من القائمة
    public void OnEnemyDeath(Transform enemy)
    {
        //if (enemies.Contains(enemy))
        //{
        //    enemies.Remove(enemy); // إزالة العدو من القائمة عند موته
        //}
    }
}

