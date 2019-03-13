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
        if (isAndroid == true)
        {
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
            if (accelOptions == false)
            {
                self.transform.Rotate(0, Input.acceleration.x * rotateForce, 0);

            }
        }


    }

    public void LeftButton ()
    {
        self.transform.Rotate(0, -22.5f, 0);
    }

    public void RightButton ()
    {
        self.transform.Rotate(0, 22.5f, 0);
    }

}
