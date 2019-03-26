using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firefly : MonoBehaviour {

    public GameObject[] positioningObjects;
    GameObject self;
    float willItMove;
    public float moveChance;
    int currentChance;
    Vector3 newPosition;
    

	// Use this for initialization
	void Start ()
    {
        self = gameObject;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (self.transform.position != newPosition)
        {
            self.transform.position = Vector3.Lerp(self.transform.position, newPosition, 0.1f);
            Debug.Log("It should be moving...");
        }
        willItMove = Random.Range(1.0f, moveChance);
        if (willItMove >= moveChance)
        {
            currentChance = Random.Range(0, positioningObjects.Length);
            Vector3 assignedPosition = positioningObjects[currentChance].transform.position;
            newPosition = new Vector3(assignedPosition.x, newPosition.y, assignedPosition.z);
                
        }
       
    }
}
