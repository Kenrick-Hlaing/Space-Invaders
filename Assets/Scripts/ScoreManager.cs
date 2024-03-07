using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiScoreText;
    private int score = 0;
     private int hiScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        Enemy.OnEnemyDied += ScoreUp;
        LoadHiScore();
        //PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ScoreUp(int pointWorth){
        score += pointWorth;
        scoreText.text = $"Score\n{score.ToString("D4")}";

        if (score > hiScore)
        {
            hiScore = score;
            hiScoreText.text = $"Hi-Score\n{hiScore.ToString("D4")}";
            SaveHiScore();
        }
    }

    void LoadHiScore()
    {
        hiScore = PlayerPrefs.GetInt("HiScore", 0);
        hiScoreText.text = $"Hi-Score\n{hiScore}";
    }

    void SaveHiScore()
    {
        PlayerPrefs.SetInt("HiScore", hiScore);
        PlayerPrefs.Save();
    }
}
