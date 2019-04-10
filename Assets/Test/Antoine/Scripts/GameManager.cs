using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [SerializeField] private Slider m_controllerToggle = null;
    [SerializeField] private Pipe_Rotation m_controlRotation = null;
    [SerializeField] private GameObject m_UIButtons = null;

    [HideInInspector] public bool tiltControl = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ReinitialiseControl()
    {
        if (tiltControl)
        {
            m_controllerToggle.value = 1;
            m_UIButtons.SetActive(false);
        }
        else
        {
            m_UIButtons.SetActive(true);
            m_controllerToggle.value = 0;
        }
    }

    public void ControlToggle()
    {
        if (m_controlRotation == null)
            m_controlRotation = FindObjectOfType<Pipe_Rotation>();


        if (m_controllerToggle != null)
        {
            tiltControl = !tiltControl;
            if (tiltControl)
            {
                m_controllerToggle.value = 1;
                m_UIButtons.SetActive(false);
            }
            else
            {
                m_UIButtons.SetActive(true);
                m_controllerToggle.value = 0;
            }
            if (m_controlRotation != null)
                m_controlRotation.touchOn = tiltControl ? false : true;
        }
    }
}
