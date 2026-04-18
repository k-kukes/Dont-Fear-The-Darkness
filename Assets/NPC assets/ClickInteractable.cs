using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class ClickInteractable : MonoBehaviour
{
    public Camera playerCam;
    public GameObject OptionsMenu;
    public GameObject DialogueBox;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = playerCam.ScreenPointToRay(mousePosition);

            RaycastHit raycastHit;

            bool hit = Physics.Raycast(ray, out raycastHit);

            Debug.Log(raycastHit.transform.name);

            if (hit)
            {
                string[] dialogue = DialogueManager.setDialogue(raycastHit.transform.name);
                if (dialogue != null)
                {

                    ResourceManager.currentObject = raycastHit.transform.gameObject;
                    DialogueBox.SetActive(true);
                    UnityEngine.Cursor.lockState = CursorLockMode.None;
                    UnityEngine.Cursor.visible = true;
                    DialogueBox.GetComponent<Dialogue>().lines = dialogue;
                }
            }

        }
    }


}
