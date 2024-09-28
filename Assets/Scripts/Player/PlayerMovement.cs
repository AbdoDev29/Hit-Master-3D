using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    // References
    KnifeThrow knifeThrow;
    Animator anim;
    PlayerLookAtEnemies playerLookAtEnemies;
    AudioManager audioManager;

    [SerializeField] float speedMov = 5f;
    [SerializeField] float distanceAmount = 25f;
    [SerializeField] float rayDistance = 10f;
    

    [Header("NavMeshAgent")]
    NavMeshAgent agent;
    public Transform[] targets;
    private int currentTargetIndex = 0;
    public bool isTargetChanged = true;

    


    private void Awake()
    {
        anim = GetComponent<Animator>();
        knifeThrow = FindObjectOfType<KnifeThrow>();
        agent = GetComponent<NavMeshAgent>();
        playerLookAtEnemies = FindObjectOfType<PlayerLookAtEnemies>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Start()
    {
        agent.SetDestination(targets[currentTargetIndex].position);
    }

    private void Update()
    {
        Move();
        Attck();
    }
    private void Move()
    {
        if (playerLookAtEnemies.closestDistance > distanceAmount && isTargetChanged)
        {
            currentTargetIndex += 1;
            if(currentTargetIndex < targets.Length)
            agent.SetDestination(targets[currentTargetIndex].position);
            isTargetChanged = false;
        }
        else if (playerLookAtEnemies.closestDistance < distanceAmount)
        {
            isTargetChanged = true;
        }
    }
    private void Attck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
           anim.SetBool("Attack", true);
           knifeThrow.ThrowKnife();
           audioManager.PlaySound("ThrowingKnife");
        }
        else
        {
            anim.SetBool("Attack", false);
        }

    }

       
       



       


       

  

 
    
}
