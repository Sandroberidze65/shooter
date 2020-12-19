using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAi : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 15f;
    [SerializeField] float turnSpeed=5f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    EnemyHealth health;
    public Transform[] moveSpots;
    private int randomSpot;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
    private void EngageTarget()
    {
        FaceTarget(); 
        if (distanceToTarget > navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        else if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    public void OnDamageTaken(){
        isProvoked=true;
    }


    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
    }
    private void patrol()
    {
        Debug.Log("patrol");
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, turnSpeed);
        //GetComponent<Animator>().SetTrigger("move");
    }
    private void FaceTarget(){
        Vector3 direction=(target.position-transform.position).normalized;
        Quaternion lookRotation=Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation=Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime*turnSpeed);
    }

    private void AttackTarget()
    {
          
        GetComponent<Animator>().SetBool("attack", true);
    }
    // Start is called before the first frame update
    void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
        else
        {
            patrol();
        }

    }
}
