using UnityEngine;

public class SocketManager : MonoBehaviour
{
    public GameObject canvas; // Assign your Canvas GameObject in the Inspector
    private int itemsInSockets = 0;

    private void Start()
    {
        // Ensure the Canvas is initially hidden
        if (canvas != null)
        {
            canvas.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is an item
        if (other.CompareTag("Item"))
        {
            itemsInSockets++;
            Debug.Log("Item entered. Total items in sockets: " + itemsInSockets);
            CheckIfBothSocketsFilled();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the object that exited the trigger is an item
        if (other.CompareTag("Item"))
        {
            itemsInSockets--;
            Debug.Log("Item exited. Total items in sockets: " + itemsInSockets);
        }
    }

    private void CheckIfBothSocketsFilled()
    {
        // If two items are in the sockets, show the Canvas
        if (itemsInSockets >= 2)
        {
            canvas.SetActive(true);
            Debug.Log("Both sockets filled. Showing canvas.");
        }
    }
}
