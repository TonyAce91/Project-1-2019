using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ScoreSystem : MonoBehaviour {

    public GameObject ScoreText;
    public static int theScore;
  

    void Update()
    {
        ScoreText.GetComponent<Text>().text = "Score: " + theScore;
    }

}

