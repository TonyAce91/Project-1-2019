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
    public GameObject DDOLTracker;
    private ScoringSystem m_scoringSystem = null;

    // Use this for initialization
    void Start ()
    {
        self = gameObject;
        DDOLTracker = GameObject.FindGameObjectWithTag("DDOLTracker");
        m_scoringSystem = FindObjectOfType<ScoringSystem>();
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
            if (m_scoringSystem)
                m_scoringSystem.CheckScore(score);
            else
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
            int obType = collider.GetComponent<Danger_Cube>().analyticObstacleType;
            DDOLTracker.GetComponent<Analytic_And_Achievement_Tracker>().RecordValues("hitObstacle", obType);
            DDOLTracker.GetComponent<Analytic_And_Achievement_Tracker>().RecordValues("bestDistance", score);
        }
    }
}
