using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public Transform Ball;
    private Vector3 Offset;
    public float SmoothSpeed;

    void Start()
    {
        Offset = transform.position - Ball.position;
    }

    void Update()
    {
        Vector3 NewPos = Vector3.Lerp(transform.position, Offset + Ball.position, SmoothSpeed);
        transform.position = NewPos;
    }
}
