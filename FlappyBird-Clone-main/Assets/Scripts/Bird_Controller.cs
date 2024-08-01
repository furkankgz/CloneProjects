using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bird_Controller : MonoBehaviour
{
    public float JumpForce;
    public Rigidbody2D Rb;
    private int Score;
    public Text ScoreText;
    public GameObject GameOverPanel;

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Rb.velocity = Vector2.up * JumpForce;
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Score")
        {
            Score++;
            ScoreText.text = Score.ToString();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
