using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup_Spawns : MonoBehaviour {

    public GameObject DDOLTracker;

	// Use this for initialization
	void Start ()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("DDOLTracker");
        if (objs.Length == 0)
        {
            Instantiate(DDOLTracker);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
