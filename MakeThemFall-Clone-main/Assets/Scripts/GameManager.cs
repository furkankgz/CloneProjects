using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    public int _score = 0;

    void Update()
    {
        _scoreText.text = _score.ToString();    
    }
    
    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }
}
