﻿using System.Collections;
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

    //Stuff needed for Death Sequence
    public GameObject deathScreenUI;
    public GameObject playerModel;
    public GameObject deathParticles;
    public GameObject firefly;
    

    //Powerup Stats
    float powerAmount;
    public int powerMaxAmount;
    public Slider powerBar;
    public GameObject lizardGlow;
    public GameObject powerUp;
    bool powered;
    public bool powerDrain;
    public int powerDrainCount;
    public float powerDrainAmount;
    int counter;
    public GameObject abilityTouchButton;

    //Iframes for shield
    public int invincibleCounter;
    public bool invincible;
    public int invincibleTimeLimit;

    // Use this for initialization
    void Start()
    {
        self = gameObject;
        m_analytics = FindObjectOfType<AnalyticsAndAchievements>();
        m_scoringSystem = FindObjectOfType<ScoringSystem>();
        
    }

    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void AbilityButton()
    {
        if ((powerAmount >= powerMaxAmount) && (powered != true))
        {
            powerAmount = 0;
            lizardGlow.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            powered = true;
            powerUp.SetActive(true);
            abilityTouchButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        
        if (isDead == false)
        {
            if (powerAmount >= powerMaxAmount)
            {
                abilityTouchButton.SetActive(true);
            }
            score += m_increment;
            counter++;
            if ((counter > powerDrainCount) && (powerAmount > 0) && (powerDrain == true) && (powerAmount < powerMaxAmount))
            {

                powerAmount += -powerDrainAmount;
                counter = 0;
            }
            powerBar.value = powerAmount;
            if (Input.GetKey("space"))
            {
                if ((powerAmount >= powerMaxAmount) && (powered != true))
                {
                    powerAmount = 0;
                    lizardGlow.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    powered = true;
                    powerUp.SetActive(true);
                    abilityTouchButton.SetActive(false);
                }
            }
            if ((invincible == true) && (invincibleCounter < invincibleTimeLimit))
            {
                invincibleCounter++;
            }
            if (invincibleCounter >= invincibleTimeLimit)
            {
                invincible = false;
                invincibleCounter = 0;
            }
        }
        if (isDead == true)
        {
            firefly.SetActive(false);
            lizardGlow.SetActive(false);
            spawnNet.SetActive(false);
            if (m_scoringSystem)
                m_scoringSystem.CheckScore(score);
            else
                deathScreenUI.SetActive(true);
                playerModel.SetActive(false);
            deathParticles.SetActive(true);
            //SceneManager.LoadScene(0);
        }
        scoreBoard.text = ("" + score + "m");
        

	}

    void OnTriggerEnter(Collider collider)
    {
        if ((collider.gameObject.tag == ("Deadly")) && (invincible != true) && (isDead == false))
        {
            if (powered == false)
            {
                Debug.Log("OW.");
                isDead = true;
                m_analytics.UpdateAnalytics(collider.GetComponent<Danger_Cube>().m_obstacleType, score, m_cumulativeSparks, Time.timeSinceLevelLoad);
            }
            if (powered == true)
            {
                powered = false;
                powerUp.SetActive(false);
                Destroy(collider);
                invincible = true;
            }
        }

        if ((collider.gameObject.tag == ("Spark")) && (isDead == false))
        {
            Debug.Log("NOM");
            Destroy(collider.gameObject);
            m_cumulativeSparks++;
            if (powerAmount < powerMaxAmount)
            {
                powerAmount += 1;
                counter = 0;
                lizardGlow.transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
            }
        }
    }
}

// Need to turn sparks into object pooling
