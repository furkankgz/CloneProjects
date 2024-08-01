using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTailEffect : MonoBehaviour
{
    public float _startTimeBtwSpawn;
    float _timeBtwSpawn;
    public GameObject _tailPrefab;
    void Update()
    {
        if (_timeBtwSpawn <= 0)
        {
            GameObject _tail = Instantiate(_tailPrefab, transform.position, Quaternion.identity);
            _timeBtwSpawn = _startTimeBtwSpawn;
            Destroy(_tail, 4f);
        }
        else
        {
            _timeBtwSpawn -= Time.deltaTime;    
        }
    }
}
