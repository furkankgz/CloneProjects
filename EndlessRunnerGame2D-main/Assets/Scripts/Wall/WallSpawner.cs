using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public float _maxTime;
    private float _time;

    public float _maxHeight;
    public float _minHeight;

    public GameObject _wallPrefab;
    GameObject _wall;

    void Start()
    {
        _time = 1;
    }

    void Update()
    {
        if (_time > _maxTime)
        {
            _wall = Instantiate(_wallPrefab);
            _wall.transform.position = transform.position + new Vector3(0f, Random.Range(_minHeight, _maxHeight), 0f);
            _time = 0;
        }
        _time += Time.deltaTime;
        Destroy(_wall, 8f);
    }
}
