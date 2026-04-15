using System;
using UnityEngine;
using System.Collections.Generic;
public class ClickInteractable : MonoBehaviour
{
    public Camera playerCam;

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


            if (hit)
            {
                if (raycastHit.transform.name.Equals("Body_Parts"))
                {

                    DialogueBox.SetActive(true);
                    DialogueBox.GetComponent<Dialogue>().lines.Clear();
                    DialogueBox.GetComponent<Dialogue>().lines.Add("??????");
                    DialogueBox.GetComponent<Dialogue>().lines.Add("is That HUMAN");
                }
                Debug.Log("HIT");
            }
            else
            {
                Debug.Log("miss");
            }
        }
    }


}
