using System.Collections;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public class ParanoiaEnemyMovement : MonoBehaviour
{
    Transform target;

    bool attack = false;

    public AudioClip Roar;
    Animator anim;

    AudioSource audio;

    public float updateSpeed;

    private NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = ResourceManager.player.transform;
        StartCoroutine(Follow());
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        MonsterAttack();
        anim.SetFloat("speed", agent.speed);
        if (agent.speed > 0)
        {
            audio.loop = true;
        }
        else
        {
            audio.loop = false;
        }

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            attack = true;
            audio.PlayOneShot(Roar);

            ResourceManager.TakeDamage(10);
        }
    }

    private void MonsterAttack()
    {
        if (attack == true)
        {
            agent.speed = 0;

            anim.SetTrigger("monsterAttack");
            Invoke(nameof(Disappear), 1.5f);

        }

    }

    private void Disappear()
    {
        this.gameObject.SetActive(false);
    }
    private IEnumerator Follow()
    {
        WaitForSeconds wait = new WaitForSeconds(updateSpeed);

        while (enabled)
        {
            agent.SetDestination(target.transform.position);

            yield return wait;
        }
    }

    void OnDisable()
    {
        Debug.Log("disabled");
        Invoke(nameof(Respawn), Random.Range(3, 8));
    }

    public void Respawn()
    {
        Transform spawnPoint = ResourceManager.playerCam.gameObject.transform;

        transform.position = spawnPoint.position + new Vector3(1, 0, 0) * 0.01f;
        gameObject.SetActive(true);


    }

    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        target = ResourceManager.player.transform;
        StartCoroutine(Follow());
        anim = GetComponent<Animator>();
    }



}
