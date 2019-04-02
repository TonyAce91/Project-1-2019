using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAdapter : MonoBehaviour {

    Button m_button = null;
    Pipe_Rotation m_controlRotation = null;
    [SerializeField] private bool m_isLeft = true;
    bool m_initialised = false;

	// Use this for initialization
	void Start () {
        m_button = gameObject.GetComponent<Button>();
        GameManager manager = FindObjectOfType<GameManager>();
	}

    private void Update()
    {
        if (m_initialised == false)
        {
            m_controlRotation = FindObjectOfType<Pipe_Rotation>();
            if (m_controlRotation != null)
            {
                ReferenceRotation(m_controlRotation);
                m_initialised = true;
            }
        }
    }

    // Update is called once per frame
    void ReferenceRotation (Pipe_Rotation rotationScript) {
        if (m_isLeft)
            m_button.onClick.AddListener(rotationScript.LeftButton);
        else
            m_button.onClick.AddListener(rotationScript.RightButton);
        Debug.Log("Reference Rotation called");

    }
}
