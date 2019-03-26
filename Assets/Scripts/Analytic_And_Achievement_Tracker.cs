using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Analytic_And_Achievement_Tracker : MonoBehaviour {

    public int timeSpentPlaying;
    public int savedBestDistance;
    public int mostCommonObstacle;
    public int savedTotalSparks;
    int[] obstaclesHit;

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    public void RecordValues (string typeOf, int amount)
    {
        if (typeOf == "bestDistance")
        {
            savedBestDistance = amount;
        }
        if (typeOf == "hitObstacle")
        {
            obstaclesHit[amount]++;

            

        }
        if (typeOf == "totalSparks")
        {
            savedTotalSparks = amount;
        }

    }
}
