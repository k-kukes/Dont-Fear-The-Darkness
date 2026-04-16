using UnityEngine;

public class MenuOptions : MonoBehaviour
{
    public GameObject menu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void exitMenu()
    {
        menu.SetActive(false);
    }

    public void loseSanity()
    {
        ResourceManager.reduceSanity(5);
        Debug.Log(ResourceManager.Sanity);
    }

}
