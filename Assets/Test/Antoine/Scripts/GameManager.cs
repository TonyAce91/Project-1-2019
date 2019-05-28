using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    // Settings variables
    [SerializeField] private Slider m_controllerToggle = null;
    [HideInInspector] public bool tiltControl = true;
    [SerializeField] private GameObject m_UIButtons = null;

    // Reference to the movement controller
    [SerializeField] private Pipe_Rotation m_controlRotation = null;

    // Hides joysticks when not using button control, this serves as memory of previous settings
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

    // Toggles between the tilt control and button control
    public void ControlToggle()
    {
        // Finds a reference to the Pipe rotation script
        if (m_controlRotation == null)
            m_controlRotation = FindObjectOfType<Pipe_Rotation>();

        // Toggles the controller slider in option menu and hides buttons when using tilt control
        if (m_controllerToggle != null)
        {
            tiltControl = !tiltControl;
            ReinitialiseControl();
            if (m_controlRotation != null)
                m_controlRotation.touchOn = tiltControl ? false : true;
        }
    }
}
