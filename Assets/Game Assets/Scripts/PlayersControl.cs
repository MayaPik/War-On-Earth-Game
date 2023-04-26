using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersControl : MonoBehaviour
{
    [Header("General Setup Settings")]
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 10f;
    [SerializeField] GameObject laser;
    public AudioClip shootSoundClip;
    private AudioSource shootSound;
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float positionYawFactor = 2f;
     [SerializeField] float controlRollFactor = -20f;

    float xThrow, yThrow;

   void Start() {
    shootSound = GetComponent<AudioSource>();
    shootSound.clip = shootSoundClip;
   }
    void Update()
    {
    ProcessTranslation();
    ProcessRotation();
    ProcessFiring();
    }

    void ProcessRotation() {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControl;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll =  xThrow * controlRollFactor;
        
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

    }
    void ProcessTranslation() {

        xThrow= Input.GetAxis("Horizontal");
        yThrow= Input.GetAxis("Vertical");

        float xOffSet = xThrow * Time.deltaTime * controlSpeed;
        float newXpos = transform.localPosition.x + xOffSet;
        float clampedXPos = Mathf.Clamp(newXpos, -xRange, xRange);

        float yOffSet = yThrow * Time.deltaTime * controlSpeed;
        float newYpos = transform.localPosition.y + yOffSet; 
        float clampedYPos = Mathf.Clamp(newYpos, -yRange, yRange);
        
        transform.localPosition = new Vector3 (clampedXPos, clampedYPos, transform.localPosition.z);
    }

   void ProcessFiring() {
    if (Input.GetButton("Fire1")) {
        if (!shootSound.isPlaying) {
            shootSound.Play();
            
        }
        
        ChangeLaserMode(true);
    } else {
        if (shootSound.isPlaying) {
            shootSound.Stop();
        }
        ChangeLaserMode(false);
    }
}

    void ChangeLaserMode(bool mode) {
        var laserComponent= laser.GetComponent<ParticleSystem>().emission;
        laserComponent.enabled = mode;
    }
   
}

