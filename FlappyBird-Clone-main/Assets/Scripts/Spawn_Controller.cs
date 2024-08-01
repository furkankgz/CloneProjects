using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Controller : MonoBehaviour
{
    public GameObject PipePrefab;
    public float minY;
    public float maxY;
    public float x;
    public float interval;

    void Start()
    {
        InvokeRepeating("Spawn", interval, interval);
    }

    void Spawn()
    {
        GameObject instance = Instantiate(PipePrefab);
        instance.transform.position = new Vector2(x, Random.Range(minY, maxY));
        instance.transform.SetParent(transform);
    }

}
