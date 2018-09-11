using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MoveTheCamera : MonoBehaviour
{
    public bool displayDebug;
    public GameObject endApplication, parkingWaypoint, conesWaypoint, constructionWaypoint, selectionStop, leftHauntedHouseWaypoint, rightHauntedHouseWaypoint, billboardCastle;

    public float invokeEnd = 3;

    public GameObject[] movePoint;
    public float[] speed;
    public float[] rotateAngle;
    public float[] rotateTime;
    public float[] invokeTime;

    public AudioSource audioSource, audioSource2, audioSourcePlay;
    public VideoPlayer videoPlayer;
    public GameObject videoPanel, mediaButton;
    public Sprite playImage;
    public Camera theCamera;

    GameObject player;
    int i, saveSub;

    // Move to the first point to stop the camera
    public void MoveCamera()
    {

        if (audioSource != null) { audioSource.Stop(); }

        if (audioSource2 != null) { audioSource2.Stop(); }

        if (videoPlayer != null) { videoPlayer.Stop(); }

        if (videoPanel != null) { videoPanel.SetActive(true); }

        if (mediaButton != null) { mediaButton.GetComponent<Image>().sprite = playImage; }

        if (displayDebug) { Debug.Log("GameObject " + this.gameObject.name); }

        for (i = 0; i < movePoint.Length; i++)
        {
            saveSub = i;
            if (movePoint[i] != null)
            {
                if (i == 0)
                {
                    MoveToPoint(i, speed[i], rotateAngle[i], rotateTime[i]);

                    if (displayDebug) { Debug.Log(i + " - MoveToPoint"); }
                }
                else
                {
                    Invoke("MoveToPointDelayed", invokeTime[saveSub]);
                }
            }
        }

        if (this.gameObject.name == "WaypointCones")
        {
            // Logic for this gameobject executes after the camera starts moving
        }
        else if (this.gameObject.name == "ButtonExitRoom4" || this.gameObject.name == "ButtonExitRoom5InsideOptions" || this.gameObject.name == "ButtonExitRoom5OutsideOptions" ||
                 this.gameObject.name == "ButtonExitRoom6" || this.gameObject.name == "EnterRoomMiddle-HouseSelection")
        {
            // Play normal enter audio when entering the room. Play sorry try again audio if they exit rooms because they did not like the home design or price
            GetComponent<PlayMiddleAudio>().SelectMiddleAudio();
        }
        else
        {
            if (audioSourcePlay != null) { audioSourcePlay.Play(); }

            if (endApplication != null) { Invoke("DisplayEndApplication", invokeEnd); }
        }

    }

    void DisplayEndApplication()
    {
        endApplication.SetActive(true);
        parkingWaypoint.SetActive(true);
        parkingWaypoint.GetComponent<Waypoint>().Exit();
    }

    void MoveToPointDelayed()
    {
        if (displayDebug) { Debug.Log(saveSub + " - MoveToPointDelayed"); }

        MoveToPoint(saveSub, speed[saveSub], rotateAngle[saveSub], rotateTime[saveSub]);
    }

    void MoveToPoint(int item, float iTweenspeed, float angleY, float timerotate)
    {
        PerformBeforeActions(item, angleY, timerotate);
        if (this.gameObject.name == "WaypointCones" && item == 0)
        {
            if (displayDebug) { Debug.Log("ConstructionSiteExplosion"); }
            ConstructionSiteExplosion(item, iTweenspeed, angleY, timerotate);
        }
        else
        {
            CameraMove(item, iTweenspeed);
        }

        PerformAfterActions(item, angleY, timerotate);

    }

    void PerformBeforeActions(int item, float angleY, float timerotate)
    {

        if (displayDebug) { Debug.Log("PerformBeforeActions"); }

        if (item == 0)
        {

            if (this.gameObject.name == "Parking" || this.gameObject.name == "ButtonExitMiddle" || this.gameObject.name == "EnterRoom5-InsideOptions")
            {
                RotateCamera(angleY, timerotate);
            }
        }
    }

    void PerformAfterActions(int item, float angleY, float timerotate)
    {

        if (displayDebug) { Debug.Log("PerformAfterActions"); }

        if (item == 0)
        {
            if (this.gameObject.name == "ButtonExitLeft" || this.gameObject.name == "ButtonExitRoom4" || this.gameObject.name == "ExitBuilding" ||
                this.gameObject.name == "EnterRoom5-OutsideOptions" || this.gameObject.name == "ButtonExitRoom5InsideOptions" || this.gameObject.name == "ButtonExitRoom6" ||
                this.gameObject.name == "ClickToGoOutside")
            {
                RotateCamera(angleY, timerotate);
            }

            if (this.gameObject.name.Contains("ClickToGoOutside"))
            {
                if (displayDebug) { Debug.Log("ClickToGoOutside"); }
                GetComponent<BillboardMove>().MoveUpdateBillboard();
                GetComponent<AnimationScript>().MoveTheArm();
                GetComponent<AnimationScript>().MoveHammerCapsule();
                leftHauntedHouseWaypoint.SetActive(false);
                rightHauntedHouseWaypoint.SetActive(false);
            }
            else if (this.gameObject.name == "EnterRoomMiddle-HouseSelection" || this.gameObject.name == "ButtonExitMiddle" || this.gameObject.name == "ButtonExitRoom4" ||
                     this.gameObject.name == "ButtonExitRoom5OutsideOptions" || this.gameObject.name == "ButtonExitRoom5InsideOptions" || this.gameObject.name == "ButtonExitRoom6")
            {
                selectionStop.GetComponent<DisplayHousePhotos>().RemovePhotos();
                selectionStop.GetComponent<GetSelectedToggle>().ResetInsideOptionRoom();
                selectionStop.GetComponent<GetSelectedToggle>().ResetOutsideOptionRoom();
                selectionStop.GetComponent<GetSelectedToggle>().ResetHouseSelectionRoom();
            }
            else if (this.gameObject.name == "EnterRoom4-HousePhotos")
            {
                selectionStop.GetComponent<DisplayHousePhotos>().DisplayPhotos();
                selectionStop.GetComponent<GetSelectedToggle>().StopToggleChecking();
            }
            else if (this.gameObject.name == "EnterRoom5-OutsideOptions")
            {
                selectionStop.GetComponent<GetSelectedToggle>().ResetOutsideOptionRoom();
                selectionStop.GetComponent<GetSelectedToggle>().StartToggleCheckingOutside();
                selectionStop.GetComponent<GetSelectedToggle>().StopToggleChecking();
            }
            else if (this.gameObject.name == "EnterRoom5-InsideOptions")
            {
                selectionStop.GetComponent<GetSelectedToggle>().ResetInsideOptionRoom();
                selectionStop.GetComponent<GetSelectedToggle>().StartToggleCheckingInside();
                selectionStop.GetComponent<GetSelectedToggle>().StopToggleCheckingOutside();
            }
            else if (this.gameObject.name == "EnterRoom6-RevealHomePrice")
            {
                selectionStop.GetComponent<GetSelectedToggle>().StopToggleCheckingInside();
            }
        }
        else if (item == 1)
        {
            if (this.gameObject.name == "ButtonExitLeft" || this.gameObject.name == "ButtonExitMiddle" || this.gameObject.name == "ButtonExitRight" || this.gameObject.name == "ButtonExitRoom4" ||
                this.gameObject.name == "ButtonExitRoom5OutsideOptions" || this.gameObject.name == "EnterRoom5-InsideOptions" ||
                this.gameObject.name == "ButtonExitRoom5InsideOptions")
            {
                RotateCamera(angleY, timerotate);
            }
        }
        else if (item == 2)
        {
            if (this.gameObject.name == "ButtonExitRoom5OutsideOptions" || this.gameObject.name == "ButtonExitRoom5InsideOptions")
            {
                RotateCamera(angleY, timerotate);
            }
        }

    }

    void ConstructionSiteExplosion(int item, float iTweenspeed, float angleY, float timerotate)
    {
        if (displayDebug) { Debug.Log("Explosion"); }
        GetComponent<AnimationScript>().Explosion();

        if (displayDebug) { Debug.Log("MoveRotateTheCamera after explosion"); }

        player = Camera.main.transform.parent.gameObject;
        player.GetComponent<ShakeCameraItween>().iTweenspeed = iTweenspeed;
        player.GetComponent<ShakeCameraItween>().rotateAngle = angleY;
        player.GetComponent<ShakeCameraItween>().rotateTime = timerotate;
        player.GetComponent<ShakeCameraItween>().MoveRotateTheCamera();

        conesWaypoint.SetActive(false);
        constructionWaypoint.SetActive(true);
        constructionWaypoint.GetComponent<Waypoint>().Exit();
    }

    void RotateCamera(float angleY, float timerotate)
    {
        if (displayDebug) { Debug.Log(saveSub + " = Camera Rotated - AngleY = " + angleY); }

        player = Camera.main.transform.parent.gameObject;

        if (!Mathf.Approximately(angleY, 0f))
        {
            iTween.RotateBy(player,
                iTween.Hash(
                    "y", angleY,
                    "time", timerotate,
                    "easeType", "linear"
                )
            );
        }
    }

    void CameraMove(int item, float iTweenspeed)
    {
        if (displayDebug) { Debug.Log(item + " - CameraMove"); }

        player = Camera.main.transform.parent.gameObject;
        iTween.MoveTo(player,
            iTween.Hash(
                "position", movePoint[item].transform.position,
                "time", iTweenspeed,
                "easetype", "linear"
            )
        );
    }

    public void ActivateWaypointCones()
    {
        conesWaypoint.SetActive(true);
        conesWaypoint.GetComponent<Waypoint>().Exit();
        constructionWaypoint.SetActive(false);
    }

}