using UnityEngine;
using UnityEngine.UI;

public class ProximityEffect : MonoBehaviour
{
    public float detectionRadius = 10f;      // How close zombies must be
    public Image vignetteImage;              // Assign your red UI Image here
    public AudioSource heartbeatAudio;       // Assign heartbeat audio source

    private GameObject[] zombies;

    void Update()
    {
        zombies = GameObject.FindGameObjectsWithTag("Zombie");

        float closestDist = Mathf.Infinity;

        foreach (var z in zombies)
        {
            float dist = Vector3.Distance(transform.position, z.transform.position);
            if (dist < closestDist)
                closestDist = dist;
        }

        // Determine intensity (0 = far, 1 = very close)
        float intensity = Mathf.InverseLerp(detectionRadius, 1f, closestDist);

        // Update vignette transparency
        if (vignetteImage != null)
        {
            Color c = vignetteImage.color;
            c.a = Mathf.Lerp(0, 0.5f, intensity); // up to 50% red overlay
            vignetteImage.color = c;
        }

        // Control heartbeat sound
        if (heartbeatAudio != null)
        {
            if (closestDist < detectionRadius)
            {
                if (!heartbeatAudio.isPlaying)
                    heartbeatAudio.Play();
                heartbeatAudio.pitch = Mathf.Lerp(0.8f, 1.5f, intensity);
                heartbeatAudio.volume = Mathf.Lerp(0.2f, 1f, intensity);
            }
            else
            {
                heartbeatAudio.Stop();
            }
        }
    }
}
