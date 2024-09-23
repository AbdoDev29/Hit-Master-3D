using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    // References
    KnifeThrow knifeThrow;
    Animator anim;
    PlayerLookAtEnemies playerLookAtEnemies;
    

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
           anim.SetBool("Attack", true);
           knifeThrow.ThrowKnife();
           
        }
        else
        {
            anim.SetBool("Attack", false);
        }

    }

       
       



       


       

  

 
    
}
