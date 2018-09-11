using UnityEngine;

public class BoothScript : MonoBehaviour
{

    // Use these objects to access the booths and goodbye text when leaving the museum
    public GameObject booth;
    public float waitTime = 3;

    // Use the for audio instructions on the booth
    public AudioSource stopAudioSource, audioSource;

    // Disable booths before moving
    public void DeactivateActivateBooth()
    {

        //Debug.Log("URL to Play: " + this.gameObject.GetComponent<VideoPlayer>().url);

        if (stopAudioSource != null) { stopAudioSource.Stop(); }

        if (audioSource != null) { audioSource.Play(); }

        booth.SetActive(false);

        this.gameObject.GetComponent<MoveTheCamera>().MoveCamera();

        Invoke("ActivateBooth", waitTime);

    }

    void ActivateBooth()
    {
        booth.SetActive(true);
    }

}