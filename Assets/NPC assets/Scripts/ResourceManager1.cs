using Mono.Cecil;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager1 : MonoBehaviour
{

    public Slider healthBar;
    public Slider sanityBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthBar.maxValue = 100;
        healthBar.value = 100;
        sanityBar.maxValue = 100;
        sanityBar.value = 100;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        sanityBar.value = ResourceManager.Sanity;
        healthBar.value = ResourceManager.Health;
    }

}
