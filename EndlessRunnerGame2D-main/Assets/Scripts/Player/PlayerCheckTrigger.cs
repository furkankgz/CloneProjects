using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Coin
        if (collision.gameObject.CompareTag("Coin"))
        {
            // Score ++
            FindObjectOfType<AudioManager>().Play("Coin");
            GameManager._instance.AddScore();
            Destroy(collision.gameObject, .02f);
            
        }

        // Wall 
        if (collision.gameObject.CompareTag("Wall"))
        {
            // GameOver
            FindObjectOfType<AudioManager>().Play("GameOver");
            Time.timeScale = 0;
            GameManager._instance.GameOver();

        }
    }
}
