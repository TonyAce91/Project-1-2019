using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAdapter : MonoBehaviour {

    private InputField m_nameField = null;
    private Button m_submitButton = null;
    private ScoringSystem m_scoringSystem = null;

	// Use this for initialization
	void Start () {

        if ((m_scoringSystem = FindObjectOfType<ScoringSystem>()) == null)
            return;

        if ((m_nameField = GetComponent<InputField>()) != null)
            m_scoringSystem.nameField = m_nameField;
        else if ((m_submitButton = GetComponent<Button>()) != null)
            m_submitButton.onClick.AddListener(m_scoringSystem.OnSubmit);
	}
	
	// Update is called once per frame
	void Update () {
		

	}
}

