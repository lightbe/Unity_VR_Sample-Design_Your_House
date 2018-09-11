using System.Collections;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public bool displayDebug, startStopHead;
    public Animator armAnimator, hauntedHouseAnimator, hammerCapsuleAnimator, hammerTargetAnimator, foxHeadAnimation;
    public AudioSource armAudioSource, bombAudioSource, hauntedHouseAudioSource, hammerCapsuleAudioSource, foxHeadAudioSource;
    public ParticleSystem hammerCapsuleParticleSystem;
    public float bombEnable = 1;
    public GameObject bombParticleSystem, directionalLights, hauntedHouseLightBlue, houseUnderWater;

    // Start/stop the construction vehicle arm animation
    public void MoveTheArm()
    {
        if (this.gameObject.name.Contains("ArmSeen") || this.gameObject.name.Contains("ClickToGoOutside"))
        {
            armAnimator.SetBool("MoveArm", true);
            armAudioSource.Play();
        }
        else if (this.gameObject.name.Contains("ArmNotSeen"))
        {
            armAnimator.SetBool("MoveArm", false);
            armAudioSource.Stop();
        }

    }

    // Play the explosion sound and start the particle system
    public void Explosion()
    {
        Invoke("EnableBomb", bombEnable);
    }

    // Disable bomb particle systems when on a certain waypoint
    public void DisableBomb()
    {
        bombParticleSystem.SetActive(false);
    }

    // Play the explosion sound and start the particle system
    void EnableBomb()
    {
        bombParticleSystem.SetActive(true);

        PlayBombSound();
    }

    // Play the explosion sound and start the particle system
    void PlayBombSound()
    {

        bombAudioSource.Play();
    }

    // Start the Haunted House tilting, turn off the directional lights and play the audio
    public void StartHauntedHouse()
    {
        directionalLights.SetActive(false);
        hauntedHouseLightBlue.SetActive(true);
        hauntedHouseAnimator.SetBool("HouseTilt", true);
        hauntedHouseAudioSource.Play();
        if (displayDebug) { Debug.Log("Haunted House should be tilting"); }

        StartCoroutine(EndOfHauntedHouseAudio());
    }

    // Check for the end of the audio and stop playing the audio if the person does not click away from the haunted house.
    IEnumerator EndOfHauntedHouseAudio()
    {
        yield return new WaitForSeconds(hauntedHouseAudioSource.clip.length);
        StopHauntedHouse();
    }

    // Stop the Haunted House tilting, turn on the directional lights and stop playing the audio
    public void StopHauntedHouse()
    {
        hauntedHouseAnimator.SetBool("HouseTilt", false);
        hauntedHouseAudioSource.Stop();
        directionalLights.SetActive(true);
        hauntedHouseLightBlue.SetActive(false);
        if (displayDebug) { Debug.Log("Haunted House should NOT be tilting"); }
    }

    // Start/stop the Hammer Capsule animation and smoke particle system
    public void MoveHammerCapsule()
    {
        if (this.gameObject.name.Contains("CapsuleSeen") || this.gameObject.name.Contains("ClickToGoOutside"))
        {
            hammerCapsuleAnimator.SetBool("MoveCapsule", true);
            hammerTargetAnimator.SetBool("Sparks", true);
            hammerCapsuleAudioSource.Play();
            hammerCapsuleParticleSystem.Play();
        }
        else if (this.gameObject.name.Contains("CapsuleNotSeen"))
        {
            hammerCapsuleAnimator.SetBool("MoveCapsule", false);
            hammerTargetAnimator.SetBool("Sparks", false);
            hammerCapsuleAudioSource.Stop();
            hammerCapsuleParticleSystem.Stop();
        }

    }

    // Start the House floating under water and play the audio
    public void StartHouseFloating()
    {
        houseUnderWater.GetComponent<Floating>().startStop = true;
        houseUnderWater.GetComponent<AudioSource>().Play();
        if (displayDebug) { Debug.Log("House should be floating"); }
    }

    // Check for the end of the audio and stop playing the audio if the person does not click away from the haunted house.
    public void StopHouseFloating()
    {
        houseUnderWater.GetComponent<Floating>().startStop = false;
        houseUnderWater.GetComponent<AudioSource>().Stop();
        if (displayDebug) { Debug.Log("House should NOT be floating"); }
    }

    // Start/stop the moveing the fox head arm animation
    public void MoveFoxHead()
    {
        if (startStopHead)
        {
            startStopHead = false;
            foxHeadAnimation.SetBool("MoveHead", false);
            foxHeadAudioSource.Stop();
            if (displayDebug) { Debug.Log("Dog head should NOT be nodding & audio should NOT be playing"); }
        }
        else
        {
            startStopHead = true;
            foxHeadAnimation.SetBool("MoveHead", true);
            foxHeadAudioSource.Play();
            if (displayDebug) { Debug.Log("Dog head should be nodding & audio should be playing"); }
        }

    }

}