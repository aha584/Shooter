using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
    public Transform playerFoot;
    public Animator anim;
    public NavMeshAgent agent;
    public float reachingRadius;
    public UnityEvent onDestinationReached;
    public UnityEvent onStartMoving;


    private bool _isMovingValue;
    public bool IsMoving
    {
        get => _isMovingValue;
        private set
        {
            if (_isMovingValue == value) return;
            _isMovingValue = value;
            OnIsMovingValueChange();
        }
    }

    private void OnIsMovingValueChange()
    {
        agent.isStopped = !_isMovingValue;
        anim.SetBool("isWalking", _isMovingValue);
        if(_isMovingValue)
        {
            onStartMoving.Invoke();
        }
        else
        {
            onDestinationReached.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.enabled) return;
        float distance = Vector3.Distance(transform.position, playerFoot.position);
        IsMoving = distance > reachingRadius;
        if(IsMoving)
        {
            agent.SetDestination(playerFoot.position);
        }
    }
    public void OnDie()
    {
        anim.SetTrigger("Die");
        agent.enabled = false;
    }
}
