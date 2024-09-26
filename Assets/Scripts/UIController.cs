using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    // References
    PlayerLookAtEnemies playerLookAtEnemies;

    public GameObject winPanel;
    public GameObject failedPanel;

    private void Awake()
    {
        playerLookAtEnemies=FindObjectOfType<PlayerLookAtEnemies>();
        audioManager = FindObjectOfType<AudioManager>();
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
          //  audioManager.PlaySound("Winning");
        }
    }

    public void Failed() 
    {
        failedPanel.SetActive(true);
       // audioManager.PlaySound("Failling");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
