using UnityEngine;
using UnityEngine.AI;

public class MonsterAI_Level3 : MonoBehaviour
{
    public Transform player;
    public float chaseRange = 100f;
    public float chaseSpeed = 4.5f;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (agent != null)
        {
            agent.speed = chaseSpeed;
            agent.isStopped = false;
        }
    }

    void Update()
    {
        if (player == null || agent == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= chaseRange)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
        else
        {
            agent.isStopped = true;
            agent.ResetPath();
        }
    }
}