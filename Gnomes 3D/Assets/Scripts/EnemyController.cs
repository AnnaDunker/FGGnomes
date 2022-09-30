using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 60f;

    List<Transform> targets = new List<Transform>();
    NavMeshAgent agent;
    Transform nearestTarget = null;

    // Start is called before the first frame update
    void Start()   
    {
        agent = GetComponent<NavMeshAgent>();
        targets.Add(PlayerManager.instance.playerOne.transform);
        targets.Add(PlayerManager.instance.playerTwo.transform);

    }

    // Update is called once per frame
    void Update()
    {
        nearestTarget = null;
        foreach(Transform t in targets) // Go through targets
        {
            float distanceToThisTarget = Vector3.Distance(transform.position, t.position); // Calculate distance to this target
            if (nearestTarget == null || distanceToThisTarget < Vector3.Distance(transform.position, nearestTarget.position)) // If this target is closer than the previous nearest target
            {
                nearestTarget = t; // Set new nearest target
            }

        }

        //Debug.Log("Nearest target is " + nearestTarget.name + " (distance: " + Vector3.Distance(transform.position, nearestTarget.position) + ")");

        float distance = Vector3.Distance(nearestTarget.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(nearestTarget.position);
            

            if (distance <= agent.stoppingDistance)
            {
                //Attack the target
                //Face the target
                FaceTarget();
            }
        }

                              
    }

    void FaceTarget ()
    {
        Vector3 direction = (nearestTarget.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
