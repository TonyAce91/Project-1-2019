using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour {

    public int whichScene;

	// Use this for initialization
	void Start ()
    {
		
	}
	
    public void LoadTheGame ()
    {
        SceneManager.LoadScene(whichScene);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
