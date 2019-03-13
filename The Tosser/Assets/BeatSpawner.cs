using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSpawner : MonoBehaviour {

    public GameObject beat;
    int counter;
    GameObject self;

	// Use this for initialization
	void Start ()
    {
        self = gameObject;
    }
	
	// Update is called once per frame
	void Update ()
    {
        counter++;
        if (counter > 10)
        {
            Instantiate(beat, self.transform);
            counter = 0;
        }

	}
}
