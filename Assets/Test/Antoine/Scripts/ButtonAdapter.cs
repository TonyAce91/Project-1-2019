﻿using System.Collections;
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
        if (m_controlRotation == null)
        {
            m_controlRotation = FindObjectOfType<Pipe_Rotation>();
        }
    }

    public void RotatePipe()
    {
        if (m_isLeft)
            m_controlRotation.LeftButton();
        else
            m_controlRotation.RightButton();
    }

    public void GameRestart()
    {
        m_controlRotation = null;
    }
}
