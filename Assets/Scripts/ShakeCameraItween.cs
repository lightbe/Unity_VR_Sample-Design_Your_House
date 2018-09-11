using UnityEngine;

public class ShakeCameraItween : MonoBehaviour
{
    public bool displayDebug;
    public float xMagnitude = 5.0f, yMagnitude = 1.0f, zMagnitude = 1.0f, duration = 4.0f, delay = 1.1f, iTweenspeed, rotateAngle, rotateTime;
    public GameObject objectToMoveTo;
    GameObject player;

    public void MoveRotateTheCamera()
    {
        if (displayDebug) { Debug.Log("MoveRotateTheCamera - Move Camera"); }
        player = Camera.main.transform.parent.gameObject;
        iTween.MoveTo(this.gameObject,
            iTween.Hash(
                "position", objectToMoveTo.transform.position,
                "time", iTweenspeed,
                "easetype", "linear"
            )
        );

        if (displayDebug) { Debug.Log("ShakeTheCamera"); }
        iTween.ShakePosition(this.gameObject,
            iTween.Hash(
                "x", xMagnitude,
                "y", yMagnitude,
                "z", zMagnitude,
                "delay", delay,
                "time", duration
             )
        );

        if (displayDebug) { Debug.Log("MoveRotateTheCamera - Rotate Camera"); }
        iTween.RotateBy(this.gameObject,
            iTween.Hash(
                "y", rotateAngle,
                "time", rotateTime,
                "easeType", "linear"
            )
        );

    }
}
