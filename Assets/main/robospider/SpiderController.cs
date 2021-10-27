using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderController : MonoBehaviour
{
    public GameObject[] secrets;
    private GameObject searchObject;
    private NavMeshAgent agent;

    private void Start()
    {
        secrets = GameObject.FindGameObjectsWithTag("secret");
        agent = GetComponent<NavMeshAgent>();

        if (secrets != null)
        {
            int index = 0;
            float minDistance = Vector3.Distance(secrets[0].transform.position , gameObject.transform.position);
            for (int i = 0; i < secrets.Length; i++)
            {
                if (Vector3.Distance(secrets[i].transform.position, gameObject.transform.position) < minDistance)
                {
                    minDistance = Vector3.Distance(secrets[i].transform.position, gameObject.transform.position);
                    index = i;
                }          
            }
            searchObject = secrets[index];
        }
        else
        {
            Debug.Log("secret places weren't detected");
        }

    }

    private void Update()
    {
        ChasePlayer();
    }

    private void ChasePlayer()
    {
        agent.SetDestination(searchObject.transform.position);



    }
}
