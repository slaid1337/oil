using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MarshmellowController : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject[] houses;
    public float fearRange;
    private bool playerInSightFearRange;
    public LayerMask playerMask;
    private bool isRunning;
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public LayerMask whatIsGround;


    private void Awake()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        houses = GameObject.FindGameObjectsWithTag("house");
        isRunning = false;
    }

    private void Update()
    {
        playerInSightFearRange = Physics.CheckSphere(gameObject.transform.position, fearRange,playerMask);


        if (playerInSightFearRange && !isRunning)
        {
            RunAwayFromPlayer();
        }
        else if (!isRunning)
        {
            Patroling();
        }
    }


    void RunAwayFromPlayer()
    {
        float longestDistance = 0f;
        Vector3 runPosition = Vector3.zero;
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        
        foreach (GameObject point in houses)
        {

            Vector3 position = point.transform.position;
            Vector3 directionToHouse = (gameObject.transform.position - point.transform.position).normalized;
            Vector3 directionToPlayer = (gameObject.transform.position - playerPosition).normalized;
            
            float currentCheckDistance = Vector3.Distance(gameObject.transform.position, point.transform.position);
            
            

            if (currentCheckDistance > longestDistance && Vector3.Angle(directionToHouse, directionToPlayer) > 90f)
            {
                
                
                longestDistance = currentCheckDistance;
                runPosition = point.transform.position;
                
            }
        }

        isRunning = true;
        agent.SetDestination(runPosition);
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void OnDrawGizmosSelected()
    {        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fearRange);
    }
}
