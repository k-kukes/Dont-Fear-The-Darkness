using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using StarterAssets;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> dialogueQueue = new Queue<string>();

    private string currentLine;
    private bool isTyping = false;

    [Header("UI")]
    public TMP_Text dialogueText;
    public GameObject nextButton;
    public GameObject choicePanel;
    public FirstPersonController playerController;
    public StarterAssetsInputs playerInputs;
    private bool isDialogueActive = false;
    private string currentTrigger = "";

    // ================= START =================
    public void StartDialogue(List<string> lines, string trigger = "")
    {

        isDialogueActive = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        dialogueQueue.Clear();

        foreach (string line in lines)
        {
            dialogueQueue.Enqueue(line);
        }

        if (playerController != null)
        {
            playerController.enabled = false;
        }

        if (playerInputs != null)
        {
            playerInputs.enabled = false;
        }

        currentTrigger = trigger;
        choicePanel.SetActive(false);

        DisplayNextLine();
    }

    void Update()
    {
        if (!isDialogueActive)
        {
            return;
        } 

        if (Input.GetMouseButtonDown(0)) // LEFT CLICK
        {
            DisplayNextLine();
        }
    }

    // ================= NEXT =================
    public void DisplayNextLine()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueText.text = currentLine;
            isTyping = false;
            return;
        }

        if (dialogueQueue.Count == 0)
        {
            OnDialogueEnd();
            return;
        }

        currentLine = dialogueQueue.Dequeue();
        StartCoroutine(TypeLine(currentLine));
    }

    // ================= TYPE EFFECT =================
    IEnumerator TypeLine(string line)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char c in line)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(0.02f);
        }

        isTyping = false;
    }

    // ================= END =================
    void OnDialogueEnd()
    {
        isDialogueActive = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        nextButton.SetActive(false);

        if (currentTrigger == "showChoices")
        {
            choicePanel.SetActive(true);
            return;
        }

        if (playerController != null)
        {
            playerController.enabled = true;
        }

        if (playerInputs != null)
        {
            playerInputs.enabled = true;
        }

        // Hide the panel
        dialogueText.transform.parent.gameObject.SetActive(false);
    }

    // ================= BUTTON EVENTS =================
    public void ChooseYes()
    {
        choicePanel.SetActive(false);
        nextButton.SetActive(true);

        List<string> lines = new List<string>()
        {
            "You accepted...",
            "The nightmare begins."
        };

        StartDialogue(lines);
    }

    public void ChooseNo()
    {
        choicePanel.SetActive(false);
        nextButton.SetActive(true);

        List<string> lines = new List<string>()
        {
            "You refused...",
            "But something feels wrong..."
        };

        StartDialogue(lines);
    }
}