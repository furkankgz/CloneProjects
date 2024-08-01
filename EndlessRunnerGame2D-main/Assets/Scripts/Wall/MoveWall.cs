using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    public float _wallMoveSpeed;

    void Update()
    {
        transform.position += Vector3.left * _wallMoveSpeed * Time.deltaTime;
    }
}
