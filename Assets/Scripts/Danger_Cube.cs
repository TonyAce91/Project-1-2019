using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger_Cube : MonoBehaviour {

    GameObject self;
    public float moveSpeed;
    public float lifeSpan;
    public float life;
    public int analyticObstacleType;

	// Use this for initialization
	void Start ()
    {
        self = gameObject;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float selfX = self.transform.position.x;
        float selfZ = self.transform.position.z;
        float selfY = self.transform.position.y;
        self.transform.position = new Vector3(selfX, selfY + moveSpeed, selfZ);
        life++;
        if (life > lifeSpan)
        {
            Destroy(gameObject);
        }
	}
}
