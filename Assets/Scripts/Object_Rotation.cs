using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Rotation : MonoBehaviour {

    GameObject self;

	// Use this for initialization
	void Start () {
        self = gameObject;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        self.transform.Rotate(0, 6, 0);
    }
}
