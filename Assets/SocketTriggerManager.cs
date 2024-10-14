using UnityEngine;

public class SocketTriggerManager : MonoBehaviour
{
    public GameObject canvas; // Assign your Canvas GameObject in the Inspector
    private int triggerCount = 0;

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
        // Check if the object that entered the trigger is the socket
        if (other.CompareTag("Socket")) // Make sure to tag your socket GameObjects as "Socket"
        {
            triggerCount++;
            CheckIfBothTriggered();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Socket"))
        {
            triggerCount--;
        }
    }

    private void CheckIfBothTriggered()
    {
        // If both sockets are triggered, show the Canvas
        if (triggerCount >= 2)
        {
            canvas.SetActive(true);
        }
    }
}
