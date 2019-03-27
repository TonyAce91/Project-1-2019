using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Analytic_And_Achievement_Tracker : MonoBehaviour {

    public int timeSpentPlaying;
    public int savedBestDistance;
    public int mostCommonObstacle;
    public int savedTotalSparks;
    public int[] obstaclesHit;

	// Use this for initialization
	void Start ()
    {
        //GameObject[] objs = GameObject.FindGameObjectsWithTag("DDOLTracker");
        //if (objs.Length > 1)
        //{
        //    Destroy(objs[1]);
        //}
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
