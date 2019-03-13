using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Spawner : MonoBehaviour {

    public GameObject dangerCube;
    public GameObject self;
    public bool spawnerOn;
    public float spawnChance;
    float willItSpawn;
    public float difficultyIncrementer;
    public bool difficultyOn;
    public float backupDifficulty;
    //The array for obstacles to spawn
    public GameObject[] obstacles;
    public bool BeatMode = false;
    public bool inBeat;
    public int counter;


    // Use this for initialization
    void Start ()
    {
        backupDifficulty = difficultyIncrementer;
        self = gameObject;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (spawnerOn == true)
        {
            if (BeatMode == false)
            {
                willItSpawn = Random.Range(1.0f, spawnChance + difficultyIncrementer);
                if (difficultyOn)
                {
                    difficultyIncrementer += (difficultyIncrementer / 100) * Time.deltaTime;
                }
                if (willItSpawn >= spawnChance)
                {
                    int whichOne = Random.Range(1, 10);
                    if (whichOne <= 8)
                    {
                        Instantiate(obstacles[0], self.transform);
                    }
                    if (whichOne > 8)
                    {
                        Instantiate(obstacles[1], self.transform);
                    }
                }
            }
            //if (BeatMode == true)
            //{
            //    counter++;
            //    if (counter > 25)
            //    {
            //        inBeat = true;
            //        if (counter > 30)
            //        {
            //            counter = 0;
            //        }
                    
            //    }
            //    if (counter < 30)
            //    {
            //        inBeat = false;
            //    }
            //    willItSpawn = Random.Range(1.0f, spawnChance + difficultyIncrementer);
            //    if (difficultyOn)
            //    {
            //        difficultyIncrementer += (difficultyIncrementer / 1000);
            //    }
            //    if (willItSpawn >= spawnChance)
            //    {
            //        if (inBeat == true)
            //        {
                        
            //            int whichOne = Random.Range(1, 10);
            //            if (whichOne <= 8)
            //            {
            //                Instantiate(obstacles[0], self.transform);
            //            }
            //            if (whichOne > 8)
            //            {
            //                Instantiate(obstacles[1], self.transform);
            //            }
                        
            //        }
            //    }
            //}
        }

        
	}
    
}
