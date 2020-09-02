using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;
    public int Score
    {
        get
        {
            return score;
        }
    }
    public void AddScore(int score)
    {
        this.score += score;
        scoreText.text = "점수\n" + this.score;
    }
}
