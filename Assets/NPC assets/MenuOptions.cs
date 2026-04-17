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

    public void Eat()
    {
        if (ResourceManager.isFood)
        {
            ResourceManager.increaseSanity(5);
            menu.SetActive(false);
        }
        else
        {
            ResourceManager.reduceSanity(5);
            menu.SetActive(false);
        }
        ResourceManager.currentObject.SetActive(false);

    }


    public void PickUp()
    {
        //add pick up logic
        menu.SetActive(false);
    }

}
