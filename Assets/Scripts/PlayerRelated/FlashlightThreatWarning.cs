using UnityEngine;

public class FlashlightThreatWarning : MonoBehaviour
{
    public FlashlightController flashlight;
    public AudioClip growlClip;           
    public float stillTimeRequired = 4f;

    private AudioSource audioSource;      // will auto-find
    private Vector3 lastPosition;
    private float stillTimer = 0f;
    private bool hasPlayedGrowl = false;

    void Start()
    {
        // Automatically find the Audio Source on the same Player object
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError( "No AudioSource found on Player! Add one.");
        }
        else
        {
            Debug.Log("AudioSource found automatically");
        }

        lastPosition = transform.position;
    }

    void Update()
    {
        if (flashlight == null) return;

        float movedDistance = Vector3.Distance(transform.position, lastPosition);

        if (flashlight.IsFlashlightOn() && movedDistance < 0.02f)
        {
            stillTimer += Time.deltaTime;

            if (stillTimer >= stillTimeRequired && !hasPlayedGrowl)
            {
                if (audioSource != null && growlClip != null)
                {
                    audioSource.PlayOneShot(growlClip);
                    Debug.Log("Monster growl played!");
                }

                hasPlayedGrowl = true;
            }
        }
        else
        {
            stillTimer = 0f;
        }

        lastPosition = transform.position;
    }
}