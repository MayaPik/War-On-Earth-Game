using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class CollisionHandler : MonoBehaviour
{

    [SerializeField] ParticleSystem expolosion;
    public AudioClip explosionSoundClip;
    private AudioSource explosionSound;
    ScoreBoard scoreboard;

    void Start() {
    scoreboard = FindObjectOfType<ScoreBoard>();
    explosionSound = GetComponent<AudioSource>();
    }

   void OnTriggerEnter(Collider other) {
    if (other.gameObject.tag == "Gate") {
       scoreboard.GetStatusText().text = $"You Won! Score: {scoreboard.GetScore().ToString()}";
    } else {
        StartCrashSequence();
       
    }
}

    void StartCrashSequence() {
    scoreboard.GetStatusText().text = "Try Again";
    Invoke("ClearScoreText", 1f);
    explosionSound.clip = explosionSoundClip;
    explosionSound.Play();
    GetComponent<PlayersControl>().enabled = false;
    expolosion.Play();
    Invoke("ReloadLevel", 1f);
    }

    void ClearScoreText() {
    scoreboard.GetStatusText().text = "";
}

    void ReloadLevel() {
    int currentIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentIndex);
    }
}