using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreSort : MonoBehaviour {

    [System.Serializable]
    public class ScoreData
    {
        public string name = "";
        public int score = 0;
    }

    int score = 0;

    [SerializeField] private List<ScoreData> m_listOfScores = new List<ScoreData>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (score > m_listOfScores[m_listOfScores.Count -1].score)
        {
            // Ask for name

            // Create new scoreData
            // Method kinda convoluted
            // Add to list
            // Sort list
            // Delete last entry if count > max

            // Another method
            // Insert to list
            // Delete last entry if count > max
        }

        // lambda so good ^_^
        m_listOfScores.Sort(delegate (ScoreData x, ScoreData y)
        {
            if (x == null || y == null) return 0;
            else if (x.score < y.score) return -1;
            else if (x.score > y.score) return 1;
            else return 0;
        }
        );
	}

}
