using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    bool hasKey = false;
    public string nextLevelName;
    public AudioClip jumpSound; // 👈 assign in Inspector
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 👇 Simple jump input (example)
        if (Input.GetButtonDown("Jump"))
        {
            if (jumpSound != null)
            {
                audioSource.PlayOneShot(jumpSound);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            hasKey = true;
            Destroy(other.gameObject);
            Debug.Log("Key collected!");
        }
        else if (other.CompareTag("Door"))
        {
            if (hasKey)
            {
                Debug.Log("Loading next level...");
                SceneManager.LoadScene(nextLevelName);
            }
            else
            {
                Debug.Log("Need key to open door!");
            }
        }
        else if (other.CompareTag("Zombie"))
        {
            Debug.Log("You were caught by a zombie!");
            SceneManager.LoadScene("Lose");
        }
    }
}
