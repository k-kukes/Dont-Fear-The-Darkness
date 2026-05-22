using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Security.Cryptography.X509Certificates;

public class SkillCheckController : MonoBehaviour
{
    public GameObject skillCheckUI;
    public RectTransform needle;
    public RectTransform targetZone;
    public TextMeshProUGUI instructionText;

    public GameObject note;

    public float rotationSpeed = 150f;
    public float successThreshold = 27f;
    public int maxAttempts = 3;

    private bool isActive = false;
    private int currentAttempts;

    private ChestInteract currentChest;

    void Start()
    {
        skillCheckUI.SetActive(false);
    }

    void Update()
    {

        if (!isActive) return;

        needle.Rotate(0, 0, -rotationSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.V))
        {
            CheckSuccess();
        }
    }

    public void StartSkillCheck(ChestInteract chest)
    {
        currentChest = chest;
        isActive = true;
        currentAttempts = maxAttempts;
        skillCheckUI.SetActive(true);

        instructionText.text = "Press V to align the needle!";

        targetZone.localEulerAngles = new Vector3(0, 0, Random.Range(0f, 360f));
        needle.GetComponent<Image>().color = Color.white;
    }

    void CheckSuccess()
    {
        float needleAngle = needle.localEulerAngles.z;
        float targetAngle = targetZone.localEulerAngles.z - 27f;
        float difference = Mathf.Abs(Mathf.DeltaAngle(needleAngle, targetAngle));
        Image needleImg = needle.GetComponent<Image>();

        if (difference <= successThreshold)
        {
            isActive = false;
            Debug.Log("Skill Check Success!");
            instructionText.text = "SUCCESS!";
            needleImg.color = Color.green;
            note.SetActive(true);
            if (currentChest != null) currentChest.OpenChest();
            ChestManager.instance.ChestOpened = true;
            Invoke("CloseSkillCheck", 1f);
        }
        else
        {
            currentAttempts--;

            if (currentAttempts <= 0)
            {
                isActive = false;
                Debug.Log("Out of attempts! Failed!");
                instructionText.text = "FAILED!";
                needleImg.color = Color.red;
                Invoke("CloseSkillCheck", 1f);
            }
            else
            {
                Debug.Log("Missed! Attempts left: " + currentAttempts);
                instructionText.text = "Missed! Attempts left: " + currentAttempts;
                needleImg.color = Color.red;
                Invoke("ResetNeedleColor", 0.2f);
            }
        }
    }

    void ResetNeedleColor()
    {
        if (isActive)
        {
            needle.GetComponent<Image>().color = Color.white;
        }
    }

    void CloseSkillCheck()
    {
        skillCheckUI.SetActive(false);
    }
}