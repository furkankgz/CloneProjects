using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip _clickSound; 

    private int count = 0;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            count++; 
            AudioSource.PlayClipAtPoint(_clickSound, collision.transform.position);
            Destroy(collision.gameObject);
        }
    }
}
