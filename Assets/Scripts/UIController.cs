using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    PlayerLookAtEnemies playerLookAtEnemies;

    public GameObject winPanel;
    public GameObject failedPanel;

    private void Awake()
    {
        playerLookAtEnemies=FindObjectOfType<PlayerLookAtEnemies>();
    }

    private void Start()
    {
        winPanel.SetActive(false);
        failedPanel.SetActive(false);
    }

    private void Update()
    {
        Win();
    }
    public void Win()
    {
        if (playerLookAtEnemies.enemies.Count == 0)
        {
            winPanel.SetActive(true);
        }
    }

    public void Failed() 
    {
        failedPanel.SetActive(true);
    }
}
