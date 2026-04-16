using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class ClickInteractable : MonoBehaviour
{
    public Camera playerCam;

    public GameObject DialogueBox;
    
    public GameObject ChoiceMenu;

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
                if (raycastHit.transform.name.Equals("rust_key"))
                {

                    DialogueBox.SetActive(true);
                    DialogueBox.GetComponent<Dialogue>().lines.Clear();
                    DialogueBox.GetComponent<Dialogue>().lines.Add("Hmmmmm");
                    DialogueBox.GetComponent<Dialogue>().lines.Add("This might be useful");
                }

                if (raycastHit.transform.name.Equals("food"))
                {

                    DialogueBox.SetActive(true);
                    DialogueBox.GetComponent<Dialogue>().lines.Clear();
                    DialogueBox.GetComponent<Dialogue>().lines.Add("Finaly");
                    DialogueBox.GetComponent<Dialogue>().lines.Add("Something I can Eat");
                }
                Debug.Log("HIT");
                Debug.Log(raycastHit.transform.name);
            }
            else
            {
                Debug.Log("miss");
            }
        }
    }


}
