using UnityEngine;
using UnityEngine.SceneManagement;

public class goToLvl2 : MonoBehaviour
{
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
        Debug.Log("Going to Lvl 2");
        if (other.CompareTag("Player") && ChestManager.instance.ChestOpened)
        {
            SceneManager.LoadScene("Level-2");
        }
    }
}
