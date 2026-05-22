using UnityEngine;

public class ChestInteract : MonoBehaviour
{
    public SkillCheckController skillCheckManager;
    public Animator chestAnimator;

    private bool isPlayerNear = false;
    private bool isOpen = false;

    void Update()
    {
        // Debug.Log(isPlayerNear);

        if (isPlayerNear && Input.GetKeyDown(KeyCode.T) && !isOpen)
        {
            Debug.Log("open");
            if (ChestManager.instance.hasChestKey)
            {
                skillCheckManager.StartSkillCheck(this);
            }
            else
            {
                Debug.Log("Locked! Need the key from the forest.");
            }
        }
    }

    public void OpenChest()
    {
        if (isOpen) return;
        isOpen = true;

        Debug.Log("Skill Check Won");
        ChestManager.instance.hasChestKey = false;
        if (chestAnimator != null)
        {
            chestAnimator.SetTrigger("Open");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) isPlayerNear = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) isPlayerNear = false;
    }
}