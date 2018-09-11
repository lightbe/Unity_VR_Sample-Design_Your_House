using UnityEngine;

public class MainScript : MonoBehaviour
{

    public ParticleSystem hammerCapsuleSmokeParticleSystem, hammerCapsuleSparksParticleSystem, billboardParticleSystemBlue, billboardParticleSystemWhite, billboardParticleSystemRed;
    public GameObject startPoint, firstStartPoint, car;
    public float moveSpeed = 2, speedCrossStreet = 1, waitToCross = 5, waitToPlayAudio = 5, waitToStartCar = 5, waitToDisableCar = 15;
    bool crossingTheStreet = true;
    GameObject player;
    Animator carAnimator;

    // Use this for initialization
    void Start()
    {
        // Stop all particle systems at the beginning of the application
        hammerCapsuleSmokeParticleSystem.Stop();
        hammerCapsuleSparksParticleSystem.Stop();
        billboardParticleSystemBlue.Stop();
        billboardParticleSystemWhite.Stop();
        billboardParticleSystemRed.Stop();

        // Update 'player' to be the camera's parent gameobject, i.e. 'GvrEditorEmulator' instead of the camera itself.
        // Required because GVR resets camera position to 0, 0, 0.
        player = Camera.main.transform.parent.gameObject;

        // Move the 'player' to the 'startPoint' position.
        // player.transform.position = startPoint.transform.position;
        iTween.MoveTo(player,
            iTween.Hash(
                "position", startPoint.transform.position,
                "time", moveSpeed,
                "easetype", "linear"
            )
        );

        Invoke("StartTheCar", waitToStartCar);

        Invoke("MoveToFirstPoint", waitToCross);

        //Debug.Log("MoveFirstPoint method");
        Invoke("DeactivateCar", waitToDisableCar);

    }

    // Move to the first point to stop the camera
    public void MoveToFirstPoint()
    {
        if (crossingTheStreet)
        {
            iTween.MoveTo(player,
                iTween.Hash(
                    "position", firstStartPoint.transform.position,
                    "time", speedCrossStreet,
                    "easetype", "linear"
                )
            );

            crossingTheStreet = false;

            Invoke("PlayCrossStreetAudio", waitToPlayAudio);
        }
        else
        {
            iTween.MoveTo(player,
                iTween.Hash(
                    "position", firstStartPoint.transform.position,
                    "time", moveSpeed,
                    "easetype", "linear"
                )
            );
        }
    }

    // Play audio after crossing the street
    public void PlayCrossStreetAudio()
    {
        AudioSource crossStreetAudio = firstStartPoint.GetComponent<AudioSource>();
        crossStreetAudio.Play();
    }

    public void StartTheCar()
    {
        car.SetActive(true);
        AudioSource carAudio = car.GetComponent<AudioSource>();
        carAudio.Play();

        carAnimator = car.GetComponent<Animator>();
        carAnimator.SetBool("StartCar", true);
    }

    public void DeactivateCar()
    {
        car.SetActive(false);
    }

}