using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public Transform Ball;
    private GameManager Gm;
    void Start()
    {
        Gm = GameObject.FindObjectOfType<GameManager>();
    }
    
    void Update()
    {
        if (transform.position.y + 12.5 >= Ball.position.y)
        {
            Destroy(gameObject);
            Gm.GameScore(25);
        }
    }
}
