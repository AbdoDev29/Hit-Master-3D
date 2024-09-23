using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HostagesController : MonoBehaviour
{
    PlayerMovement playerMovement;
    Animator anim;
    UIController uiController;
 
    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        anim = GetComponent<Animator>();
        uiController = FindObjectOfType<UIController>();
    }
    private void Update()
    {
        if (!playerMovement.isTargetChanged)
        {
            anim.SetBool("Dance", true);
           
        }
        else if(playerMovement.isTargetChanged)
        {
            anim.SetBool("Dance", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Knife"))
            // destroy the hostage to test
          uiController.Failed();
    }
}
