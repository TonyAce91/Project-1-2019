using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EternalCanvas : MonoBehaviour {

    public static EternalCanvas m_canvas = null;

	// Use this for initialization
	void Awake () {
        if (m_canvas == null)
        {
            DontDestroyOnLoad(gameObject);
            m_canvas = this;
        }
        else
            Destroy(gameObject);
	}
}
