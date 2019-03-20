using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Ball : MonoBehaviour {

    public bool isDead = false;
    public GameObject self;
    public Text scoreBoard;
    public int score;
    [SerializeField] private int m_increment = 1;
    public GameObject spawnNet;

	// Use this for initialization
	void Start ()
    {
        self = gameObject;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (isDead == false)
        {
            score += m_increment;
            

        }
        if (isDead == true)
        {
            spawnNet.SetActive(false);
            SceneManager.LoadScene(0);
        }
        scoreBoard.text = ("" + score + "m");
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == ("Deadly"))
        {
            Debug.Log("OW.");
            isDead = true;
        }
    }
}
