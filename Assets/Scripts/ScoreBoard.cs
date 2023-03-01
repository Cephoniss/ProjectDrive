using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private float score;
    private float scoreGain = 100;
    public const string HighScore = "Score";
    
    void Start()
    {
        
    }

    
    void Update()
    {
        //Updating  score by ScoreGain and 
        score += scoreGain * Time.deltaTime;

        //Using FloorToInt to change from float to int
        scoreText.text  = Mathf.FloorToInt(score).ToString();
    }

    private void OnDestroy() 
    {
        int currentHighScore = PlayerPrefs.GetInt(HighScore, 0);

        if(score > currentHighScore)
        {
            PlayerPrefs.SetInt(HighScore, Mathf.FloorToInt(score));
        }
    }
}
