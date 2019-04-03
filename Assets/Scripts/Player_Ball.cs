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
    private AnalyticsAndAchievements m_analytics = null;
    private ScoringSystem m_scoringSystem = null;
    private int m_cumulativeSparks = 0;
    int powerAmount;
    public Slider powerBar;
    public GameObject lizardGlow;

    // Use this for initialization
    void Start ()
    {
        self = gameObject;
        m_analytics = FindObjectOfType<AnalyticsAndAchievements>();
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
        powerBar.value = powerAmount;
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == ("Deadly"))
        {
            Debug.Log("OW.");
            isDead = true;
            m_analytics.UpdateAnalytics(collider.GetComponent<Danger_Cube>().m_obstacleType, score, m_cumulativeSparks, Time.timeSinceLevelLoad);
        }

        if (collider.gameObject.tag == ("Spark"))
        {
            Debug.Log("NOM");
            Destroy(collider.gameObject);
            m_cumulativeSparks++;
            if (powerAmount < 50)
            {
                powerAmount++;
                lizardGlow.transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
            }
        }
    }
}

// Need to turn sparks into object pooling
