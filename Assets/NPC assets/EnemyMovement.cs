using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;

    public float updateSpeed;

    private NavMeshAgent agent;

    public Camera playerCam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(Follow());

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Vector3.Dot(transform.position.normalized, target.transform.forward.normalized));

        if (Vector3.Dot(transform.forward.normalized, target.transform.forward.normalized) < -0.5)
        {
            agent.speed = 0;
        }
        else
        {
            agent.speed = 3;
        }
    }

    private IEnumerator Follow()
    {
        WaitForSeconds wait = new WaitForSeconds(updateSpeed);

        while (enabled)
        {
            agent.SetDestination(target.transform.position);
            Debug.Log(agent.destination);
            yield return wait;
        }
    }
}
