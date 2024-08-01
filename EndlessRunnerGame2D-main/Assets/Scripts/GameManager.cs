using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int _score;
    public TMP_Text _scoreText;

    public static GameManager _instance;
    public GameObject _gameOverPanel;
    public TMP_Text _currentText;
    public TMP_Text _highScoreText;
    public Button _restartButton;

    public Camera _mainCam;
    public Image _backgroundImage;
    private int _randomIndex;
    public Color[] _colorToChange;


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        _randomIndex = Random.Range(0, _colorToChange.Length);
        ChangeColor();
    }

    private void Start()
    {
        _score = 0;
        _scoreText.text = _score.ToString();
        _gameOverPanel.SetActive(false);
        _restartButton.onClick.RemoveAllListeners();
        _restartButton.onClick.AddListener(RestartLevel);

        _currentText.text = PlayerPrefs.GetInt("Score").ToString();
        _highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void AddScore()
    {
        _score++;
        _scoreText.text = _score.ToString();
        _randomIndex = Random.Range(0, _colorToChange.Length);
        ApplyColor();
    }

    public void GameOver()
    {
        FindObjectOfType<AudioManager>().Play("GameOver");

        if (_score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", _score);
        }

        PlayerPrefs.SetInt("Score", _score);
        _currentText.text = PlayerPrefs.GetInt("Score").ToString();
        _highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();

        _gameOverPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    void ApplyColor()
    {
        if (_score >= 2)
        {
            ChangeColor();
        }
        else if (_score == 5)
        {
            ChangeColor();
        }
    }

    public void ChangeColor()
    {
        _mainCam.backgroundColor = _colorToChange[_randomIndex];
        _backgroundImage.color = _colorToChange[_randomIndex];
    }
}
