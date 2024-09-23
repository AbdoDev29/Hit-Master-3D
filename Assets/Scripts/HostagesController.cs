using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HostagesController : MonoBehaviour
{
    PlayerMovement playerMovement;
    Animator anim;

    //public Transform player;
    //[SerializeField] float distanceAmount = 25f;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (!playerMovement.isTargetChanged)
        {
            anim.SetBool("Waving", true);
        }
        else if(playerMovement.isTargetChanged)
        {
            anim.SetBool("Dance", true);
        }
        //float distance = Vector3.Distance(transform.position,pl)
        //if()
    }
}
