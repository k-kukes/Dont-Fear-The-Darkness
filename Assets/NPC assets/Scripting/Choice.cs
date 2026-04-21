using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
    public Text question;

    public Button EatBtn;

    public Button PickUpBtn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public  void PickUpMenu()
    {

        EatBtn.interactable = false;
        PickUpBtn.interactable = true;

    }

    public void EatMenu()
    {

        EatBtn.interactable = true;
        PickUpBtn.interactable = false;

    }
}
