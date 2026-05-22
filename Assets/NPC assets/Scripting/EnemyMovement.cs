using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    Transform target;

    bool attack = false;
    public RawImage scareImage;

    public AudioClip Roar;
    Animator anim;

    AudioSource audio;

    public float updateSpeed;

    private NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scareImage.enabled = false;
        agent = GetComponent<NavMeshAgent>();
        target = ResourceManager.player.transform;
        StartCoroutine(Follow());
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        this.gameObject.SetActive(false);
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

            ResourceManager.TakeDamage(10);
        }
    }

    private void MonsterAttack()
    {
        if (attack == true)
        {
            agent.speed = 0;
            audio.PlayOneShot(Roar);
            anim.SetTrigger("monsterAttack");
            attack = false;
            // the scare effect screen
            scareImage.enabled = true;
        }
        else
        {
            agent.speed = 3.5f;
        }

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
        ResourceManager.Monster = this.gameObject;

    }

    public void Respawn()
    {
        Transform spawnPoint = ResourceManager.playerCam.gameObject.transform;

        transform.position = spawnPoint.position + new Vector3(1, 0, 0) * 0.01f;
        Debug.Log(transform.position);
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
