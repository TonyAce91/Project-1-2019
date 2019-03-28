using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firefly : MonoBehaviour {

    [SerializeField] private Transform positioningObjectsParent = null;
    [SerializeField] private List<Transform> m_positioningObjects = new List<Transform>();
    [SerializeField] private int moveChance = 50;
    int willItMove;
    int currentChance;
    Vector3 newPosition;
    public float moveSpeed;
    

	// Use this for initialization
	void Start ()
    {
        if (positioningObjectsParent != null)
        {
            foreach (Transform child in positioningObjectsParent)
            {
                m_positioningObjects.Add(child);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate ()
    {

        willItMove = Random.Range(1, moveChance + 1);
        if (willItMove >= moveChance)
        {
            currentChance = Random.Range(0, m_positioningObjects.Count);
            newPosition = m_positioningObjects[currentChance].transform.position;
                
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, newPosition, moveSpeed);
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == ("Deadly"))
        {
            currentChance = Random.Range(0, m_positioningObjects.Count);
            newPosition = m_positioningObjects[currentChance].transform.position;
        }
    }
}
