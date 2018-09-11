using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private enum State
    {
        Idle,
        Focused,
        Clicked,
        Approaching,
        Moving,
        Collect,
        Collected,
        Occupied,
        Open,
        Hidden
    }

    [SerializeField]
    private State _state = State.Idle;
    private Color _color_origional = new Color(0.0f, 1.0f, 0.0f, 0.5f);
    private Color _color = Color.white;
    private float _scale = 1.0f;
    private float _animated_lerp = 1.0f;
    private AudioSource _audio_source = null;
    private Material _material = null;

    public bool displayDebug;
    public AudioSource crossStreetAudio, exitAudio;

    public GameObject endApplication, parkingWaypoint, leftHauntedHouseWaypoint, rightHauntedHouseWaypoint, dogHead;
    public float myFieldOfView = 90;

    [Header("Material")]
    public Material material = null;
    public Color color_hilight = new Color(0.8f, 0.8f, 1.0f, 0.125f);

    [Header("State Blend Speeds")]
    public float lerp_idle = 0.5f;
    public float lerp_focus = 0.5f;
    public float lerp_hide = 0.5f;
    public float lerp_clicked = 0.5f;

    [Header("State Animation Scales")]
    public float scale_clicked_max = 3.0f;
    public float scale_animation = 3.0f;
    public float scale_idle_min = 1.0f;
    public float scale_idle_max = 1.25f;
    public float scale_focus_min = 1.25f;
    public float scale_focus_max = 2.0f;

    [Header("Sounds")]
    public AudioClip clip_click = null;

    [Header("Hide Distance")]
    public float threshold = 0.125f;

    [Header("Camera Heights")]
    public float cameraHeight = 3.0f;
    public float cameraHeightDoor = 2.0f;

    void Awake()
    {
        _material = Instantiate(material);
        _color_origional = _material.color;
        _color = _color_origional;
        _audio_source = gameObject.GetComponent<AudioSource>();
        _audio_source.clip = clip_click;
        _audio_source.playOnAwake = false;
    }


    void Update()
    {
        bool occupied = Camera.main.transform.parent.transform.position == gameObject.transform.position;

        switch (_state)
        {
            case State.Idle:
                Idle();

                _state = occupied ? State.Occupied : _state;
                break;

            case State.Focused:
                Focus();
                break;

            case State.Clicked:
                Clicked();

                bool scaled = _scale >= scale_clicked_max * .95f;
                _state = scaled ? State.Approaching : _state;
                break;

            case State.Approaching:
                Hide();

                _state = occupied ? State.Occupied : _state;
                break;
            case State.Occupied:
                Hide();

                _state = !occupied ? State.Idle : _state;
                break;

            case State.Hidden:
                Hide();
                break;

            default:
                break;
        }

        gameObject.GetComponentInChildren<MeshRenderer>().material.color = _color;
        gameObject.transform.localScale = Vector3.one * _scale;

        _animated_lerp = Mathf.Abs(Mathf.Cos(Time.time * scale_animation));
    }


    public void Enter()
    {
        _state = _state == State.Idle ? State.Focused : _state;
        //Invoke ("Click", 1);
    }


    public void Exit()
    {
        _state = State.Idle;
    }


    public void Click()
    {
        _state = _state == State.Focused ? State.Clicked : _state;

        _audio_source.Play();

        if (crossStreetAudio != null)
        {
            crossStreetAudio.Stop();
        }

        if (exitAudio != null)
        {
            exitAudio.Stop();
        }

        if (endApplication != null) { endApplication.SetActive(false); }

        if (parkingWaypoint != null) { parkingWaypoint.SetActive(false); }

        // Waypoints where you first see the contruction vehicle or when you don't
        if (this.gameObject.name.Contains("Arm"))
        {
            GetComponent<AnimationScript>().MoveTheArm(); // Script will start/stop the moving of the arm
        }

        // Waypoints where you first see the contruction vehicle or when you don't
        if (this.gameObject.name.Contains("Capsule"))
        {
            if (displayDebug) { Debug.Log(this.gameObject.name + " - Capsule Animation"); }
            GetComponent<AnimationScript>().MoveHammerCapsule(); // Script will start/stop the moving of the hammer capsule on the piling machine
        }

        // Waypoint where you are about to enter the constuction area - Clicking on another gameobject will start the bomb
        if (this.gameObject.name == "WaypointConstructionSiteHalfway")
        {
            GetComponent<AnimationScript>().DisableBomb(); // Script will disable group of particle systems for explosion
        }

        // Waypoints logic to control the house floating in water
        if (this.gameObject.name.Contains("HouseUnderWaterStart"))
        {
            GetComponent<AnimationScript>().StartHouseFloating(); // House should be floating
        }
        else if (this.gameObject.name.Contains("HouseUnderWaterStop"))
        {
            GetComponent<AnimationScript>().StopHouseFloating(); // House should be floating
        }

        // Stop move fox head animation
        if (this.gameObject.name.Contains("Dog"))
        {
            if (displayDebug) { Debug.Log(this.gameObject.name + " - Dog Animation"); }
            dogHead.GetComponent<AnimationScript>().MoveFoxHead();
        }

        // Waypoint to tilt haunted house
        if (this.gameObject.name.Contains("WaypointHauntedHouse"))
        {
            if (displayDebug) { Debug.Log("GameObject name: " + this.gameObject.name + " - MoveTheHouse() should be called"); }
            if (this.gameObject.name == "WaypointHauntedHouse")
            {
                GetComponent<BillboardMove>().MoveBillboardBackward();
                Camera.main.fieldOfView = myFieldOfView;
                GetComponent<AnimationScript>().StartHauntedHouse();
                leftHauntedHouseWaypoint.SetActive(true);
                rightHauntedHouseWaypoint.SetActive(true);
                leftHauntedHouseWaypoint.GetComponent<Waypoint>().Exit();
                rightHauntedHouseWaypoint.GetComponent<Waypoint>().Exit();
            }
            else
            {
                Camera.main.fieldOfView = 60;
                GetComponent<AnimationScript>().StopHauntedHouse();
            }
        }

        if (this.gameObject.name == "WaypointFrontDoor")
        {
            Camera.main.transform.parent.transform.position = new Vector3(gameObject.transform.position.x, cameraHeight + cameraHeightDoor, gameObject.transform.position.z);
        }
        else
        {
            Camera.main.transform.parent.transform.position = new Vector3(gameObject.transform.position.x, cameraHeight, gameObject.transform.position.z);
        }

        // After the camera moves to WaypointCones move the camera again to the spot near the mound of dirt where the explosion happens
        if (this.gameObject.name == "WaypointCones")
        {
            this.gameObject.GetComponent<MoveTheCamera>().MoveCamera();
        }
        else if (this.gameObject.name == "WaypointConstructionSiteHalfway") //Acivate WaypointCones gameobject - no camera movement
        {
            this.gameObject.GetComponent<MoveTheCamera>().ActivateWaypointCones();
        }

    }


    private void Idle()
    {
        float scale = Mathf.Lerp(scale_idle_min, scale_idle_max, _animated_lerp);
        Color color = Color.Lerp(_color_origional, color_hilight, _animated_lerp);

        _scale = Mathf.Lerp(_scale, scale, lerp_idle);
        _color = Color.Lerp(_color, color, lerp_idle);
    }


    public void Focus()
    {
        float scale = Mathf.Lerp(scale_focus_min, scale_focus_max, _animated_lerp);
        Color color = Color.Lerp(_color_origional, color_hilight, _animated_lerp);

        _scale = Mathf.Lerp(_scale, scale, lerp_focus);
        _color = Color.Lerp(_color, color, lerp_focus);
    }


    public void Clicked()
    {
        _scale = Mathf.Lerp(_scale, scale_clicked_max, lerp_clicked);
        _color = Color.Lerp(_color, color_hilight, lerp_clicked);
    }


    public void Hide()
    {
        _scale = Mathf.Lerp(_scale, 0.0f, lerp_hide);
        _color = Color.Lerp(_color, Color.clear, lerp_hide);
    }
}
