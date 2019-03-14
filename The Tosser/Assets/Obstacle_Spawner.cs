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
    public int[] obstacleChances;
    public GameObject[] spawners;
    public bool BeatMode = false;
    public bool inBeat;
    public int counter;


    // Use this for initialization
    void Start ()
    {
        backupDifficulty = difficultyIncrementer;
        self = gameObject;
	}
	
    

    void SpiralSpawn ()
    {
        
        Instantiate(obstacles[0], spawners[0].transform);
       
        Instantiate(obstacles[0], spawners[1].transform);

        Instantiate(obstacles[0], spawners[2].transform);

        Instantiate(obstacles[0], spawners[3].transform);

        Instantiate(obstacles[0], spawners[4].transform);

        Instantiate(obstacles[0], spawners[5].transform);

        Instantiate(obstacles[0], spawners[6].transform);

        
        Debug.Log("HYPERWALL");
    }

    //IEnumerator SpiralWait ()
    //{
        
    //}

    // Update is called once per frame
    void FixedUpdate ()
    {
        //Checks if the spawner is activated
        if (spawnerOn == true)
        {
            //"Beat Mode" is for trying to making obstacles sync with the "beat" generated. Currently broken.
            if (BeatMode == false)
            {
                //Generates a number between 1 and the spawn chance, and makes it more likely to succeed the spawn chance by adding the difficulty number
                willItSpawn = Random.Range(1.0f, spawnChance + difficultyIncrementer);
                if (difficultyOn)
                {
                    //Makes difficulty get harder by exponentially increasing the difficulty number each tick.
                    difficultyIncrementer += (difficultyIncrementer / 100) * Time.deltaTime;
                }
                //
                if (willItSpawn >= spawnChance)
                {
                    //Picks which obstacle to spawn
                    int whichOne = Random.Range(1, 10);
                    int whichSpawner = Random.Range(0, 7);
                    if (whichOne <= 7)
                    {
                        Instantiate(obstacles[0], spawners[whichSpawner].transform);

                    }
                    if (whichOne > 7 && whichOne < 10)
                    {
                        Instantiate(obstacles[1], spawners[whichSpawner].transform);
                    }
                    if (whichOne >= 9)
                    {
                        if (difficultyIncrementer > 3)
                        {
                            SpiralSpawn();
                        }
                        
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
