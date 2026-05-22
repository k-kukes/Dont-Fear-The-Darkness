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
        Debug.Log("Exit");
        menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void Eat()
    {
        Debug.Log("Eat");
        ResourceManager.Heal(15);
        if (ResourceManager.isFood)
        {
            ResourceManager.increaseSanity(10);

        }
        else
        {

            ResourceManager.reduceSanity(10);


        }
        ResourceManager.currentObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        menu.SetActive(false);
        Time.timeScale = 1;
    }


    public void PickUp()
    {
        Debug.Log("Pickup");
        //add pick up logic
        menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

}
