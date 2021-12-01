using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MarshmellowBoss : MonoBehaviour
{
    private NavMeshAgent agent;
    public float triggerRange;
    private bool playerInSightTriggerRange , isFighting;
    private GameObject player;
    public LayerMask playerMask;
    public GameObject[] placesForFluidAttack;
    public GameObject fluidMarshmellow;
    private bool fightSwitch;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        isFighting = false;
        fightSwitch = true;
    }

    private void Update()
    {
        playerInSightTriggerRange = Physics.CheckSphere(gameObject.transform.position, triggerRange, playerMask);

        if (playerInSightTriggerRange && !isFighting && fightSwitch)
        {            
            isFighting = true;
            fightSwitch = false;
        }
        if (isFighting)
        {
            AttackPlayer();
        }

        Vector3 lookAtPosition = player.transform.position;
        lookAtPosition.y = transform.position.y;
        transform.LookAt(lookAtPosition);
    }

    private void AttackPlayer()
    {
        Instantiate(fluidMarshmellow, placesForFluidAttack[0].transform.position, placesForFluidAttack[0].transform.rotation);
        Instantiate(fluidMarshmellow, placesForFluidAttack[1].transform.position, placesForFluidAttack[1].transform.rotation);
        isFighting = false;
        StartCoroutine(Wait(5f));
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, triggerRange);
    }

    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        fightSwitch = true;
    }
}
