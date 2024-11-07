using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Add this for SceneManager

public class LevelMove : MonoBehaviour
{
    public int sceneBuildIndex;  // Corrected declaration

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Entered");
        if (other.CompareTag("Player"))  // Use CompareTag for better performance
        {
            print("Switching Scene to " + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}