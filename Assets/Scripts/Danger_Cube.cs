using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObstacleType
{
    Pipe1,
    Pipe2,
    SewerGrate,
    TreeHollow,
    SpiderWeb,
    Branch,
    Crystal
}


public class Danger_Cube : MonoBehaviour {

    public float moveSpeed;
    public float lifeSpan;
    public float life;
    public ObstacleType m_obstacleType;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += new Vector3(0, moveSpeed, 0);
        life++;
        if (life > lifeSpan)
        {
            Destroy(gameObject);
        }
	}
}
