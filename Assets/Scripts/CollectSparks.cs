using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CollectSparks : MonoBehaviour
{
    public AudioSource collectSound;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("AudioPlayer");
        collectSound = playerObject.GetComponent<AudioSource>();

    }

    void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == ("Player"))
        {
            collectSound.Play();
            ScoreSystem.theScore += 1;
            Destroy(gameObject);
        }
        
    }
}

    
