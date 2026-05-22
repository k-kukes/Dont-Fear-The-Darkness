using UnityEngine;
using TMPro;

public class KeypadManager : MonoBehaviour
{
    public string correctPasscode = "82016";

    public GameObject keypadCanvas;
    public TMP_InputField inputField; 
    public TMP_Text feedbackText; 

    void Start()
    {
        keypadCanvas.SetActive(false);
    }
    void Update()
    {
        if (keypadCanvas.activeSelf && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            CheckPasscode();
        }
    }


    public void TurnOnKeypad()
    {
        keypadCanvas.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        inputField.text = ""; 
        feedbackText.text = "ENTER PASSCODE:";
        feedbackText.color = Color.white;

        inputField.ActivateInputField(); 
    }

    public void CheckPasscode()
    {
        if (inputField.text == correctPasscode)
        {
            feedbackText.text = "ACCESS GRANTED";
            feedbackText.color = Color.green;
            Debug.Log("PASSCODE CORRECT! DOOR IS OPENING!");

            Invoke("CloseKeypad", 2f); 
        }
        else
        {
            feedbackText.text = "ERROR: INCORRECT";
            feedbackText.color = Color.red;
            inputField.text = ""; 
            inputField.ActivateInputField(); 
        }
    }

    public void CloseKeypad()
    {
        keypadCanvas.SetActive(false);

        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}