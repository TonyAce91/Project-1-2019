using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CollectSparks : MonoBehaviour
{
    public AudioSource collectSound;


    void OnTriggerEnter(Collider other)
    {
        collectSound.Play();
        ScoreSystem.theScore += 50;
        Destroy(gameObject);
    }
}

    
