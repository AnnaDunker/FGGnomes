using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 60f;

    Transform target;
    Transform target2;
    NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
        
    {
        target = PlayerManager.instance.playerOne.transform;
        target2 = PlayerManager.instance.playerTwo.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            agent.SetDestination(target2.position);

            if (distance <= agent.stoppingDistance)
            {
                //Attack the target
                //Face the target
                FaceTarget();
            }
        }

        /*
        if (distance > lookRadius)
        {
            return;
        }
        */
                        
    }

    void FaceTarget ()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
