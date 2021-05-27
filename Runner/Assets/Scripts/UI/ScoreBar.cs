using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBar : MonoBehaviour
{

    public TextMeshProUGUI score, highScore;
    public string highScorePrefix;

    private void Update()
    {
        UpdateScore();
        UpdateHighScore();
    }

    private void UpdateScore()
    {
        score.text = Player.instance.playerStats.Score.ToString();
    }

    private void UpdateHighScore()
    {
        highScore.text = highScorePrefix + Player.instance.playerStats.GetHighScore().ToString();
    }
}
