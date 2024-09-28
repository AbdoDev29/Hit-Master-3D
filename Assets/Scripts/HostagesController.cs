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
            GetComponent<CapsuleCollider>().enabled = false;
        }
        else if(playerMovement.isTargetChanged)
        {
            anim.SetBool("Dance", false);
            GetComponent<CapsuleCollider>().enabled = true;
        }
    }

 
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Knife")
        {
            Debug.Log("You alredy kiled the hostage");
            Destroy(this.gameObject);
            uiController.Failed();
        }
    }
}
