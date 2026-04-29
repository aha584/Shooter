using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
    public Transform playerFoot;
    public Animator anim;
    public NavMeshAgent agent;
    public float reachingRadius;

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, playerFoot.position);
        if(distance > reachingRadius)
        {
            agent.isStopped = false;
            agent.SetDestination(playerFoot.position);
            anim.SetBool("isWalking", true);
        }
        else
        {
            agent.isStopped = true;
            anim.SetBool("isWalking", false);
        }
    }
}
