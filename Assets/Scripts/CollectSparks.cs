using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CollectSparks : MonoBehaviour
{
    public AudioSource collectSound;
    public GameObject sparkHit;

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
            Instantiate(sparkHit, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), Quaternion.identity);
            Destroy(gameObject);

        }
        
    }
}

    
