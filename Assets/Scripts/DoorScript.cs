using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public float waitToMove = 1, waitToCloseDoor = 3;
    public GameObject door, crossStreet;

    // Use this to open/close the museum door
    public Animator doorAnimator;

    // Open the Door
    public void OpenTheDoor()
    {
        if (crossStreet != null)
        {
            crossStreet.GetComponent<AudioSource>().Stop();
        }

        doorAnimator.SetTrigger("Open");

        // Wait a few seconds to move the camera
        Invoke("MoveAround", waitToMove);

        // Wait a few seconds to close the door behind you
        Invoke("CloseDoor", waitToCloseDoor);

    }

    // Open the Door
    void MoveAround()
    {
        this.gameObject.GetComponent<MoveTheCamera>().MoveCamera();
    }

    // Close the Door
    void CloseDoor()
    {
        doorAnimator.SetTrigger("Close");
        if (this.gameObject.name == "CompanyName")
        {
            GetComponent<BillboardMove>().ResetBillboard();
        }
    }

}