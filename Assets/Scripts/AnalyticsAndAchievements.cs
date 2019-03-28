using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class AnalyticsAndAchievements : MonoBehaviour {

    Dictionary<string, int> obstacleAnalytics = new Dictionary<string, int>();
    int maxReachedDistance = 0;
    int maxCollectedSparks = 0;
    float m_cumulativeTime = 0f;

    [Header("Achievement list")]
    [SerializeField] private int m_distanceAchievement = 1000;
    [SerializeField] private int m_sparksAchievement = 100;
    [SerializeField] private float m_timeAchievement = 10f;

    // Events
    public UnityEvent distanceAchieved;
    public UnityEvent sparksAchieved;
    public UnityEvent timeAchieved;

	// Use this for initialization
	void Start () {
        // Initialise Analytics
        foreach (string obstacleName in Enum.GetNames(typeof(ObstacleType)))
            obstacleAnalytics.Add(obstacleName, 0);

        DontDestroyOnLoad(transform.parent.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateAnalytics(ObstacleType obstacleType, int distance, int collectedSparks, float timeSpent)
    {
        // Analytics
        obstacleAnalytics[obstacleType.ToString()]++;

        if (maxReachedDistance < distance)
            maxReachedDistance = distance;

        if (maxCollectedSparks < collectedSparks)
            maxCollectedSparks = collectedSparks;

        m_cumulativeTime += timeSpent / 60;


        // Achievements
        if (m_cumulativeTime > m_timeAchievement)
            timeAchieved.Invoke();
        if (distance > m_distanceAchievement)
            distanceAchieved.Invoke();
        if (collectedSparks > m_sparksAchievement)
            sparksAchieved.Invoke();
    }
}
