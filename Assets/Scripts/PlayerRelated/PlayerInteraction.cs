using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactDistance = 4f;        
    public LayerMask interactLayer;            

    private Camera playerCamera;

    void Start()
    {
        playerCamera = GetComponent<Camera>();          
        if (playerCamera == null)
            playerCamera = Camera.main;                  
    }

    void Update()
    {
        // Right click

        if (Input.GetKeyDown(KeyCode.Mouse1))   
        {
           
            Debug.DrawRay(playerCamera.transform.position,
                         playerCamera.transform.forward * interactDistance,
                         Color.red, 2f);

            Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                Debug.Log("Raycast hit: " + hit.collider.gameObject.name);

                BatteryPickup battery = hit.collider.GetComponent<BatteryPickup>();
                if (battery != null)
                {
                    battery.Interact();
                    Debug.Log("Battery picked up!");
                }
            }
            else
            {
                Debug.Log("Raycast hit NOTHING - move closer or look directly at battery");
            }
        }
    }
}