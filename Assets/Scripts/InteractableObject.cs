using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GameObject[] interactableObjects;
    private Transform player;
    private float detectionRange = 5f;
    // Start is called before the first frame update
    void Start()
    {
        interactableObjects = GameObject.FindGameObjectsWithTag("Interactable");

        if (player == null)
        {
            // please.....
            player = Camera.main.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        foreach (GameObject obj in interactableObjects)
        {
            if (obj == null) continue;

            float distance = Vector3.Distance(player.position, obj.transform.position);
            if (distance <= detectionRange)
            {
                SetHighlight(obj, true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // TODO: Add interaction logic
                }
            } else {
                SetHighlight(obj, false);
            }
        }
    }

    private void SetHighlight(GameObject target, bool state)
    {
       Renderer renderer = target.GetComponent<Renderer>();
       if (renderer != null)
       {
        renderer.material.color = state ? Color.yellow : Color.white;
       }
    }
}
