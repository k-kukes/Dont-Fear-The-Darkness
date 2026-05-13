using UnityEngine;

public class Paranoia_collision : MonoBehaviour
{
    public GameObject monster;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision");
        monster.SetActive(false);
    }
}
