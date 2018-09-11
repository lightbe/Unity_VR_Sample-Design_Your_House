using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PausePlayButtons : MonoBehaviour
{

    public AudioSource audioSource;

    public VideoPlayer videoPlayer;
    public GameObject videoPanel;

    // Use these objects to for media buttons
    public Sprite playImage, pauseImage;

    private void Start()
    {
        if (videoPlayer != null) { videoPlayer.loopPointReached += EndOfVideo; }
    }

    public void PlayPauseAudio()
    {

        if (audioSource.isPlaying)
        {
            audioSource.Pause();
            GetComponent<Image>().sprite = playImage;
        }
        else
        {
            audioSource.Play();
            GetComponent<Image>().sprite = pauseImage;

            StartCoroutine(EndOfAudio());
        }

    }

    public void PlayPauseVideo()
    {

        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
            GetComponent<Image>().sprite = playImage;
        }
        else
        {
            videoPlayer.Play();
            GetComponent<Image>().sprite = pauseImage;
            if (videoPanel != null) { videoPanel.SetActive(false); }
        }

    }

    IEnumerator EndOfAudio()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        GetComponent<Image>().sprite = playImage;
    }


    void EndOfVideo(VideoPlayer vp)
    {
        GetComponent<Image>().sprite = playImage;
        if (videoPanel != null) { videoPanel.SetActive(true); }
    }
}