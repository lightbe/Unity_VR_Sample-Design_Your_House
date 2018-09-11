using UnityEngine;
using UnityEngine.Video;

public class CheckVideo : MonoBehaviour
{

    public int frameControls = 50;
    public GameObject controlsPanel;
    bool displayedControls;
    int whichFrame;

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<VideoPlayer>().frame > 0)
        {
            whichFrame = (int)this.gameObject.GetComponent<VideoPlayer>().frame;

            if (this.gameObject.GetComponent<VideoPlayer>().isPlaying)
            {
                if (!displayedControls && whichFrame >= frameControls)
                {
                    displayedControls = true;
                    controlsPanel.SetActive(true);
                    //Debug.Log("Video Controls Displayed");
                }
            }

        }

    }

}