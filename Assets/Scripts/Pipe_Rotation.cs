using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pipe_Rotation : MonoBehaviour {

    GameObject self;
    public float rotateForce;
    public bool isAndroid = true;
    public bool touchOn = false;
    public Button leftButton;
    public Button rightButton;
    private GameManager m_manager = null;
    //private List<ButtonAdapter> m_controlButtons = new List<ButtonAdapter>();

	// Use this for initialization
	void Start ()
    {
        self = gameObject;
        m_manager = FindObjectOfType<GameManager>();
        if (m_manager != null)
        {
            touchOn = !m_manager.tiltControl;
            Debug.Log("Manager found");
        }
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //Using the left and right arrows to turn the whole tunnel
        
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                self.transform.Rotate(0, -rotateForce, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                self.transform.Rotate(0, rotateForce, 0);
            }

#endif
        //Checks if using Android control schemes
#if UNITY_IOS || UNITY_ANDROID
            //The version that actually works
            if (touchOn == false)
            {
                transform.Rotate(0, Input.acceleration.x * rotateForce, 0);
            }
#endif
    }

    //For left-click and right-click, turns tunnel 1/8th. To be used for touch-screen
    public void LeftButton ()
    {
        if (Time.timeScale > 0)
            transform.Rotate(0, -rotateForce * 2, 0);
    }

    public void RightButton ()
    {
        if (Time.timeScale > 0)
            transform.Rotate(0, rotateForce * 2, 0);
    }

}
