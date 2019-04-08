using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.Analytics;

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


    // Unity Analytics
    private const string eventName = "CustomEvent";
    private Dictionary<string, object> parameters = new Dictionary<string, object>();
    [SerializeField] private GameObject touchButtons = null;

    // Use this for initialization
    void Start () {
        // Initialise Analytics
        foreach (string obstacleName in Enum.GetNames(typeof(ObstacleType)))
            obstacleAnalytics.Add(obstacleName, 0);

        // Initialise Unity Analytics
        parameters.Add("Obstacle Type", "None");
        parameters.Add("Distance Reached", 0);
        parameters.Add("Controls Used", "None");
        parameters.Add("Sparks Collected", 0);
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

        parameters["Obstacle Type"] = obstacleType.ToString();
        parameters["Distance Reached"] = distance;
        if (touchButtons.activeSelf)
            parameters["Controls Used"] = "Buttons";
        else
            parameters["Controls Used"] = "Tilt";
        parameters["Sparks Collected"] = collectedSparks;

        // Send Event
        AnalyticsResult result = AnalyticsEvent.Custom(eventName, parameters);

        if (result == AnalyticsResult.Ok)
            Debug.Log("Analytics sent");
        else
            Debug.Log("Analytics not sent");
    }
}
