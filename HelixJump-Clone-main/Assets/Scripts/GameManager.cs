using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int Score;
    public Text ScoreText;

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void GameScore(int RingScore)
    {
        Score += RingScore;
        ScoreText.text = Score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
