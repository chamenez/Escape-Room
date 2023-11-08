using UnityEngine;

public class PuzzleInteraction : MonoBehaviour
{
    public ST_PuzzleDisplay puzzle;  // Reference to the puzzle script.
    public float interactionDistance = 2.0f;  // Distance at which the player can interact with the puzzle.

    private bool canInteract = false;

    void Update()
    {
        // Check for player input (e.g., pressing "E") to interact with the puzzle.
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            // Call a method to solve the puzzle. You may want to implement this method in your "ST_PuzzleDisplay" script.
            puzzle.CheckForComplete();
        }
    }

    // Detect if the player is within interaction distance of the puzzle.
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    // Detect when the player exits the interaction distance.
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
        }
    }
}
