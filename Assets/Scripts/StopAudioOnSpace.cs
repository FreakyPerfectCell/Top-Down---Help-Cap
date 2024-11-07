using UnityEngine;
using UnityEngine.SceneManagement;

public class StopAudioOnSpace : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip sound1;  // First sound (skippable)
    public AudioClip sound2;  // Second sound (non-skippable)
    private bool hasPlayedFirstSound = false;

    void Start()
    {
        // Attempt to get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Check if AudioSource is attached to the GameObject
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on this GameObject.");
        }
        else
        {
            // Start by playing the first sound
            audioSource.clip = sound1;
            audioSource.Play();
        }
    }

    void Update()
    {
        // Check if the Space key is pressed and the first sound is still playing
        if (Input.GetKeyDown(KeyCode.Space) && !hasPlayedFirstSound)
        {
            // Stop the first sound if it's playing and move to the second sound
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }

            // Play the second sound
            audioSource.clip = sound2;
            audioSource.Play();
            hasPlayedFirstSound = true; // Ensure we don't skip the second sound
        }

        // If the first sound finishes playing and hasn't been skipped, move to the second sound
        if (!audioSource.isPlaying && !hasPlayedFirstSound)
        {
            // Automatically transition to the second sound
            audioSource.clip = sound2;
            audioSource.Play();
            hasPlayedFirstSound = true; // Mark the transition complete
        }

        // Once the second sound is done playing, change the scene to "Stage1"
        if (!audioSource.isPlaying && hasPlayedFirstSound && audioSource.clip == sound2)
        {
            // Load the "Stage1" scene after the second sound finishes
            SceneManager.LoadScene("Stage1");
        }
    }
}