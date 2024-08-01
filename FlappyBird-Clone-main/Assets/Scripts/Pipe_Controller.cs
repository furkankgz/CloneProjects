using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe_Controller : MonoBehaviour
{
    public float Speed;
    public float LifeTime;

    void Update()
    {
        transform.position += Vector3.left * Speed * Time.deltaTime;
        Destroy(gameObject, LifeTime);
    }
}
