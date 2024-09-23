using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public List<GameObject> enemies;

    private void Update()
    {
      for(int i = enemies.Count-1; i>=0; i--)
        {
            if (enemies[i] == null)
                enemies.RemoveAt(i);
        }

        if (enemies.Count == 0)
            Debug.Log("Aii enemies is dead!!");
    }

}
