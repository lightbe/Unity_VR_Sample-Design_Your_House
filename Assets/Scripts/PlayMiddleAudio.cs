using UnityEngine;

public class PlayMiddleAudio : MonoBehaviour
{
    public GameObject selectionStop;
    public AudioClip[] audioClips;

    public void SelectMiddleAudio()
    {
        if (this.gameObject.name.Contains("ButtonExit"))
        {
            selectionStop.GetComponent<AudioSource>().clip = audioClips[1];
        }
        else
        {
            selectionStop.GetComponent<AudioSource>().clip = audioClips[0];
        }
        selectionStop.GetComponent<AudioSource>().Play();
    }
}
