using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoControlsSphere : MonoBehaviour
{
    public GameObject movieSphere, buttonExitRight, videoButtonRight;
    public VideoClip[] videoClips;
    public VideoPlayer videoPlayer;
    public Sprite playImage, pauseImage;
    int i;

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
        }
    }

    public void StartVideo()
    {
        movieSphere.SetActive(true);
        buttonExitRight.SetActive(false);
        videoButtonRight.SetActive(false);
        videoPlayer.Play();
    }

    public void StopVideo()
    {
        videoPlayer.Stop();
        movieSphere.SetActive(false);
        buttonExitRight.SetActive(true);
        videoButtonRight.SetActive(true);
    }

    public void SwitchVideo()
    {
        if (i == 0)
        {
            i = 1;
        }
        else
        {
            i = 0;
        }

        videoPlayer.clip = videoClips[i];
        videoPlayer.Play();
    }
}
