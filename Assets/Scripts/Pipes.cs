using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour {

    GameObject self;
    public float moveSpeed;
    int timer = 0;

    // Use this for initialization
    void Start ()
    {
        self = gameObject;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float selfX = self.transform.position.x;
        float selfZ = self.transform.position.z;
        float selfY = self.transform.position.y;
        self.transform.position = new Vector3(selfX, selfY + moveSpeed, selfZ);
        //transform.position += new Vector3(0, moveSpeed, 0);
        timer++;
        if (timer >= 300)
        {
            int number = timer;
            self.transform.position = new Vector3(selfX, selfY + -300, selfZ);
            //transform.position += new Vector3(0, -300, 0);
            timer = 0;
        }
    }
}
