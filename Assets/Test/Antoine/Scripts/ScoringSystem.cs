using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.Events;

public class ScoringSystem : MonoBehaviour {

    [Serializable]
    public class ScoreData
    {
        public string name = "";
        public int score = 0;
    }

    [Serializable]
    private class JsonWrapper
    {
        public List<ScoreData> scoreList;
    }

    int m_score = 0;
    int maxAmount = 5;
    int minimumThreshold = 0;
    float templateHeight = 20;

    private bool stopUpdate = false;

    [SerializeField] private GameObject m_submissionCanvas = null;
    [SerializeField] private GameObject m_highscoreContainer = null;
    [SerializeField] private ScoreEntryScript m_scorePrefab = null;
    [SerializeField] private GameObject m_highscoreBoard = null;

    [HideInInspector] public bool sendAnalytics = false;

    private List<ScoreEntryScript> m_scoreUIList = new List<ScoreEntryScript>();

    public InputField nameField = null;
    private JsonWrapper wrapper = new JsonWrapper();

    private List<ScoreData> m_listOfScores = new List<ScoreData>();

    // Events
    public UnityEvent onGameOver;

    // Use this for initialization
    void Start () {

        // Checks if a score file exist
        if (File.Exists(Application.dataPath + "/score.txt"))
        {
            // Loads the score list if file exist
            string scoreString = File.ReadAllText(Application.dataPath + "/score.txt");
            JsonWrapper wrapper = JsonUtility.FromJson<JsonWrapper>(scoreString);
            m_listOfScores = wrapper.scoreList;
            minimumThreshold = m_listOfScores[m_listOfScores.Count - 1].score;
        }
        else
        {
            // Creates a new score list if file doesn't exist
            for (int i = 0; i < maxAmount; i++)
            {
                ScoreData newData = new ScoreData();
                m_listOfScores.Add(newData);
            }
            m_listOfScores.TrimExcess();
        }

        m_scorePrefab.gameObject.SetActive(false);

        int iteration = 0;
        foreach (ScoreData scoreData in m_listOfScores)
        {
            ScoreEntryScript scoreEntry = Instantiate(m_scorePrefab, m_highscoreContainer.transform);
            RectTransform rectTrans = scoreEntry.transform.GetComponent<RectTransform>();
            rectTrans.anchoredPosition = new Vector2(0, -templateHeight * iteration);
            rectTrans.gameObject.SetActive(true);

            // Set the scores from list into UI
            scoreEntry.nameText.text = scoreData.name;
            scoreEntry.scoreText.text = scoreData.score.ToString();
            m_scoreUIList.Add(scoreEntry);
            iteration++;
        }
    }

    // Update is called once per frame
    void Update () {
        if (stopUpdate)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
	}

    public void PauseGame(bool status = true)
    {
        stopUpdate = status;
    }

    public void CheckScore(int score)
    {
        // Checks if there's new high score
        if (score > minimumThreshold)
        {
            m_score = score;
            m_submissionCanvas.SetActive(true);
            stopUpdate = true;
        }
        else
        {
            if (m_highscoreBoard)
                m_highscoreBoard.SetActive(true);
            onGameOver.Invoke();
            SceneManager.LoadScene(0);
        }
    }
    public void OnSubmit()
    {
        ScoreData newData = new ScoreData
        {
            name = nameField.text,
            score = m_score
        };

        int index = int.MaxValue;
        Debug.Log(m_listOfScores.Count);

        // Goes through the current list and insert the new score
        for (int i = 0; i < m_listOfScores.Count; i++)
        {
            if (newData.score > m_listOfScores[i].score)
            {
                index = i;
                m_listOfScores.Insert(index, newData);
                break;
            }
        }


        // Remove unnecessary high scores
        if (m_listOfScores.Count > maxAmount)
        {
            m_listOfScores.RemoveAt(m_listOfScores.Count - 1);
        }

        // Updates UI list
        for (int i = 0; i < m_scoreUIList.Count; i++)
        {
            m_scoreUIList[i].nameText.text = m_listOfScores[i].name;
            m_scoreUIList[i].scoreText.text = m_listOfScores[i].score.ToString();
        }

        minimumThreshold = m_listOfScores[m_listOfScores.Count -1].score;
        m_submissionCanvas.SetActive(false);
        stopUpdate = false;
        onGameOver.Invoke();
        SceneManager.LoadScene(0);
    }

    public void OpenSurvey()
    {
        Application.OpenURL("https://forms.gle/3XqZkWEFMNMh5rdB8");
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void OnDisable()
    {
        Application.OpenURL("https://forms.gle/3XqZkWEFMNMh5rdB8");
        Debug.Log("Quitting application");
        JsonWrapper wrapper = new JsonWrapper();
        wrapper.scoreList = m_listOfScores;
        string json = JsonUtility.ToJson(wrapper);
        File.WriteAllText(Application.dataPath + "/score.txt", json);
    }
}


//if (score > m_listOfScores[m_listOfScores.Count -1].score)
//{
//    // Ask for name


//    // Create new scoreData
//    // Method kinda convoluted
//    // Add to list
//    // Sort list
//    // Delete last entry if count > max

//    //if (m_listOfScores.Count > maxAmount)
//    //    m_listOfScores

//    // Another method
//    // Insert to list
//    // Delete last entry if count > max
//}

//// lambda so good ^_^
//m_listOfScores.Sort(delegate (ScoreData x, ScoreData y)
//{
//    if (x == null || y == null) return 0;
//    else if (x.score < y.score) return -1;
//    else if (x.score > y.score) return 1;
//    else return 0;
//}
//);

