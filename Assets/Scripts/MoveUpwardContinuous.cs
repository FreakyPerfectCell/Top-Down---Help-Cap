using UnityEngine;

public class MoveUpwardContinuous : MonoBehaviour
{
    public float speed = 1f;  // Speed at which the sprite moves upward
    public float startY = -5f;  // Starting Y position of the sprite
    public float endY = 10f;  // Y position where the sprite stops
    public AudioSource musicSource;  // Reference to the AudioSource playing the music

    private bool hasStopped = false; // To ensure the game ends only once

    void Start()
    {
        // Set the initial position of the sprite
        transform.position = new Vector3(transform.position.x, startY, transform.position.z);

        // Ensure music starts playing when the game begins
        if (musicSource != null)
        {
            musicSource.Play();
        }
    }

    void Update()
    {
        // Move the sprite upward at a constant speed if it hasn't stopped
        if (!hasStopped)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);

            // Check if the sprite has reached the end position
            if (transform.position.y >= endY)
            {
                hasStopped = true;  // Stop movement
            }
        }

        // Check if the sprite has stopped moving and the music has finished playing
        if (hasStopped && musicSource != null && !musicSource.isPlaying)
        {
            EndGame();  // Call the method to end the game when music is done
        }
    }

    // Method to end the game
    void EndGame()
    {
        Debug.Log("Game Over! The sprite has reached the top and the music has finished.");
        
        // End the game (application quit in a build)
        Application.Quit(); // This will quit the game when built

        // If you're testing in the editor, you can simulate quitting with:
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}