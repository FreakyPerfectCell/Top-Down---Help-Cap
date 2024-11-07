using UnityEngine;

public class ActivateTextOnSceneLoad : MonoBehaviour
{
    public GameObject textObject; // Reference to the Text UI element

    void Start()
    {
        // Ensure the Text is activated when the scene is loaded
        if (textObject != null)
        {
            textObject.SetActive(true); // Activate the Text GameObject
        }
    }
}