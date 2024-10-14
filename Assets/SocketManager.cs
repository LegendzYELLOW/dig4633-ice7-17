using UnityEngine;
using UnityEngine.InputSystem;

public class SocketManager : MonoBehaviour
{
    public GameObject canvas; // Assign your Canvas GameObject in the Inspector
    private int itemsInSockets = 0;

    private PlayerControls controls; // Reference to the Input Action asset

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.Interact.performed += ctx => TryPlaceItem();
    }

    private void Start()
    {
        if (canvas != null)
        {
            canvas.SetActive(false); // Start with the canvas hidden
        }
    }

    private void OnEnable()
    {
        controls.Enable(); // Enable input actions
    }

    private void OnDisable()
    {
        controls.Disable(); // Disable input actions
    }

    private void TryPlaceItem()
    {
        // Logic to check if the player is trying to place an item
        // This would typically be called when an item is close to a socket
        Debug.Log("Trying to place item in socket");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item")) // Check if the object is tagged "Item"
        {
            itemsInSockets++;
            Debug.Log("Item entered. Total items in sockets: " + itemsInSockets);
            CheckIfBothSocketsFilled();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item")) // Check if the object is tagged "Item"
        {
            itemsInSockets--;
            Debug.Log("Item exited. Total items in sockets: " + itemsInSockets);
        }
    }

    private void CheckIfBothSocketsFilled()
    {
        if (itemsInSockets >= 2) // Check if there are at least 2 items
        {
            canvas.SetActive(true); // Show the canvas
            Debug.Log("Both sockets filled. Showing canvas.");
        }
    }
}
