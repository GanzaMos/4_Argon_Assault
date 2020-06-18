using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [Tooltip("Time before new level starts after collision")] [SerializeField] float levelLoadDelay = 1f;
    [Tooltip("Insert Death Animation")][SerializeField] GameObject deathFX;
    
    private void OnTriggerEnter(Collider collision)
    {
        DeathSequance(); 
    }

    private void DeathSequance()
    {
        SendMessage("OnPlayerDeath"); //disable movement
        deathFX.SetActive(true); //activate explosion particle
        Invoke("RestartScene", levelLoadDelay); //restart current scene with delay
    }

    private void RestartScene() //strig reference, don't change the name!
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
