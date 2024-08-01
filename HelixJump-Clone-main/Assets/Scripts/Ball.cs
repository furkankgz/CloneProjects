using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody Rb;
    public float JumpForce;
    public GameObject SplashPrefab;
    private GameManager Gm;

    void Start()
    {
        Gm = GameObject.FindObjectOfType<GameManager>();
    }
    
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rb.AddForce(Vector3.up * JumpForce);
        string MaterialName = collision.gameObject.GetComponent<MeshRenderer>().material.name;
        GameObject Splash = Instantiate(SplashPrefab, transform.position + new Vector3(0f, -0.22f, 0f), transform.rotation);
        Splash.transform.SetParent(collision.gameObject.transform);

        if (MaterialName == "UnsafeColor (Instance)")
        {
            Gm.RestartGame();
        }
        else if (MaterialName == "Last Ring (Instance)")
        {
            Debug.Log("Next Level");
        }
    }
}
