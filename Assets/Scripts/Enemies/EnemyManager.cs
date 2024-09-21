using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    private const int damage = 10;

    // References
    private NavMeshAgent agent;
    private Animator anim;
    public Transform player;
    private EnemyHealth enemyHealth;
    // Variables
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float stoppingDistance = 5.36f;
    
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void Update()
    {

        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            if (agent.speed > 0)
            {
                agent.SetDestination(player.position);
                anim.SetInteger("Walk", 1);
                LookAtPlayer();
            }

            if(distance < stoppingDistance)
            {
                Debug.Log("The enemy is clothest to player");
                anim.SetInteger("Walk", 0);
                anim.SetBool("Attack", true);
          
            }

        }
            if (enemyHealth.isEnemyDead)
            {
                Destroy(this.gameObject);
                // animation
            }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Knife")
        {
            enemyHealth.DecreaseHealth(damage);
            Debug.Log("Enemy is hitting!");
        }
    }

    private void LookAtPlayer()
    {

        Vector3 direction = (transform.position - player.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }







}
