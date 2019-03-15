using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pipe_Rotation : MonoBehaviour {

    GameObject self;
    public float rotateForce;
    public bool isAndroid;
    public bool accelOptions;
    public Button leftButton;
    public Button rightButton; 

	// Use this for initialization
	void Start ()
    {
        self = gameObject;
        
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //Using the left and right arrows to turn the whole tunnel
        
        if (isAndroid == false)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                self.transform.Rotate(0, -rotateForce, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                self.transform.Rotate(0, rotateForce, 0);
            }
            
        }
        //Checks if using Android control schemes
        if (isAndroid == true)
        {
            //Checks if using the accelerometer, and which "version". This one doesn't work.
            if (accelOptions == true)
            {
                if (Input.acceleration.x > 0)
                {
                    self.transform.Rotate(0, -rotateForce, 0);
                }
                if (Input.acceleration.x < 0)
                {
                    self.transform.Rotate(0, -rotateForce, 0);
                }
            }
            //The version that actually works
            if (accelOptions == false)
            {
                self.transform.Rotate(0, Input.acceleration.x * rotateForce, 0);

            }
        }


    }

    //For left-click and right-click, turns tunnel 1/8th. To be used for touch-screen
    public void LeftButton ()
    {
        self.transform.Rotate(0, -22.5f, 0);
        
    }

    public void RightButton ()
    {
        self.transform.Rotate(0, 22.5f, 0);
    }

}
